using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
public GameObject GameCourseIcons;
public GameObject StartNode;
public GameObject EndNode;
public int ColumnLength;
public int RowHeight;
public GameObject[,] gamePath;
public GameObject currentLevel;
public List<GameObject> LevelColumns;
public Sprite battle;
public Sprite tribute;
// public Sprite[] LevelTypes = new Sprite[] {battle, tribute};


    //map generator script
    //matrix array holding the map to turn certain positions on and off
    //event call for when you come back to map script


    // Start is called before the first frame update
    void Start()
    {
        ColumnLength = 4;
        RowHeight = 3;
        mapInitialGenerate();
    }

    void mapInitialGenerate() {
        // gamePath = new GameObject[ColumnLength,RowHeight];
        // for (int i = 0; i < ColumnLength; i++)
        // {
        //     for (int j = 0; j < RowHeight; j++)
        //     {
        //         gamePath[i,j] = (GameObject)Instantiate(TestMapNode, new Vector3(i, j, 0), Quaternion.identity);
        //     }
        // }
        //button.GetComponent<Image>().sprite = Image1;
        //obj = currentObjContainer.transform.GetChild(0);
        //Cubes[0].name
        foreach (GameObject column in LevelColumns) {
                // string selectedLevel = getRandomLevel();
                column.GetComponent<Image>().sprite = battle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (GameObject column in LevelColumns) {
        //     Button btn = column.GetComponent<Button>();
		//     btn.onClick.AddListener(SceneManager.LoadScene("SampleScene"));
        // }
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

    // public string getRandomLevel() {
    //     // return LevelTypes[Random.Range(0, LevelTypes.Length)];
    // }
}
