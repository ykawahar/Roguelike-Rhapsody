using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    private GameObject playerObj = null;
    private int speed = 4;
    private bool stop = false;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj==null){
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Player Position: X = " + playerObj.transform.position.x + " --- Y = " + playerObj.transform.position.y + " --- Z = " + 
        //  playerObj.transform.position.z);
        Vector3 playerPos = new Vector3(playerObj.transform.position.x, 0, playerObj.transform.position.z);

        if (Vector3.Distance(transform.position, playerPos) < 3f)
        {
            Debug.Log("Stop");
        } else {
            Move(playerPos);
        }

    }

    void Move(Vector3 targetPos){

        // Debug.Log(playerPos);
        var Step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Step);
    }


}
