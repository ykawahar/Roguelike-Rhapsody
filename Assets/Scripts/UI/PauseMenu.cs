using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{



    public Button playerStatsButton;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private GameObject playerStatsPanel;

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

    public void playerStatsOnClick() {
        Debug.Log("Player Stats Button Clicked");
        playerStatsPanel.GetComponentInChildren<Text>().text = "Epithet:" + PlayerStats.epithet;
        playerStatsPanel.SetActive(true);
    }

    public void closePlayerStatsOnClick(){
        playerStatsPanel.SetActive(false);
    }

    void Start() {
        canvasObjects = pauseMenuUI.GetComponents<Canvas>();
        Debug.Log(canvasObjects[0].name);
    }
}
