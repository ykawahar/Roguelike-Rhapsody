using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    private Canvas[] canvasObjects;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused){
            ActivateMenu();
        }
        else {
            DeactivateMenu();
        }
    }

    private void ActivateMenu()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    private void DeactivateMenu()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    void playerStatsOnClick(){
    }

    void Start() {
        canvasObjects = pauseMenuUI.GetComponents<Canvas>();
        Debug.Log(canvasObjects[0].name);
    }
}
