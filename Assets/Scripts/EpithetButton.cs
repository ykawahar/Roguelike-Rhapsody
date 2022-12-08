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
        PlayerStats.epithet = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        Debug.Log(PlayerStats.epithet);
        if (PlayerStats.epithet.Equals("Fleet-Footed")) {
            PlayerStats.moveSpeed *= 1.2f;
        }
        if (PlayerStats.epithet.Equals("Musclebound")) {
            PlayerStats.strength *= 1.2f;
        }
        if (PlayerStats.epithet.Equals("Silver-Tongued")) {
            PlayerStats.money += 200;
        }
        if (PlayerStats.epithet.Equals("Megamind")) {
            //maybe something mmagic related idk though
        }
        if (PlayerStats.epithet.Equals("God-Fearing")) {
            //not sure what to do with this one we could just give small buffs to multiple stats on this one
        }
        if (PlayerStats.epithet.Equals("Heroic")) {
            PlayerStats.knockbackStrength *= 1.2f;
        }

    }

    public void buttonTest() {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    //get currently selected button gameobject
    //get text from button
    //save text to playerstats

    public void getClickedButton() {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
