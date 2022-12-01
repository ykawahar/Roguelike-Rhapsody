using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMapManager : MonoBehaviour
{
    public static MainMapManager Instance; //creating a single instance with static values
    public GameObject currentLevel;

    public GameObject[] mapNodes;
    public LinkedList<Sprite> currentMap = new LinkedList<Sprite>();

    void Start()
    {
        mapNodes = GameObject.FindGameObjectsWithTag("MapNode");
        foreach (GameObject mapNode in mapNodes) {
            // if (mapNode.GetComponent<Image>().sprite.name == "swords") {
            //     currentMap.AddLast(Resources.Load<Sprite>("Sprites/Icons/swords"));
            // } else if (mapNode.GetComponent<Image>().sprite.name == "tribute") {
            //     currentMap.AddLast(Resources.Load<Sprite>("Sprites/Icons/tribute"));
            // } else {
            //     //do nothing
            // }
        }
        // Debug.Log(currentMap.First);
    }

    private void Awake()
    {
    // destroys duplicate instances
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    }
}