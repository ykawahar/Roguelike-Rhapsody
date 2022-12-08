using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempPanelController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject tempPanel;
    void Start()
    {
        TempPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // timer for panel to disappear 5 seconds
    public void TempPanel()
    {
        tempPanel.SetActive(true);
        StartCoroutine(DeactivateTempPanel());
    }

    IEnumerator DeactivateTempPanel()
    {
        yield return new WaitForSeconds(5);
        tempPanel.SetActive(false);
    }
}
