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

    // Start is called before the first frame update
    void Start()
    {
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/swords"));
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/tribute"));
        this.gameObject.GetComponent<Image>().sprite = getRandomLevel(); //see random level notes
        this.gameObject.GetComponent<Button>().onClick.AddListener(loadCurrentLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //use when clicked
    void loadCurrentLevel() {
        Debug.Log("Load level has been called");
        if (currentLevelType == "Tribute") {
            Debug.Log("I think this is a tribute node" + " " + currentLevelType);
            SceneManager.LoadScene("TributeArea");
        } else if (currentLevelType == "Combat") {
            Debug.Log("I think this is a combat node"+ " " + currentLevelType);
            // SceneManager.LoadScene("SampleScene"); //not loaded New TestSene error
            SceneManager.LoadScene("New TestSene");
        } else if (currentLevelType == "Boss") {
            // SceneManager.LoadScene("")
        } else {
            //do nothing
        }
    }
    public Sprite getRandomLevel() { //need to add weights to make the combat more common (60/40 or 70/30)
        Sprite randomLevel = LevelTypes[Random.Range(0, LevelTypes.Count)];
        if (randomLevel.name == "swords") {
            currentLevelType = "Combat";
        } else if (randomLevel.name == "tribute") {
            currentLevelType = "Tribute";
        } else {
            currentLevelType = "";
        }
        // Debug.Log(randomLevel.name); //testing purposes
        return randomLevel;
    }
}
