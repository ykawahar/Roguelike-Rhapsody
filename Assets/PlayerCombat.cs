using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombat : MonoBehaviour  
{
    public Transform attackPoint;
    public float attackRange = 1.35f; //1.35f for sprite length
    public LayerMask enemyLayers;
    public CircleField circleField;

    private bool isCoroutineExecuting = false;
    // private Collider[] overlapResults = new Collider[10];

    public Vector3 localBasePoint = new Vector3(0, -5, -0.25f);

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicSwing(float damage, float knockback){
        //Detect in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Using NonAlloc (saves RAM)
        // int numHit = Physics.OverlapSphereNonAlloc(attackPoint.position, attackRange, overlapResults, enemyLayers);

        //Deal Damage
        foreach(Collider enemy in hitEnemies){
            enemy.GetComponent<BasicEnemy>().TakeDamage(damage);
            Rigidbody rb = enemy.GetComponent<Rigidbody>();
            if(rb!=null){
                // Vector3 direction = enemy.transform.position - transform.position;
                // rb.AddForce(-direction.normalized * knockback, ForceMode.Impulse);
                rb.AddExplosionForce(knockback, transform.position, 5f, 2f, ForceMode.Impulse);
            }
        }
    }

    public void AntiGravity(float damage){
        CircleField field = Instantiate(circleField, transform.TransformPoint(localBasePoint), Quaternion.Euler(0,0,0));
        field.enemyLayer = enemyLayers;
        float time = 0;
        // Collider[] hitEnemies = StartCoroutine(GetCollider(field));
        field.StartExpand(ExpandFinished);
        
        //Collider[] hitEnemies = field.ReturnHitEnemies();
        

    }

    public void ExpandFinished(Collider[] hitEnemies){

        Debug.Log("Action Completed");
        foreach (Collider enemy in hitEnemies){
            enemy.GetComponent<BasicEnemy>().TakeDamage(10);
        }
    }

    // private IEnumerator GetCollider(CircleField field){
        
    //     yield return new WaitForSeconds (3);
    //     Debug.Log("HI");
    //     Collider[] hitEnemies = field.ReturnHitEnemies();
    //     return hitEnemies;
    // }

    void OnDrawGizmosSelected(){
        if (attackPoint == null){
            return;
        }

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    IEnumerator WaitTimer(float time){
        if (isCoroutineExecuting){
            yield break;
        }
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        isCoroutineExecuting = false;
    }
}
