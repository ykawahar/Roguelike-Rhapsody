using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    Transform parent;
    private float initialY;
    void Start()
    {
        parent = transform.parent;
        initialY = transform.position.y;
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }
}
