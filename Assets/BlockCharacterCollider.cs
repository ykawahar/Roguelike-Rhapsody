using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollider : MonoBehaviour
{
    [SerializeField] private Collider characterCollider;
    [SerializeField] private Collider blocker;
        
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(characterCollider, blocker, true);
    }
}
