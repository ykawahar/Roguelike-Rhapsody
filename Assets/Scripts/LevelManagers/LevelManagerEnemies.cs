using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerEnemies : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemiesList;

    public GameObject textLogManager;
    private TextManager textLog;
    private int difficulty;

    // Start is called before the first frame update
    void Start()
    {

        textLog = textLogManager.GetComponent<TextManager>();
        SpawnEnemies();
        enemiesList = new List<GameObject>();
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
            //progress
        }
    }

    void SpawnEnemies(){

        for (int i = 0; i<= Random.Range(3,10); i++) {
            float randX = Random.Range(-32,32);
            float randZ = Random.Range(-13, 13);
            Vector3 position = new Vector3(randX, 2, randZ);
            
            Instantiate(enemy, position, Quaternion.Euler(30,1,0));
        }
        // textLog.messageQueue.Enqueue(textLog.slimeSubjectList[Random.Range(0, textLog.slimeSubjectList.Count)] + " " + textLog.slimeDescriptorList[Random.Range(0, textLog.slimeDescriptorList.Count)] + " " + textLog.slimeDescriptorList2[Random.Range(0, textLog.slimeDescriptorList2.Count)] + " " + textLog.slimeActionList[Random.Range(0, textLog.slimeActionList.Count)]);
    }

    // IEnumerator WaitAndSwitchScene(){
    //     yield return new WaitForSeconds(10);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("TributeArea");
    // }
}
