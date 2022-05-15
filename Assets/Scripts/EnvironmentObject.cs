using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------
    public enum StationaryEnvironmentType {
        None,
        Tree,
        River
    };

    public enum MobileEnvironmentType {
        None,
        Log,
        Boat
    };

    [SerializeField] StationaryEnvironmentType currentStationaryType;
    [SerializeField] MobileEnvironmentType currentMobileType;

    [SerializeField] bool isStationary;

    [SerializeField] bool movementDirection;
    [SerializeField] float speed;
    
    Vector3 currentPosition;
    
    float laneWidth;
    


    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------

    public bool GetIsStationary() {
        return isStationary;
    }

    public StationaryEnvironmentType GetCurrentStationaryType() {
        return currentStationaryType;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------
    
    void WaterLoop() {

        // If z position is > laneWidth, move it to -z, else increase z
        if(movementDirection) {
            movementDirection = !movementDirection;
            speed = -speed;
            laneWidth = -laneWidth;
        } 

        if(transform.position.z > laneWidth) {
            transform.position = new Vector3(currentPosition.x,currentPosition.y,-laneWidth);
        }

        transform.position += new Vector3(0f,0f,speed);
    }


    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------


    void Start()
    {
        laneWidth = FindObjectOfType<BoardObject>().GetZWidth();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        WaterLoop();
    }
}
