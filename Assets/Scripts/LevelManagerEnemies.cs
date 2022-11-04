using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerEnemies : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemies();
        // transform.position = Random.insideUnitCircle * 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies(){
        for (int i = 0; i<= Random.Range(3,10); i++) {
            float randX = Random.Range(-32,32);
            float randZ = Random.Range(-13, 13);
            Vector3 position = new Vector3(randX, 0, randZ);
            
            Instantiate(enemy, position, Quaternion.Euler(0,1,0));
        }

    }
}
