using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMapManager : MonoBehaviour
{
    public static MainMapManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}