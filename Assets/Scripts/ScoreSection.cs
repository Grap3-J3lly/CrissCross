using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSection : MonoBehaviour
{
    // Followed along with Unity 3D Unity Tutorial to change score

    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------

    TMP_Text scoreText;
    PlayerObject currentPlayer;
    Renderer[] activeCoins;
    
    int currentScore;

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------

    public int GetCurrentScore() {
        return currentScore;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    // Need to set up Score system to generate the coin objects depending on the value entered
    // As opposed to using the loop

    public void ChangeScore(int amount, bool increase) {
        if(increase == false) {
            amount = -amount;
        } 
        currentScore += amount;

        scoreText.text = "Score: " + currentScore.ToString();
    }  

    public void DeactivateHUDCoins() {
        for(int count = 0; count < currentPlayer.GetWinAmount(); count++) {
            activeCoins[count].enabled = false;
        }
    }

    public void UpdateHUDCoins(int currentCoinCount) {
        activeCoins[currentCoinCount-1].enabled = true;
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
        scoreText.text = "Score: " + currentScore.ToString();
        currentPlayer = FindObjectOfType<PlayerObject>();
        activeCoins = transform.Find("Coins").gameObject.GetComponentsInChildren<Renderer>();
        DeactivateHUDCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
