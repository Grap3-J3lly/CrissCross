using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //------------------------------------------------------
    //                    VARIABLES
    //------------------------------------------------------

    [SerializeField] GameObject pToken;
    [SerializeField] bool startCamRotate;
    [SerializeField] bool rotationDirection;
    [SerializeField] float rotationSpeed;
    Vector3 currentPos;
    Vector3 parentAngle;
    float xPos;
    float zPos;
    float radius;
    

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------
    
    public void SetStartCamRotate(bool startRotation) {
        startCamRotate = startRotation;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------
    
    void CameraRotation() {
    
            // Keep rotating the camera, while constantly focusing on the player object
            transform.LookAt(pToken.transform);
            radius = (rotationSpeed * Time.deltaTime);
            transform.parent.transform.Rotate(0, radius, 0);
            
            parentAngle = transform.parent.transform.localEulerAngles;

            // Semi-circle complete, setting up for possible second rotation
            if(parentAngle.y > 180) {
                parentAngle.y = parentAngle.y - 360;
            }

            if(rotationDirection && parentAngle.y < 0) {
                // If parent angle becomes < 0, stop
                startCamRotate = false;
                rotationDirection = false;
            } 
            
            if(rotationDirection == false && parentAngle.y > 0) {
                // If parent angle becomes > 0, stop
                startCamRotate = false;
                rotationDirection = true;
            }
            

    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(pToken.transform);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if(startCamRotate) {
            CameraRotation();
        }
        
    }
}
