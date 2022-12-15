using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpUpgrade : MonoBehaviour
{
    private bool used = false;
    private TextManager textLog;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("JUMP UPGRADE CREATED");
        this.gameObject.GetComponent<Button>().onClick.AddListener(addJump);
        textLog = GameObject.Find("TextLogManager").GetComponent<TextManager>();
    }

    void addJump() {
        Debug.Log("CLICKED jump UPGRADE");
        PlayerStats.maxJumpCount = PlayerStats.maxJumpCount+1;
    }

    void OnTriggerEnter(Collider other){
        if (other.tag=="Player" & !used){
            PlayerStats.maxJumpCount = PlayerStats.maxJumpCount+1;
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
