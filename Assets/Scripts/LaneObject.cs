using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneObject : MonoBehaviour
{
    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------

    enum LaneType {
        MobileHazard,
        MobileNonHazard,
        StationaryHazard,
        StationaryEnvironmentType
    };

    [SerializeField] LaneType currentLane;
    [SerializeField] bool isStationary;
    // True = Left, False = Right
    [SerializeField] bool movementDirection;
    [SerializeField] float speed;

    Vector3 currentPos;
    BoardObject currentBoard;
    BorderWallObject boardWall1;
    BorderWallObject boardWall2;

    float laneWidth;
    

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------

    public float GetLaneWidth() {
        return laneWidth;
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        // Determine Width of the lane
        currentBoard = FindObjectOfType<BoardObject>();
        boardWall1 = currentBoard.transform.Find("EndOfBoardZNegative").GetComponent<BorderWallObject>();
        boardWall2 = currentBoard.transform.Find("EndOfBoardZPositive").GetComponent<BorderWallObject>();

        laneWidth = ((-1) * boardWall1.transform.position.z) + boardWall2.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
    }
}
