using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Logic")]
    private CharacterController charController;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private BoxCollider boxCollider;
    [SerializeField] private AudioClip swooshAudio;
    private PlayerCombat playerCombat;
    
    [Header ("Stats")]
    // public float maxHP = 100f;
    // public float strength = 3f;
    // public float moveSpeed = 5f;
    // [Range(0,100)]
    // public float groundMoveSpeed = 5f;
    // // [Range(0,100)]
    // public float airMoveSpeed = 2.5f;
    // [Range(0,100)]
    // public float currentHP;
    // public float basicDamage = 1;
    // public int maxJumpCount = 1;
    private int currentJumpCount = 0;
    // public float knockbackStrength = 2;

    [Header ("vertical forces")]
    private float gravity = 9.8f;
    // private float jumpSpeed = 5f;
    [SerializeField] private float jumpHeight = 0.6f;
    private float vertSpeed = 0;

    [Header ("Movement")]
    private Vector3 moveDirection = Vector3.zero;
    private bool canMove = true;

    [Header ("Ground Check")]
    private bool grounded;
    private float groundCheckDistance = 1f;
    [SerializeField] private LayerMask groundMask;

    [Header ("Animation")]
    private bool facingRight = true;

    [Header ("Combat")]
    // private float basicAttackRate = 2f;
    private float nextAttackTime = 0f;
    // protected bool dead = false;
    private bool intangible = false;
    [SerializeField] protected float intangibleLength = 0.5f;
    protected float timeCount;

    // [Header ("LayerMasks")]
    // private int EnemyLayer = LayerMask.NameToLayer("Enemy"); 

    // public Collider attackBox; 

    
    

     
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        playerCombat = GetComponent<PlayerCombat>();
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void UpdateOld()
    {
        // grounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask); // PlayerPos, distanceToGround, WhatIsGround
        // if (grounded){
        //     Debug.Log("Grounded");
        // }
        // if(grounded && moveDirection.y < 0){
        //     moveDirection.y = -2f;
        // }

        // Debug.Log("grounded = " + charController.isGrounded);
        
        if (charController.isGrounded){
            animator.SetBool("Grounded", true);


        /// Movement
        // if (grounded){
            if (canMove){
                MoveDefunct();
            }
        
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }

        //     
        //     AttackCheck(attackBox);
        // }

        // if (currentHP <= 0){
        //     Death();
        // }
        
        // vertSpeed -= gravity * Time.deltaTime;
        // _controller.Move(vertSpeed * Time.deltaTime);
        
    } else {
        animator.SetBool("Grounded", false);
    }

    void MoveDefunct(){
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveDirection *= PlayerStats.moveSpeed;
        // Debug.Log(moveDirection);
            
        if (moveDirection.x > 0 && !facingRight){
            flip();
        }
        if (moveDirection.x < 0 && facingRight){
            flip();
        }
            

        if (Input.GetButton("Jump")){
            moveDirection.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            moveDirection = airMove(moveDirection.y);
            // moveDirection.y = jumpSpeed;
        }
        }

        if (!charController.isGrounded){
            animator.SetBool("Grounded", false);
        }
        
        moveDirection.y -= gravity*Time.deltaTime; //Gravity



        animator.SetFloat("Speed", (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)));

        // Debug.Log(moveDirection);

        //Snap Falling
        // if (moveDirection.y < 0){
        //     moveDirection.y -= gravity*Time.deltaTime*(2.5f-1);
        // }
        
        charController.Move(moveDirection * Time.deltaTime * PlayerStats.moveSpeed);


    }

    void Update()
    {
        isGrounded();
        // Debug.Log("grounded = " + charController.isGrounded);
        /// Movement
        if (charController.isGrounded){
            animator.SetBool("Grounded", true);
            // animator.SetBool("Jump_Bool", false);
            currentJumpCount = 0;
            // moveSpeed = groundMoveSpeed;
            if (canMove){
                Move();
            }
            if (Time.time > nextAttackTime){
                if(Input.GetMouseButtonDown(0)){
                    Attack();
                    nextAttackTime = Time.time + 1f/PlayerStats.basicAttackRate;
                }
                if(Input.GetKeyDown("q")){
                    SpecialAttack();
                    nextAttackTime = Time.time + 3f/PlayerStats.basicAttackRate;
                }
            }
            
            

        } else {
            animator.SetBool("Grounded", false);
        }

        if (charController.isGrounded & currentJumpCount == 0 || !charController.isGrounded & (currentJumpCount<PlayerStats.maxJumpCount)){

            if (Input.GetButtonDown("Jump")){
                // animator.SetBool("Jump_Bool", false);
                currentJumpCount +=1;
                moveDirection.y = Jump();
                animator.SetTrigger("Jump");
                // animator.SetBool("Jump_Bool", true);
            }
        }

        moveDirection.y -= gravity*Time.deltaTime; //Gravity
 

        animator.SetFloat("Speed", (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)));

        // Snap Falling
        if (moveDirection.y < 0){
            moveDirection.y -= gravity*Time.deltaTime*(2.5f-1);
        }
        
        charController.Move(moveDirection * Time.deltaTime * PlayerStats.moveSpeed);
        
       
    }

    private void LateUpdate() {
        if (intangible & !PlayerStats.dead){
            if (Time.time > timeCount+intangibleLength){
                intangible = false;
            }
        }
    }

    private bool isGrounded(){
        RaycastHit raycastHit;
        Physics.Raycast(boxCollider.bounds.center, Quaternion.Euler(30,1,0)*Vector3.down,  out raycastHit, boxCollider.bounds.extents.y + 0.05f, groundMask); 
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider.bounds.center, Quaternion.Euler(30,1,0)*Vector3.down * (boxCollider.bounds.extents.y + 0.5f), rayColor); 
        // Debug.Log(raycastHit.collider);
        return raycastHit.collider !=null;
    }

    private Vector3 Move(){
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveDirection *= PlayerStats.moveSpeed;

        CheckFlip(moveDirection.x); //Flip sprite if necessary

        // if (Input.GetButton("Jump")){
        //     moveDirection.y = Jump();
        //     moveDirection = airMove(moveDirection.y);
        //     // moveDirection.y = jumpSpeed;
        // }
        animator.SetFloat("Speed", (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)));
        return moveDirection;
    }

    private float Jump(){
        moveDirection.y = Mathf.Sqrt(jumpHeight * 2 *gravity);
        // moveDirection.y += jumpHeight * gravity * 2.5f * Time.deltaTime;
        
        // if (currentJumpCount <maxJumpCount){
        //     if(Input.GetButton("Jump")){
        //         moveDirection.y = Jump();
        //     }
        // }
        // moveSpeed = airMoveSpeed;
        // moveDirection.x = moveDirection.x*0.5f
        // moveDirection.z = moveDirection..z*0.5f
        return moveDirection.y;
    }

    private void flip(){
        Vector3 currentFlip = transform.localScale;
        currentFlip.x *= -1;
        transform.localScale = currentFlip;

        facingRight = !facingRight;
    }

    private void CheckFlip(float heading){
        if (heading > 0 && !facingRight){
            flip();
        }
        if (heading < 0 && facingRight){
            flip();
        }
    }

    private Vector3 airMove(float yMove){
       if (!charController.isGrounded){
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), yMove, Input.GetAxisRaw("Vertical")).normalized;
            moveDirection *= PlayerStats.moveSpeed/3;
        }
        return moveDirection;
    }

    void Attack()
    {
        moveDirection=Vector3.zero; 
        animator.SetTrigger("Attack");
        playerCombat.BasicSwing(PlayerStats.strength*PlayerStats.basicDamage, PlayerStats.knockbackStrength);

        audioSource.clip = swooshAudio;
        audioSource.Play();
        // var nextClip:AudioClip;
        // nextClip = Resources.Load("Assets/Music/swoosh",AudioClip);
        // audioSource.clip = nextClip;

        // Collider[] hitEnemies = Physics HitSphere(attackPoint.position, attackRange);
        // foreach(Collider hits in hitEnemies){
        //     Debug.Log("hit " + hits);
        // }

    }
    private void AttackCheck(Collider col){
        Collider [] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HurtBox"));
        foreach(Collider c in cols){
            if(c.transform.parent==transform) {
                continue;
            }
            float damage = 10*PlayerStats.strength;

            

            Debug.Log(c.name);
            // c.GetComponent<BasicEnemy>().TakeDamage(damage);
            // if (c.GetComponent<BasicEnemy>().hp <= 0){
            //     Destroy(c);
            // }

        }
    }

    private void SpecialAttack(){
        moveDirection=Vector3.zero; 
        playerCombat.AntiGravity(10);
    }
    
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Enemy"){
            PlayerStats.currentHealth -= 5;
        }
    }

    // private void OnCollisionEnter(Collision other) {
    //     if (other.gameObject.layer == EnemyLayer){
            
    //     }
    // }

    public void TakeDamage(float damage){
        if (!intangible){
            PlayerStats.currentHealth -= damage;
            intangible = true;
            timeCount = Time.time;
            StartCoroutine(DamageFlash());
            Debug.Log(name+" took "+damage+" damage!");

            //hurtAnimation

            if (PlayerStats.currentHealth<= 0){
                PlayerStats.dead = true;
                Die();
            }
        }
        
    }

    protected virtual IEnumerator DamageFlash(){
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    } 

    void Die(){
        intangible = true;
        spriteRenderer.color = Color.black;
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    void CanMove(){
        canMove = true;
    }

    void CannotMove(){
        canMove = false;
    }

    void ToggleIntangible(){
        intangible = true;
    }

}
