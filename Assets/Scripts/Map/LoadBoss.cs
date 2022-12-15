using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class LoadBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(loadCurrentLevel);
    }

    void loadCurrentLevel() {
        Debug.Log("Load level has been called");
        SceneManager.LoadScene("BossScene");
        MainMapManager.Instance.mapCanvas.SetActive(false);
    }
}