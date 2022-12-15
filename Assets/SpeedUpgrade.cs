using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUpgrade : MonoBehaviour
{

    private bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("speed UPGRADE CREATED");
        this.gameObject.GetComponent<Button>().onClick.AddListener(addSpeed);
    }

    void addSpeed() {
        Debug.Log("CLICKED SPEED UPGRADE!!!!!!!!!!!!!!!!!");
        PlayerStats.moveSpeed = PlayerStats.moveSpeed + 1f;
    }

    void OnTriggerEnter(Collider other){
        if (other.tag=="Player" & !used){
            PlayerStats.moveSpeed = PlayerStats.moveSpeed + 2f;
            used = true;
        }
        transform.parent.gameObject.GetComponent<UpgradePopup>().gate.SetActive(true);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
