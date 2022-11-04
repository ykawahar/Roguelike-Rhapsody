//Based on code by Epitome

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField]private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0,19,-24);

    [Header("Bounds")]
    [SerializeField] private bool enableBounds = true;
    [SerializeField] private float bounds = 3f;

    [Header("Smooth")]
    private bool enableSmooth = true;
    private float smoothSpeed = 10.0f;
    private Vector3 desiredPosition;
    [SerializeField] private Vector3 clampPosition;
    [SerializeField] private Vector3 minClampValue;
    [SerializeField] private Vector3 maxClampValue;

    private void Start(){
        target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate(){
        //LateUpdate updates after Update functions
        // Camera will update after player has moved
        
        desiredPosition = target.position + offset;

        if (enableBounds){
            //check if in bounds
            float deltaX = target.position.x - transform.position.x;
            if(Mathf.Abs(deltaX) > bounds){
                if(deltaX > 0){ //right side
                    desiredPosition.x = target.position.x - bounds;
                } else {
                    desiredPosition.x = target.position.x + bounds;
                }
            } else {
                desiredPosition.x = target.position.x - deltaX;
            }
        }

        clampPosition = new Vector3(
            Mathf.Clamp(desiredPosition.x, minClampValue.x, maxClampValue.x), 
            Mathf.Clamp(desiredPosition.y, minClampValue.y, maxClampValue.y), 
            Mathf.Clamp(desiredPosition.z, minClampValue.z, maxClampValue.z));

        //Smoothing
        if(enableSmooth){
            transform.position = Vector3.Lerp(transform.position, clampPosition, Time.deltaTime * smoothSpeed);   
        } else {
            transform.position = desiredPosition;
        }
    }


}
