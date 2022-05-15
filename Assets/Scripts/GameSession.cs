using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    public void RestartGame() {
        
        Debug.Log("Clicking is working");
        // Only have the one scene right now, so scene being loaded is scene 0
        SceneManager.LoadScene(0);
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
        
    }
}
