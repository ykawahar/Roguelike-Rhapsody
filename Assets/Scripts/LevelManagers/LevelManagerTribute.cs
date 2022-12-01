using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerTribute : MonoBehaviour
{
    public GameObject statue;
    private List<int> statueTypes = new List<int>(){1,2};

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

        int index = Random.Range(0, statueTypes.Count);
        Debug.Log("Index 1: " + index);
        Debug.Log("Count 1: " + statueTypes.Count);
        GameObject leftStatue = Instantiate(statue, new Vector3(transform.position.x-10, transform.position.y+6f, transform.position.z+7f), Quaternion.Euler(30,0,0));
        TributeStatue script = leftStatue.GetComponent<TributeStatue>();
        script.type = statueTypes[index];
        // script.type = 2;
        script.Initialize();
        statueTypes.RemoveAt(index);

        index = Random.Range(0, statueTypes.Count);
        Debug.Log("Index 2: " + index);
        Debug.Log(statueTypes.Count);
        GameObject rightStatue = Instantiate(statue, new Vector3(transform.position.x+10, transform.position.y+6f, transform.position.z+7f), Quaternion.Euler(30,0,0));
        TributeStatue rightScript = rightStatue.GetComponent<TributeStatue>();
        rightScript.type = statueTypes[index];
        // rightScript.type = 1;
        rightScript.Initialize();
    }

    
}

