using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

// wow these are amazing changes i just added here super pog!!!!

    public Button playerStatsButton;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private GameObject playerStatsPanel;

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private GameObject storyTellerPanel;

    [SerializeField] private GameObject quitPanel;

    [SerializeField] private GameObject helpPanel;

    [SerializeField] private bool isPaused;

    [SerializeField] private Text narratorLog;

    private bool panelActive = false;
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
        playerStatsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        storyTellerPanel.SetActive(false);
        quitPanel.SetActive(false);
        helpPanel.SetActive(false);
        panelActive = false;
    }

    public void playerStatsOnClick() {
        if (panelActive == false) {
            playerStatsPanel.GetComponentInChildren<Text>().text = "Epithet: " + PlayerStats.epithet;
            playerStatsPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void settingsOnClick() {
        if (panelActive == false) {
            settingsPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void storyOnClick() {
        if (panelActive == false) {
            storyTellerPanel.SetActive(true);
            panelActive = true;
            narratorLog.text = StaticNarratorLog.narratorLog;
        }
    }

    public void controlsOnClick() {
        if (panelActive == false) {
            helpPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void quitOnClick() {
        if (panelActive == false) {
            quitPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void closeStoryOnClick(){
        storyTellerPanel.SetActive(false);
        panelActive = false;
    }

    public void closePlayerStatsOnClick(){
        playerStatsPanel.SetActive(false);
        panelActive = false;
    }

    public void closeSettingsOnClick(){
        settingsPanel.SetActive(false);
        panelActive = false;
    }

    public void closeHelpOnClick(){
        helpPanel.SetActive(false);
        panelActive = false;
    }

    public void closeQuitOnClick(){
        quitPanel.SetActive(false);
        panelActive = false;
    }

    public void quitGameOnClick(){
        Application.Quit();
    }

    public void quitToTitleOnClick(){
        SceneManager.LoadScene("TitleScreen");
    }

    void Start() {
    }
}
