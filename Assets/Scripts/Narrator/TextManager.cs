using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{

    public Queue<string> messageQueue;
    private string prologue = PlayerStats.epithet + " <name>| washed up on| sandy shore.| His calling| left him now| shipless and| stranded here.| Stirring from| slumber and| wiping the| sand away.| Queen of the| Gods Above| Amani| called to him.| To atone| for your sins| hear my voice,| heed my call.| The river| called Mercy| is poisoned | she bleeds black!";

    private string tributeScreen = "At a shrine| to the gods| one above| one below|" + PlayerStats.epithet + "| <name>| felt the call| of the flame. Would he choose| to add weight| to the scale| of above? Or weigh down| the balance| to the gods| underneats?";

    private string godsAboveTribute = "The call of| the higher| spoke to him| through the flame. He offered| his tribute| to be raised| up in smoke.";
    private string godsBelowTribute = "Through flame tongues| the call of| gods below| compelled him. To offer| his tribute| to be raised| up in smoke.";
    public ArrayList slimeSubjectList;
    public ArrayList cultistSubjectList;
    public ArrayList cultistDescriptorList;
    public ArrayList cultistDescriptorList2;
    public ArrayList cultistActionList;
    public ArrayList slimeDescriptorList;
    public ArrayList slimeDescriptorList2;
    public ArrayList slimeActionList;
    public ArrayList batSubjectList;
    public ArrayList batDescriptorList;
    public ArrayList batDescriptorList2;
    public ArrayList batActionList;
    public ArrayList waveClear;
    public ArrayList waveClearAdverb;
    public ArrayList waveClearVerb;
    public ArrayList nodeTraversal;
    public ArrayList nodeTraversal2;
    public ArrayList nodeTraversal3;



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
        cultistActionList = new ArrayList();

        batSubjectList = new ArrayList();
        batDescriptorList = new ArrayList();
        batDescriptorList2 = new ArrayList();
        batActionList = new ArrayList();

        waveClear = new ArrayList();
        waveClearAdverb = new ArrayList();
        waveClearVerb = new ArrayList();

        nodeTraversal = new ArrayList();
        nodeTraversal2 = new ArrayList();
        nodeTraversal3 = new ArrayList();


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

        cultistActionList.Add("soon attacked!");
        cultistActionList.Add("had attacked!");

        slimeDescriptorList2.Add("and strange smell|");
        slimeDescriptorList2.Add("and foul smell|");
        slimeDescriptorList2.Add("and strange face|");

        cultistDescriptorList2.Add("and strange masks|");
        cultistDescriptorList2.Add("and in chrome|");

        slimeActionList.Add("came to be!");
        slimeActionList.Add("had appeared!");

        batSubjectList.Add("Flighted beasts|");
        batSubjectList.Add("Flying beasts|");
        batSubjectList.Add("Swooping beasts|");

        batDescriptorList.Add("leather-winged|");
        batDescriptorList.Add("of pleat-wing|");
        batDescriptorList.Add("unfeathered|");

        batDescriptorList2.Add("with lone eye|");
        batDescriptorList2.Add("with sole eye|");
        batDescriptorList2.Add("with one eye|");

        batActionList.Add("came in droves!");
        batActionList.Add("had attacked!");

        waveClear.Add("Through effort|");
        waveClear.Add("With great might|");

        waveClearAdverb.Add("handily|");
        waveClearAdverb.Add("easily|");
        waveClearAdverb.Add("blessed by the gods|");

        waveClearVerb.Add("slew the beasts!");
        waveClearVerb.Add("vanquished all!");
        waveClearVerb.Add("bonk-bonk-bonked!");

        nodeTraversal.Add("In fair wind|");
        nodeTraversal.Add("In foul wind|");
        nodeTraversal.Add("Through kingdom|");

        nodeTraversal2.Add("with great speed|");
        nodeTraversal2.Add("making way|");
        nodeTraversal2.Add("and terrain|");

        nodeTraversal3.Add("traveled far.");
        nodeTraversal3.Add("journeyed on.");
        nodeTraversal3.Add("had trekked forth.");

        if(sceneName == "Prologue") {
            StartCoroutine("StartPrologue");
        }
        if(sceneName == "TributeArea") {
            StartCoroutine("StartTribute");
        }
    }

    // Update is called once per frame
    void Update()
    {

        CheckNewMessages();
    }

    void CheckNewMessages(){
        
        if (messageQueue.Count > 0){
            StaticNarratorLog.narratorLog += messageQueue.Peek() + " \n";
            TextLogController.Instance.startBlockText(messageQueue.Dequeue());
        }
    }

    void StartPrologue(){
        messageQueue.Enqueue(prologue);
    }

    void StartTribute(){
        messageQueue.Enqueue(tributeScreen);
    }

    public void nodeTraversalLog() {
        messageQueue.Enqueue(nodeTraversal[Random.Range(0, nodeTraversal.Count)] + " " + nodeTraversal2[Random.Range(0, nodeTraversal2.Count)] + " " + nodeTraversal3[Random.Range(0, nodeTraversal3.Count)]);
    }

    public void generateCultistText() {
        // generates cultist text
        messageQueue.Enqueue(cultistSubjectList[Random.Range(0, cultistSubjectList.Count)] + " " + cultistDescriptorList[Random.Range(0, cultistDescriptorList.Count)] + " " + cultistDescriptorList2[Random.Range(0, cultistDescriptorList2.Count)] + " " + cultistActionList[Random.Range(0, cultistActionList.Count)]);
    }

    public void generateSlimeText() {
        // generates slime text
        messageQueue.Enqueue(slimeSubjectList[Random.Range(0, slimeSubjectList.Count)] + " " + slimeDescriptorList[Random.Range(0, slimeDescriptorList.Count)] + " " + slimeDescriptorList2[Random.Range(0, slimeDescriptorList2.Count)] + " " + slimeActionList[Random.Range(0, slimeActionList.Count)]);
    }

    public void generateWaveClearText() {
        // generates wave clear text
        messageQueue.Enqueue(waveClear[Random.Range(0, waveClear.Count)] + " " + waveClearAdverb[Random.Range(0, waveClearAdverb.Count)] + " " + waveClearVerb[Random.Range(0, waveClearVerb.Count)]);
    }

    //wait 10 seconds before switchin scenes
    // IEnumerator WaitAndSwitchScene(){
    //     yield return new WaitForSeconds(10);
    //     UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    // }



}