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
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping && !isComplete)
        {
            StartText();
            isTyping = true;
            pressSpace.SetActive(false);
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isTyping)
        {
            speedUpText = true;
            textSpeed = 0.01f;
        }
        
        if (isComplete)
        {

            pressSpaceText.text = "Select an epithet";
            if (!epithetsGenerated)
            {
                epithetGenerator.GenerateEpithet();
                epithetsGenerated = true;
            }
            pressSpace.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space) && !isTyping)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("NarratorDialogueSystemPlayScene");
                

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
}
