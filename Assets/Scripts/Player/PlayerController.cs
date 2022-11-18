using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Logic")]
    private CharacterController charController;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    public AudioClip swooshAudio;
    private PlayerCombat playerCombat;
    
    [Header ("Stats")]
    public float maxHP = 100f;
    public float strength = 3f;
    public float moveSpeed = 5f;

    [Range(0,100)]
    public float currentHP;
    public float basicDamage = 1;

    [Header ("vertical forces")]
    private float gravity = 9.8f;
    private float jumpSpeed = 5f;
    private float jumpHeight = 1f;
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
    private float basicAttackRate = 2f;
    private float nextAttackTime = 0f;

    // [Header ("LayerMasks")]
    // private int EnemyLayer = LayerMask.NameToLayer("Enemy"); 

    // public Collider attackBox; 

    
    

     
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
        currentHP = maxHP;

        audioSource = GetComponent<AudioSource>();

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
        moveDirection *= moveSpeed;
        Debug.Log(moveDirection);
            
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

        Debug.Log(moveDirection);

        //Snap Falling
        // if (moveDirection.y < 0){
        //     moveDirection.y -= gravity*Time.deltaTime*(2.5f-1);
        // }
        
        charController.Move(moveDirection * Time.deltaTime * moveSpeed);


    }

    void Update()
    {
        Debug.Log("grounded = " + charController.isGrounded);
        /// Movement
        if (charController.isGrounded){
            animator.SetBool("Grounded", true);
            if (canMove){
                Move();
            }
            if (Time.time > nextAttackTime){
                if(Input.GetMouseButtonDown(0)){
                    Attack();
                    nextAttackTime = Time.time + 1f/basicAttackRate;
                }
            }
            
            

        } else {
            animator.SetBool("Grounded", false);
        }

        moveDirection.y -= gravity*Time.deltaTime; //Gravity

        animator.SetFloat("Speed", (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)));
        
        charController.Move(moveDirection * Time.deltaTime * moveSpeed);
        
       
    }

    private Vector3 Move(){
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveDirection *= moveSpeed;

        CheckFlip(moveDirection.x); //Flip sprite if necessary

        if (Input.GetButton("Jump")){
            moveDirection.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
            moveDirection = airMove(moveDirection.y);
            // moveDirection.y = jumpSpeed;
        }
        animator.SetFloat("Speed", (Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z)));
        return moveDirection;
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
            moveDirection *= moveSpeed/3;
        }
        return moveDirection;
    }

    void Attack()
    {
        moveDirection=Vector3.zero; 
        animator.SetTrigger("Attack");
        playerCombat.BasicSwing(strength*basicDamage);

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
            float damage = 10*strength;

            

            Debug.Log(c.name);
            // c.GetComponent<BasicEnemy>().TakeDamage(damage);
            // if (c.GetComponent<BasicEnemy>().hp <= 0){
            //     Destroy(c);
            // }

        }
    }
    
    public float GetMaxHP(){
        return maxHP;
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Enemy"){
            currentHP -= 5;
        }
    }

    // private void OnCollisionEnter(Collision other) {
    //     if (other.gameObject.layer == EnemyLayer){
            
    //     }
    // }

    void Death(){
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    void CanMove(){
        canMove = true;
    }

    void CannotMove(){
        canMove = false;
    }

}
