///Based on code by Epitome

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatEmUpMovement : MonoBehaviour
{
    [Header ("Logic")]
    private CharacterController controller;
    private Vector3 slopeNormal;
    private bool grounded;
    private float verticalVelocity;

    [Header ("movement config")]
    [SerializeField] private float speedX = 5.0f;
    [SerializeField] private float speedZ = 5.0f;
    [SerializeField] private float gravity = 0.25f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float terminalVelocity = 5.0f;

    [Header ("Ground check raycast")]
    [SerializeField] private float extremitiesOffset = 0.05f;
    [SerializeField] private float innerVerticalOffset = 0.25f;
    [SerializeField] private float distanceGrounded = 0.15f;
    [SerializeField] private float slopeThreshold = 0.55f;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        if (controller == null){
            Debug.Log("No cc");
        }   
    }

    private void Update() {
        ///Store what key is pressed.
        Vector3 inputVector = PoolInput();

        //Multiply input with speed
        Vector3 moveVector = new Vector3(inputVector.x * speedX, 0, inputVector.y*speedZ);
        
        //Store in variable so it is not called more than once per frame
        grounded = Grounded();

        controller.Move(moveVector *Time.deltaTime);
    }

    private Vector3 PoolInput(){
        Vector3 r = Vector3.zero;

        r.x = Input.GetAxisRaw("Horizontal");
        r.y = Input.GetAxisRaw("Vertical");

        return r.normalized;
    }

    public bool Grounded(){
        return false;
    }





}
