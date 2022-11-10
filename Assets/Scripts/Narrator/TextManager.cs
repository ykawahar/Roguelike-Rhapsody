using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{

    public Queue<string> messageQueue;
    private string prologue = PlayerStats.epithet + " <name>| washed up on| sandy shore.| His calling| left him now| shipless and| stranded here.| Stirring from| slumber and| wiping the| sand away.| Queen of the| Gods Above| Amani| called to him.| To atone| for your sins| hear my voice,| heed my call.| The river| called Mercy| is poisoned | she bleeds black!";
    public ArrayList slimeSubjectList;
    public ArrayList cultistSubjectList;
    public ArrayList cultistDescriptorList;
    public ArrayList cultistDescriptorList2;
    public ArrayList slimeDescriptorList;
    public ArrayList slimeDescriptorList2;
    public ArrayList slimeActionList;


    // Start is called before the first frame update
    void Start()
    {

        messageQueue = new Queue<string>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        slimeSubjectList = new ArrayList();
        slimeDescriptorList = new ArrayList();
        slimeDescriptorList2 = new ArrayList();
        slimeActionList = new ArrayList();

        cultistSubjectList = new ArrayList();
        cultistDescriptorList = new ArrayList();
        cultistDescriptorList2 = new ArrayList();

        slimeSubjectList.Add("Beasts of slime|");
        slimeSubjectList.Add("Beasts of ooze|");
        slimeSubjectList.Add("Beasts of sludge|");

        cultistSubjectList.Add("Sly cultists|");
        cultistSubjectList.Add("Dark cultists|");
        cultistSubjectList.Add("Devout men|");

        slimeDescriptorList.Add("of blue hue|");
        slimeDescriptorList.Add("of green hue|");
        slimeDescriptorList.Add("of red hue|");

        cultistDescriptorList.Add("in dark robes|");
        cultistDescriptorList.Add("in crimson|");
        cultistDescriptorList.Add("of old gods|");

        slimeDescriptorList2.Add("and strange smell|");
        slimeDescriptorList2.Add("and foul smell|");
        slimeDescriptorList2.Add("and strange face|");

        cultistDescriptorList2.Add("and strange masks|");
        cultistDescriptorList2.Add("and in chrome|");

        slimeActionList.Add("came to be!");
        slimeActionList.Add("had appeared!");

        if(sceneName == "Prologue") {
            StartPrologue();
        }
    }

    // Update is called once per frame
    void Update()
    {

        CheckNewMessages();
    }

    void CheckNewMessages(){
        
        if (messageQueue.Count > 0){
            TextLogController.Instance.startBlockText(messageQueue.Dequeue());
        }
    }

    public void StartPrologue(){
        messageQueue.Enqueue(prologue);
    }



}