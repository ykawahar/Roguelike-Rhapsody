using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpUpgrade : MonoBehaviour
{
    private bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("JUMP UPGRADE CREATED");
        this.gameObject.GetComponent<Button>().onClick.AddListener(addJump);
    }

    void addJump() {
        Debug.Log("CLICKED jump UPGRADE");
        PlayerStats.maxJumpCount = PlayerStats.maxJumpCount+1;
    }

    void OnTriggerEnter(Collider other){
        if (other.tag=="Player" & !used){
            PlayerStats.maxJumpCount = PlayerStats.maxJumpCount+1;
            used = true;
        }
        transform.parent.gameObject.GetComponent<UpgradePopup>().gate.SetActive(true);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
