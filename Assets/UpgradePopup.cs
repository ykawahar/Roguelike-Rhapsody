using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePopup : MonoBehaviour
{
    public GameObject popupL;
    public GameObject popupR;
    private GameObject spawnedPopup;
    public bool right = true;
    private bool spawned = false;

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
            } else {
                spawnedPopup = Instantiate(popupL);
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
