using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManagerEnemies : MonoBehaviour
{
    public GameObject enemy;
    public List<BasicEnemy> enemiesList;

    public GameObject gate;

    public GameObject textLogManager;
    private TextManager textLog;
    private int difficulty;


    // Start is called before the first frame update
    void Start()
    {

        enemiesList = new List<BasicEnemy>();
        textLog = textLogManager.GetComponent<TextManager>();
        SpawnEnemies();
        gate = GameObject.FindGameObjectWithTag("Gate");
        gate.SetActive(false);
        

        // transform.position = Random.insideUnitCircle * 10;
        // StartCoroutine("WaitAndSwitchScene");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void CheckIfCleared(){
        //Conditions to clear level
        if (enemiesList.Count<= 0){
            StartCoroutine(RevealGate(1));
        }
    }

    IEnumerator RevealGate(float delay){
        yield return new WaitForSeconds(delay);
        gate.SetActive(true);
    }

    void SpawnEnemies(){

        for (int i = 0; i<= Random.Range(3,10); i++) {
            float randX = Random.Range(-32,32);
            float randZ = Random.Range(-13, 13);
            Vector3 position = new Vector3(randX, 2, randZ);
            
            BasicEnemy newEnemy = (BasicEnemy) Instantiate(enemy, position, Quaternion.Euler(30,1,0)).GetComponent<BasicEnemy>();
            enemiesList.Add(newEnemy);
            newEnemy.levelManager = this;
            newEnemy.transform.parent = transform;
        }
        // textLog.messageQueue.Enqueue(textLog.slimeSubjectList[Random.Range(0, textLog.slimeSubjectList.Count)] + " " + textLog.slimeDescriptorList[Random.Range(0, textLog.slimeDescriptorList.Count)] + " " + textLog.slimeDescriptorList2[Random.Range(0, textLog.slimeDescriptorList2.Count)] + " " + textLog.slimeActionList[Random.Range(0, textLog.slimeActionList.Count)]);
    }

    // IEnumerator WaitAndSwitchScene(){
    //     yield return new WaitForSeconds(10);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("TributeArea");
    // }
}
