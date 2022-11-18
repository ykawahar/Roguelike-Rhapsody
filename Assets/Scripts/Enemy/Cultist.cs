using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : BasicEnemy
{

    [Header ("Hovering")]
    private bool hover = true;
    private float startY;
    public float floatingHeight = 0.3f; 
    public float floatingSpeed = 1f;


    [Header ("Combat")]
    public float strength = 1;
    private Collider[] overlapResults = new Collider[1];
    public Transform attackPoint;
    public Transform tipAttackPoint;
    public float attackRange = 0.9f;
    public float tipAttackRange = 0.5f;

    private bool tip = false;
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        facingRight = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        var position = transform.position;
        startY = transform.position.y+floatingHeight;
        oldPosX = transform.position.x;

    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!dead){
            if (hover){
            Hover(); //Constant Hover
            }
        
            CheckFlip();

            if (Vector3.Distance(transform.position, playerPos) < 6f)
            {
                hover = false;
                Stab();
                animator.SetTrigger("Stab");

            } else{
                if (hover!= true){
                    hover = true;
                }
            }
        }
        

    }

    void Hover(){
        float newY = startY + floatingHeight*Mathf.Sin(Time.time*floatingSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void Stab(){
        float damage = strength+3;
        float tipMod = 0.5f;

        
        if (tip){
            int numTipHit = Physics.OverlapSphereNonAlloc(tipAttackPoint.position, tipAttackRange, overlapResults, enemyLayer);
            if (numTipHit>0){
                for(int i=0; i<numTipHit; i++){
                    overlapResults[i].GetComponent<PlayerController>().TakeDamage(damage*tipMod);
                }
            }
        } else {
            int numHit = Physics.OverlapSphereNonAlloc(attackPoint.position, attackRange, overlapResults, enemyLayer);
            for(int i=0; i<numHit; i++){
                overlapResults[i].GetComponent<PlayerController>().TakeDamage(damage);
            }
        }

        if(tip){
            ToggleTip();
        }
    }

    void OnDrawGizmosSelected(){
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(tipAttackPoint.position, tipAttackRange);
    }

    void ToggleTip(){
        tip = !tip;
    }

}
