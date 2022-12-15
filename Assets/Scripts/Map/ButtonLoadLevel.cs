using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonLoadLevel : MonoBehaviour
{
public List<Sprite> LevelTypes;
public string currentLevelType;
private Sprite assignedSprite;
private TextManager textLog;
    // Start is called before the first frame update
    void Start()
    {
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/swords"));
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/tribute"));
        this.gameObject.GetComponent<Image>().sprite = getRandomLevel(); //see random level notes
        this.gameObject.GetComponent<Button>().onClick.AddListener(sendText);
        textLog = GameObject.Find("TextLogManager").GetComponent<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //use when clicked
    void loadCurrentLevel() {
        Debug.Log("Load level has been called");
        if (currentLevelType == "Tribute") {
            // Debug.Log("I think this is a tribute node" + " " + currentLevelType);
            SceneManager.LoadScene("TributeArea");
            MainMapManager.Instance.mapCanvas.SetActive(false);
        } else if (currentLevelType == "Combat") {
            // Debug.Log("I think this is a combat node"+ " " + currentLevelType);
            SceneManager.LoadScene("CombatScene");
            MainMapManager.Instance.mapCanvas.SetActive(false);
        } else if (currentLevelType == "Boss") {
            SceneManager.LoadScene("BossScene");
            MainMapManager.Instance.mapCanvas.SetActive(false);
        } else {
            //do nothing
        }
    }

    void sendText() {
        textLog.nodeTraversalLog();
        StartCoroutine(WaitAndSwitchScene(2f));
    }
    public Sprite getRandomLevel() { //need to add weights to make the combat more common (60/40 or 70/30)
        assignedSprite = LevelTypes[Random.Range(0, LevelTypes.Count)];
        if (assignedSprite.name == "swords") {
            currentLevelType = "Combat";
        } else if (assignedSprite.name == "tribute") {
            currentLevelType = "Tribute";
        } else {
            currentLevelType = "";
        }
        // Debug.Log(randomLevel.name); //testing purposes
        return assignedSprite;
    }

    IEnumerator WaitAndSwitchScene(float delay) {
        yield return new WaitForSeconds(delay);
        loadCurrentLevel();
    }
}
