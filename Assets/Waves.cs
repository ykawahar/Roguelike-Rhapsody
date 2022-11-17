using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float maxZ = 10f;
    public float minZ = 17.5f;
    private bool ebb;
    public float speed = 2f;
    public float duration = 2f;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = new Vector3(transform.position.x, transform.position.y, minZ);
        Vector3 endPos = new Vector3(transform.position.x, transform.position.y, maxZ);
        // if (!ebb){
        //     Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, maxZ);
        //     transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //     Vector3 currentPos = transform.position;
        //     if (currentPos.z <= targetPos.z){
        //         ebb = !ebb;
        //     }
        // }
        // if (ebb){
        //     Vector3 targetPos = new Vector3(transform.position.x, transform.position.y, minZ);
        //     transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        //     Vector3 currentPos = transform.position;
        //     if (currentPos.z >= targetPos.z){
        //         ebb = !ebb;
        //     }
        // }

        var factor = Mathf.PingPong(Time.time / (2f * duration), 1f);
    // This adds additional ease-in and -out near to 0 and 1
        factor = Mathf.SmoothStep(0, 1, factor);
    // This interpolates between the given positions according to the given factor
        transform.position = Vector3.Lerp(startPos, endPos, factor);

    }
}
