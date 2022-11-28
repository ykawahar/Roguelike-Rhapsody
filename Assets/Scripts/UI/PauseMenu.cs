using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{



    public Button playerStatsButton;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private GameObject playerStatsPanel;

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private GameObject storyTellerPanel;

    [SerializeField] private GameObject quitPanel;

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
        playerStatsPanel.GetComponentInChildren<Text>().text = "Epithet: " + PlayerStats.epithet;
        playerStatsPanel.SetActive(true);
    }

    public void settingsOnClick() {
        settingsPanel.SetActive(true);
    }

    public void storyOnClick() {
        storyTellerPanel.SetActive(true);
    }

    public void quitOnClick() {
        quitPanel.SetActive(true);
    }

    public void closeStoryOnClick(){
        storyTellerPanel.SetActive(false);
    }

    public void closePlayerStatsOnClick(){
        playerStatsPanel.SetActive(false);
    }

    public void closeSettingsOnClick(){
        settingsPanel.SetActive(false);
    }

    public void closeQuitOnClick(){
        quitPanel.SetActive(false);
    }

    public void quitGameOnClick(){
        Application.Quit();
    }

    public void quitToTitleOnClick(){
        SceneManager.LoadScene("TitleScreen");
    }

    void Start() {
        canvasObjects = pauseMenuUI.GetComponents<Canvas>();
        Debug.Log(canvasObjects[0].name);
    }
}
