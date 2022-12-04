using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : BasicEnemy
{
    public int sizeCategory = 1;
    public GameObject selfCopy;
    public Vector3 scale;

    // Start is called before the first frame update
   protected override void Start()
    {
        base.Start();
        facingRight = false;
        var position = transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame


    protected override void Die(){

        Vector3 newSpawnPos = new Vector3(transform.position.x - 1, transform.position.y+0.5f, transform.position.z);

            GameObject clone = Instantiate(selfCopy, newSpawnPos, Quaternion.Euler(30,1,0));
            // clone.transform.localScale = transform.localScale * 0.5f * Random.Range(0.8f, 1.2f);
            
        
        // base.Die();
    }
}
