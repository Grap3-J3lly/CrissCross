using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSection : MonoBehaviour
{
    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    // Need to set up Extra Life system to generate these objects depending on the value entered
    // Marked for rewrite asap

    public void DeactivateUILifeObeject(bool choice) {
        if(choice == false) {
            transform.Find("XLife1").gameObject.GetComponent<Renderer>().enabled = false;
        } else {
            transform.Find("XLife2").gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    public void DeactivateAllUILifeObjects() {
        transform.Find("XLife1").gameObject.GetComponent<Renderer>().enabled = false;
        transform.Find("XLife2").gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void ActivateAllUILifeObjects() {
        transform.Find("XLife1").gameObject.GetComponent<Renderer>().enabled = true;
        transform.Find("XLife2").gameObject.GetComponent<Renderer>().enabled = true;
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        ActivateAllUILifeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
