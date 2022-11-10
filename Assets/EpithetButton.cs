using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EpithetButton : MonoBehaviour
{
    public Button epithetButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveEpithet() {
        PlayerStats.epithet = epithetButton.GetComponentInChildren<Text>().text;
        Debug.Log(PlayerStats.epithet);
    }

    public void buttonTest() {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
