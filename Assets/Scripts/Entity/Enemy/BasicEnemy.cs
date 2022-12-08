using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour
{

    protected Rigidbody rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected GameObject playerObj = null;
    protected Vector3 playerPos = Vector3.zero;
    public LevelManagerEnemies levelManager;
    public bool useLM = true; 

    [Header("Stats")]
    [SerializeField] protected int speed = 4;
    protected bool stop = false;
    public float maxHP = 10;
    [SerializeField] protected float currentHP;
    public float defaultAttackDistance;
    public float actionDistance;

    protected bool facingRight = true;
    protected float oldPosX;


    [Header ("Combat")]
    protected bool dead = false;
    public bool intangible = false;
    [SerializeField] protected float intangibleLength = 0.5f;
    protected float timeCount;
    protected LayerMask enemyLayer;





    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // if (TryGetComponent(out LevelManagerEnemies levelManager)){
        //     levelManager = GetComponent<LevelManagerEnemies>();
        // } else {
        //     useLM = false;
        // }
        currentHP = maxHP;
        if (playerObj==null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        enemyLayer = LayerMask.GetMask("Player");
        if(!useLM){
            levelManager = null;
        }

    }

    private void LateUpdate() {
        oldPosX = transform.position.x;
        if (intangible & !dead){
            if (Time.time > timeCount+intangibleLength){
                intangible = false;
            }
        }

        if (transform.position.y < -100){
            Die();
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!dead){
            playerPos = new Vector3(playerObj.transform.position.x, 0, playerObj.transform.position.z);

            if (Vector3.Distance(transform.position, playerPos) > defaultAttackDistance & Vector3.Distance(transform.position, playerPos) < actionDistance)
            {
                Move(playerPos);
                // CheckFlip();
            } 
        }
   
    }

    void Move(Vector3 targetPos){

        // Debug.Log(playerPos);
        var Step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Step);
    }
    protected void CheckFlip(){

        // For if enemy doesn't move, but the player moves to other side.
        if (Vector3.Distance(transform.position, playerPos) < defaultAttackDistance)
        {
            if ((playerPos.x - transform.position.x) > 0 && !facingRight){
                Flip();
            }
            if ((playerPos.x - transform.position.x) < 0 && facingRight){
                Flip();
            }
            return;
        }

        // Otherwise, check direction heading
        if ((transform.position.x - oldPosX) > 0 && !facingRight){
            Flip();
        }
        if ((transform.position.x - oldPosX) < 0 && facingRight){
            Flip();
        }
    }
    private void Flip(){
        Vector3 currentFlip = transform.localScale;
        currentFlip.x *= -1;
        transform.localScale = currentFlip;

        facingRight = !facingRight;
    }

    public void TakeDamage(float damage){
        if (!intangible){
            currentHP -= damage;
            intangible = true;
            timeCount = Time.time;
            StartCoroutine(DamageFlash());
            Debug.Log(name+" took "+damage+" damage!");

            //hurtAnimation

            if (currentHP<= 0){
                dead = true;
                Die();
            }
        }
        
    }

    protected virtual IEnumerator DamageFlash(){
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    } 

    protected virtual void Die(){
        intangible = true;
        StartCoroutine(DeathFade());
        Debug.Log(name+" died");

        if (useLM){
            levelManager.enemiesList.Remove(this);
            levelManager.CheckIfCleared();
        }

        Destroy(gameObject, 2f);
        //Die animation
        //Disable this enemy
    }

    protected virtual IEnumerator DeathFade(){
        float time = 0;
        float duration = 1.5f;
        Color start = spriteRenderer.color;
        while(time < duration){
            spriteRenderer.color = Color.Lerp(start, Color.clear, time/duration);
            time+= Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = Color.clear;
    }

    public static explicit operator BasicEnemy(GameObject v)
    {
        throw new NotImplementedException();
    }

    
}
