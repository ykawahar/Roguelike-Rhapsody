using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCut : MonoBehaviour
{
    // Start is called before the first frame update

    public string dialogueLines;
    public float textSpeed;
    private Text dialogueText;
    private Text pressSpaceText;
    private GameObject pressSpace;
    private EpithetGenerator epithetGenerator;

    private bool isTyping = false;

    private bool speedUpText = false;
    private bool isComplete = false;
    private bool epithetsGenerated = false;

    void Start()
    {
        dialogueText = GetComponent<Text>();
        pressSpace = GameObject.Find("PressSpaceText");
        pressSpaceText = GameObject.Find("PressSpaceText").GetComponent<Text>();
        epithetGenerator = GameObject.Find("DialogueText").GetComponent<EpithetGenerator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0)) && !isTyping && !isComplete)
        {
            StartText();
            isTyping = true;
            pressSpace.SetActive(false);
            
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonUp(0)) && isTyping)
        {
            speedUpText = true;
            textSpeed = 0;
        }
        
        if (isComplete)
        {

            if (!epithetsGenerated)
            {
                pressSpace.SetActive(true);
                pressSpaceText.text = "Select an epithet";
                epithetGenerator.GenerateEpithet();
                epithetsGenerated = true;
            }
            if (PlayerStats.epithet != "")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Prologue");
            }
        }
    }


    void StartText() {
        StartCoroutine(WriteSentence());
    }

        IEnumerator WriteSentence() {
        foreach(char Character in dialogueLines.ToCharArray()) {
            dialogueText.text += Character;
            yield return new WaitForSeconds(textSpeed);
        }
        isComplete = true;
        isTyping = false;
    }

        void startBlockText()
    {
        StartCoroutine(typeBlock());
    }

    IEnumerator typeBlock()
    {
        string[] textBlocks = dialogueLines.Split('|');
        foreach (string blocks in textBlocks)
        {
            dialogueText.text += blocks;
            yield return new WaitForSeconds(textSpeed);
        }
        isComplete = true;
        isTyping = false;
    }
}
