using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialHealthBar : MonoBehaviour
{
    public Image hpBar;
    [SerializeField] GameObject target;

    private float currentHP;
    private float maxHP = 100;

    private void Start() {

    }

    void Update()
    {
        float hpPercent = currentHP/maxHP;
        //Range of fill is 0 to 1
        hpBar.fillAmount = hpPercent;


    }
}
