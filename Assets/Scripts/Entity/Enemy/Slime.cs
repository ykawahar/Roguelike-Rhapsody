using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : BasicEnemy
{
    public int sizeCategory;
    public GameObject selfCopy;
    public Vector3 scale;
    public float strength;
    public bool attack;
    public LayerMask groundLayer;
    public Collider col;
    private Collider[] overlapResults = new Collider[1];
    public Transform attackPoint;
    public float attackRange = 0.9f;
    private float nextAttackTime = 0f;
    private float attackRate = 4f;

    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        facingRight = false;
        var position = transform.position;
        scale = transform.localScale;
        maxHP = 10*sizeCategory;
        strength = (sizeCategory-1) * 4;
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, playerPos) < defaultAttackDistance){
            // new Vector3(transform.position.x, 0, transform.position.z), new Vector3(playerPos.x, 0, playerPos.z)
            if(Random.value<0.4 & isGrounded()){
                Jump();
                attack = true;
            }
        }
    }

    void Jump(){
        rb.AddForce(new Vector3(0, 5*(5-sizeCategory), 0), ForceMode.Impulse);
        if (Time.time > nextAttackTime){
            StartCoroutine(Attack(5f));
            nextAttackTime = Time.time + 1f/attackRate;
        }
        
    }

    IEnumerator Attack(float delay){
        if (attack){
            int numHit = Physics.OverlapSphereNonAlloc(attackPoint.position, attackRange, overlapResults, enemyLayer);
            for(int i=0; i<numHit; i++){
                overlapResults[i].GetComponent<PlayerController>().TakeDamage(strength);
                Rigidbody rb = overlapResults[i].GetComponent<Rigidbody>();
                if(rb!=null){
                    rb.AddExplosionForce(20f, transform.position, 5f, 2f, ForceMode.Impulse);
                }
            }
        }
        yield return new WaitForSeconds(delay);
    }

    bool isGrounded(){
        return Physics.Raycast(transform.position, -Vector3.up, col.bounds.extents.y + 1f);
    }

    protected override void Die(){
        if (sizeCategory > 1){
            for (int i = 0; i<3; i++){
                Vector3 newSpawnPos = new Vector3(transform.position.x - (2 + i)*2, transform.position.y, transform.position.z +2 -i);

                BasicEnemy clone = (BasicEnemy) Instantiate(selfCopy, newSpawnPos, Quaternion.Euler(30,1,0)).GetComponent<BasicEnemy>();
                if (useLM){
                    levelManager.enemiesList.Add(clone);
                    clone.useLM = true;
                    clone.levelManager = levelManager;
                    clone.transform.parent = levelManager.transform;
                }
            // float scaleFactor = Random.Range(0.8f, 1.2f);
            // GameObject clone = Instantiate(Resources.Load("Prefabs/Entity Prefabs/Slime Blue"), newSpawnPos, Quaternion.Euler(30,1,0)) as GameObject;
            // instance.transform.localScale = transform.localScale * 0.5f * Random.Range(0.8f, 1.2f);
            // clone.transform.localScale = new Vector3(transform.localScale.x * 0.5f * scaleFactor,transform.localScale.y * 0.5f * scaleFactor, transform.localScale.z * 0.5f * scaleFactor);
            // clone.transform.localScale = new Vector3(2,2,2);
            }
        }
        base.Die();
    }

    void OnDrawGizmosSelected(){
        if (attackPoint == null){
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red;
    }
}