using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradePopup : MonoBehaviour
{
    public GameObject popupL;
    public GameObject popupR;
    private GameObject spawnedPopup;
    public bool right = true;
    private bool spawned = false;
    public GameObject gate;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if (other.tag=="Player" & !spawned){
            if (right){
                spawnedPopup = Instantiate(popupR);
                spawnedPopup.transform.parent = transform;
            } else {
                spawnedPopup = Instantiate(popupL);
                spawnedPopup.transform.parent = transform;
            }
            spawned = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.tag=="Player"&spawned){
            Destroy(spawnedPopup);
            spawned = false;
        }
    }
}
