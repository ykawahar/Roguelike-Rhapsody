using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgrade : MonoBehaviour
{

    private bool used = false;
    private TextManager textLog;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("speed UPGRADE CREATED");
        this.gameObject.GetComponent<Button>().onClick.AddListener(addSpeed);
        textLog = GameObject.Find("TextLogManager").GetComponent<TextManager>();
    }

    void addSpeed() {
        Debug.Log("CLICKED SPEED UPGRADE!!!!!!!!!!!!!!!!!");
        PlayerStats.moveSpeed = PlayerStats.moveSpeed + 1f;
    }

    void OnTriggerEnter(Collider other){
        if (other.tag=="Player" & !used){
            PlayerStats.moveSpeed = PlayerStats.moveSpeed + 2f;
            used = true;

            if (Random.Range(0,2) == 1){
                textLog.messageQueue.Enqueue(textLog.godsAboveTribute);
            }
            else {
                textLog.messageQueue.Enqueue(textLog.godsBelowTribute);
            }
            
        }
        transform.parent.gameObject.GetComponent<UpgradePopup>().gate.SetActive(true);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
