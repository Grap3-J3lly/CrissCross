using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------

    public enum ItemType {
        Coin,
        PowerUp,
        UIElement
    };

    [SerializeField] ItemType currentType;
    [SerializeField] float oscillationRange;
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    
    Vector3 newPos;
    Vector3 initialPos;
    Vector3 currentPos;

    float newYPos;

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------

    public ItemType GetCurrentType() {
        return currentType;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    // Moves item up and down slowly
    void Hover() {
        newYPos = (oscillationRange * Mathf.Sin(Time.time * speed)) + initialPos.y;
        newPos = new Vector3(currentPos.x, newYPos, currentPos.z);
        transform.position = newPos;
    }

    // Rotates item
    void Rotate() {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if(currentType == ItemType.Coin || currentType == ItemType.PowerUp) {
            Hover();
            Rotate();
            
        }
    }
}
