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
public GameObject currentLevel;
public GameObject[] mapNodes;
public LinkedList<Sprite> currentMap = new LinkedList<Sprite>();

    //map generator script
    //matrix array holding the map to turn certain positions on and off
    //event call for when you come back to map script


    //radically change this script to be a dont destroy on load or maybe a minimize option??

    // Start is called before the first frame update
    void Start()
    {
        mapNodes = GameObject.FindGameObjectsWithTag("MapNode");
        foreach (GameObject mapNode in mapNodes) {
            if (mapNode.GetComponent<Image>().sprite.name == "swords") {
                currentMap.AddLast(Resources.Load<Sprite>("Sprites/Icons/swords"));
            } else if (mapNode.GetComponent<Image>().sprite.name == "tribute") {
                currentMap.AddLast(Resources.Load<Sprite>("Sprites/Icons/tribute"));
            } else {
                //do nothing
            }
        }
        // Debug.Log(currentMap.First);
    }

    // Update is called once per frame
    void Update()
    {

    }
}