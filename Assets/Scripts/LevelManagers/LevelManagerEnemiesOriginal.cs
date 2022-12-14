using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerEnemiesOriginal : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemiesList;
    public GameObject gate;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
        // transform.position = Random.insideUnitCircle * 10;

        enemiesList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfCleared(); //instantly returns true, needs to either wait to spawn or have 1 enemy in list before scene starts
    }

    public void CheckIfCleared(){
        //Conditions to clear level
        if (enemiesList.Count<= 0){
            gate.SetActive(true);
        }
    }

    void SpawnEnemies(){

        for (int i = 0; i<= Random.Range(3,10); i++) {
            float randX = Random.Range(-32,32);
            float randZ = Random.Range(-13, 13);
            Vector3 position = new Vector3(randX, 3, randZ);
            
            GameObject newSpawn = Instantiate(enemy, position, Quaternion.Euler(30,1,0));
            enemiesList.Add(newSpawn);
            Debug.Log(enemiesList);
        }

    }
}
