using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TributeStatue : MonoBehaviour{

    public Sprite AboveStatue;
    public Sprite BelowStatue;

    public int type;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize(){


        if (type == 1){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = AboveStatue;
        } else {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = BelowStatue;
        }
        Debug.Log("My type is " + type);
    }
}
