using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonLoadLevel : MonoBehaviour
{
public List<Sprite> LevelTypes;

    // Start is called before the first frame update
    void Start()
    {
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/swords"));
        LevelTypes.Add(Resources.Load<Sprite>("Sprites/Icons/tribute"));
        this.gameObject.GetComponent<Image>().sprite = getRandomLevel(); //add weights
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadCurrentLevel(string levelName) {
        if (levelName == "Tribute") {
            SceneManager.LoadScene("TributeArea");
        } else if (levelName == "Battle") {
            SceneManager.LoadScene("SampleScene");
        } else if (levelName == "Boss") {
            // SceneManager.LoadScene("")
        } else {
            //do nothing
        }
    }
    public Sprite getRandomLevel() {
        Sprite randomLevel = LevelTypes[Random.Range(0, LevelTypes.Count)];
        Debug.Log(randomLevel.name);
        return randomLevel;
    }
}
