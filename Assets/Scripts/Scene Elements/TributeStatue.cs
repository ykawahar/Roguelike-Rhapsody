using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TributeStatue : MonoBehaviour{

    public Sprite AboveStatue;
    public Sprite BelowStatue;
    public GameObject brazier;

    public int type;

    public int offset = 1;
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
        // Debug.Log("My type is " + type);
        Debug.Log(offset);
        Debug.Log(transform.position.x+offset);
        Instantiate(brazier, new Vector3(transform.position.x+offset, transform.position.y-4f, transform.position.z-7f), Quaternion.Euler(30,0,0));
    }
}
