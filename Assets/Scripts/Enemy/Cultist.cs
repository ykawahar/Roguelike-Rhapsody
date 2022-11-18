using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    private GameObject playerObj = null;
    private Rigidbody rb;
    [SerializeField] Animator animator;
    private bool facingRight = false;
    private float oldPosX;

    [Header ("Hovering")]
    private float startY;
    public float floatingHeight = 0.3f; 
    public float floatingSpeed = 1f;
    
    




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        if (playerObj==null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        var position = transform.position;
        startY = transform.position.y+floatingHeight;
        oldPosX = transform.position.x;
    }

    private void LateUpdate() {
        oldPosX = transform.position.x;
    }



    // Update is called once per frame
    void Update()
    {
        Hover(); //Constant Hover
        


        Vector3 playerPos = new Vector3(playerObj.transform.position.x, 0, playerObj.transform.position.z);

        if (Vector3.Distance(transform.position, playerPos) < 6f)
        {
            animator.SetTrigger("Stab");
        }


        if ((transform.position.x - oldPosX) > 0 && !facingRight){
            Flip();
        }
        if ((transform.position.x - oldPosX) < 0 && facingRight){
            Flip();
        }
    }

    void Hover(){
        float newY = startY + floatingHeight*Mathf.Sin(Time.time*floatingSpeed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void CheckFlip(){
        

    }

    private void Flip(){
        Vector3 currentFlip = transform.localScale;
        currentFlip.x *= -1;
        transform.localScale = currentFlip;

        facingRight = !facingRight;
    }
}
