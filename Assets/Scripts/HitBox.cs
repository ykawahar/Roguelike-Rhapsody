using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public float damage = 10;
    public Vector3 knockback = new Vector3(0,5,15);

    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        HurtBox h = other.GetComponent<HurtBox>();

        if (h!=null){
            h.health-= damage;
        }
    }
}
