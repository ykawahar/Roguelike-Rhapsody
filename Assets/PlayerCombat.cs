using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour  
{
    public Transform attackPoint;
    public float attackRange = 1.35f;
    public LayerMask enemyLayers;
    // private Collider[] overlapResults = new Collider[10];


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BasicSwing(float damage){
        //Detect in range
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        //Using NonAlloc (saves RAM)
        // int numHit = Physics.OverlapSphereNonAlloc(attackPoint.position, attackRange, overlapResults, enemyLayers);

        //Deal Damage
        foreach(Collider enemy in hitEnemies){
            enemy.GetComponent<BasicEnemy>().TakeDamage(damage);
        }

    }

    void OnDrawGizmosSelected(){
        if (attackPoint == null){
            return;
        }

        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
