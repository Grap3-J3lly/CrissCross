using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardObject : MonoBehaviour
{
    //------------------------------------------------------
    //                    VARIABLES
    //------------------------------------------------------

    // Credit to aldonaletto for idea of attaching empty child objects to 
    //something to keep track of the coordinates of the end of the object
    //https://answers.unity.com/questions/329155/how-to-calculate-position-of-cannons-end.html

    [SerializeField] float zWidth;

    Vector3 initialPos;
    Vector3 scaleVector;

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------

    public Vector3 GetPosition() {
        return initialPos;
    }

    public float GetZWidth() {
        return zWidth;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    // Need to make child walls get position coordinates from here
    void SetBoardZWidth() {

    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        scaleVector = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
