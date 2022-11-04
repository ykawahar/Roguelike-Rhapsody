using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerTribute : MonoBehaviour
{
    public GameObject statue;
    // Start is called before the first frame update
    void Start()
    {

        SpawnTribute();
           
        // transform.position = Random.insideUnitCircle * 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTribute(){
        Instantiate(statue, new Vector3(transform.position.x-10, transform.position.y+1.5f, transform.position.z-3), Quaternion.Euler(45,0,0));
        Instantiate(statue, new Vector3(transform.position.x+10, transform.position.y+1.5f, transform.position.z-3), Quaternion.Euler(45,0,0));
    }
}

