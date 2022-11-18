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

}
