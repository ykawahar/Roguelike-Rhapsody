using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogController : MonoBehaviour
{
    private static TextLogController instance;
    public GameObject textLogPrefab;
    public RectTransform textLogParent;
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

        newTextLog.transform.GetChild(0).GetComponent<Text>().text = text;

    }
}