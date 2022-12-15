using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : BasicEnemy
{
    public int sizeCategory;
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
        if (sizeCategory > 1){
            for (int i = 0; i<5; i++){
            Vector3 newSpawnPos = new Vector3(transform.position.x - 2 + i, transform.position.y, transform.position.z +2 -i);

            GameObject clone = Instantiate(selfCopy, newSpawnPos, Quaternion.Euler(30,1,0));
            // float scaleFactor = Random.Range(0.8f, 1.2f);
            // GameObject clone = Instantiate(Resources.Load("Prefabs/Entity Prefabs/Slime Blue"), newSpawnPos, Quaternion.Euler(30,1,0)) as GameObject;
            // instance.transform.localScale = transform.localScale * 0.5f * Random.Range(0.8f, 1.2f);
            // clone.transform.localScale = new Vector3(transform.localScale.x * 0.5f * scaleFactor,transform.localScale.y * 0.5f * scaleFactor, transform.localScale.z * 0.5f * scaleFactor);
            // clone.transform.localScale = new Vector3(2,2,2);
            }
        }
        

        
        
            base.Die();
    }
}
