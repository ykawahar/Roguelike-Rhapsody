using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float travelDistance = 4f;
    public float speed = 0.5f;
    public float duration = 2f;
    public float pos;

    [Header ("Debug")]
    public float min =100;
    public float max = -20;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        pos = +transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //var factor = Mathf.PingPong(Time.time / (2f * duration), 1f);
    // This adds additional ease-in and -out near to 0 and 1
        //factor = Mathf.SmoothStep(0, 1, factor);
    // This interpolates between the given positions according to the given factor
       // transform.position = Vector3.Lerp(startPos, endPos, factor);

       float newZ = pos + travelDistance*Mathf.Sin(Time.time*speed); // starting point + radius * sin(time * speed)
       
       //Debug
        // if (newZ<min){
        //     min = newZ;
        // }
        // if (newZ>max){
        //     max=newZ;
        // }
       
       transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
       

    }
}
