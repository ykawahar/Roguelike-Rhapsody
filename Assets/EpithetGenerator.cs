using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpithetGenerator : MonoBehaviour
{
    // Start is called before the first frame upda
    
    public GameObject buttonPrefab;
    private ArrayList epithets;
    public RectTransform buttonParent;
    

    void Start()
    {
        epithets = new ArrayList();
        epithets.Add("Fleet-Footed");;
        epithets.Add("Silver-Tongued");
        epithets.Add("Megamind");
        epithets.Add("Musclebound");
        epithets.Add("God-Fearing");
        epithets.Add("Heroic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateEpithet() {
        PlayerStats.epithet = "";
        // loops through epithets and creates 3 random buttons with epithets on them no repeats
        for (int i = 0; i < 3; i++) {
            int rand = Random.Range(0, epithets.Count);
            GameObject button = Instantiate(buttonPrefab, buttonParent);
            button.GetComponentInChildren<Text>().text = epithets[rand].ToString();
            epithets.RemoveAt(rand);
        }
    }
    // saves text from selected button
    public void SaveEpithet() {
        
    }

}
