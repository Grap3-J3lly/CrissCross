using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardObject : MonoBehaviour
{
    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------

    enum StationaryHazardType {
        None,
        Mine,
        Water
    };

    enum MobileHazardType {
        None,
        Truck
    };

    [SerializeField] StationaryHazardType currentStationaryType;
    [SerializeField] MobileHazardType currentMobileType;
    [SerializeField] bool isStationary;
    // True = Negative Direction, False = Positive Direction
    [SerializeField] bool movementDirection;
    [SerializeField] float speed;

    Vector3 currentPos;

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------
    

    // Translates a certain distance before resetting its position
    void CrossBoard() {
        if(movementDirection) {
            movementDirection = !movementDirection;
            speed = -speed;
        }
        transform.position += new Vector3(0f,0f,speed);
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if(isStationary == false) {
            CrossBoard();
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<PlayerObject>()) {
            other.gameObject.GetComponent<PlayerObject>().LoseALife();
        } else {
            currentPos.z = -currentPos.z;
            transform.position = currentPos;
        }
    }
}
