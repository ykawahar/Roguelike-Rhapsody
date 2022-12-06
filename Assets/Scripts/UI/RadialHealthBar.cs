using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialHealthBar : MonoBehaviour
{
    public Image hpBar;
    [SerializeField] GameObject target;
    private Image img;
    // [SerializeField] float currentHP;
    // private float maxHP;
    private float hpPercent;
    private Color startColor;

    [SerializeField] private Gradient gradient;

    private void Start() {
        // if (target==null){
        //     target = GameObject.FindGameObjectWithTag("Player");
        // }
        // currentHP = target.GetComponent<PlayerController>().currentHP;
        // maxHP = target.GetComponent<PlayerController>().GetMaxHP();

        

        img = GetComponent<Image>();
        startColor = img.color;
    }

    void Update()
    {
        // currentHP = target.GetComponent<PlayerController>().currentHP;
        hpPercent = PlayerStats.currentHealth/PlayerStats.maxHealth;
        //Range of fill is 0 to 1
        hpBar.fillAmount = hpPercent;

        UpdateColor();
    }

    void UpdateColor(){
        img.color = gradient.Evaluate(hpPercent);

        // img.color = Color.Lerp(startColor, Color.red, 1-hpPercent);
    }
}
