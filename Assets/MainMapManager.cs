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

    public List<GameObject> mapNodes = new List<GameObject>();
    public LinkedList<Sprite> currentMap = new LinkedList<Sprite>();
    public GameObject mapCanvas;

    void Start()
    {
        foreach (GameObject mapNode in GameObject.FindGameObjectsWithTag("MapNode")) {
            mapNodes.Add(mapNode);
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