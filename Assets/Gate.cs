using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Gate : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //check if collision with ball happens
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Hello: ");
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Hello: ");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
