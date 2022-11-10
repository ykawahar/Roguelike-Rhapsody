using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogController : MonoBehaviour
{
    private static TextLogController instance;
    public GameObject textLogPrefab;
    public RectTransform textLogParent;

    public float textDelay;
    public static TextLogController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TextLogController>();
            }
            return instance;
        }
    }

    public void AddTextLog(string text)
    {
        GameObject newTextLog = Instantiate(textLogPrefab, textLogPrefab.transform.position, Quaternion.identity);
        newTextLog.transform.SetParent(textLogParent);
        newTextLog.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        // newTextLog.transform.GetChild(0).GetComponent<Text>().text = text;
        newTextLog.GetComponent<Text>().text = text;
    }

    public void typeTextByBlock(string text) 
    {
        GameObject newTextLog = Instantiate(textLogPrefab, textLogPrefab.transform.position, Quaternion.identity);
        newTextLog.transform.SetParent(textLogParent);
        newTextLog.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        string[] textBlocks = text.Split('|');
        foreach (string block in textBlocks)
        {
            newTextLog.GetComponent<Text>().text += block;
            WaitForSeconds wait = new WaitForSeconds(textDelay);
        }
    }

    public void startBlockText(string text)
    {
        StartCoroutine(typeBlock(text));
    }

    IEnumerator typeBlock(string block)
    {
        GameObject newTextLog = Instantiate(textLogPrefab, textLogPrefab.transform.position, Quaternion.identity);
        newTextLog.transform.SetParent(textLogParent);
        newTextLog.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        string[] textBlocks = block.Split('|');
        foreach (string blocks in textBlocks)
        {
            newTextLog.GetComponent<Text>().text += blocks;
            WaitForSeconds wait = new WaitForSeconds(textDelay);
            yield return wait;
        }
    }
}