using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController charController;
    
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private float speed = 10;

    private float currentHP;

    private float gravity = 9.8f;
    private float jumpSpeed = 5f;
    private float jumpHeight = 5f;

    private float vertSpeed = 0;

    private Vector3 moveDirection = Vector3.zero;

    private bool grounded;

    Transform attackPoint;
    float attackRange = 0.5f;

    


     
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        currentHP = maxHP;

    }

    // Update is called once per frame
    void Update()
    {
        if (charController.isGrounded){
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity*Time.deltaTime;

        charController.Move(moveDirection * Time.deltaTime * speed);
        
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Attack");
        }
        

        // vertSpeed -= gravity * Time.deltaTime;
        // _controller.Move(vertSpeed * Time.deltaTime);
        
    }

    void Attack()
    {

        
        // Collider[] hitEnemies = Physics HitSphere(attackPoint.position, attackRange);
        // foreach(Collider hits in hitEnemies){
        //     Debug.Log("hit " + hits);
        // }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint = null){
            return;
        }
        // Gizmos DrawWireSphere(attackPoint.position, attackRange);
    }

    float GetHP(){
        return maxHP;
    }
}
