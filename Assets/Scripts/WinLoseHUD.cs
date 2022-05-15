using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseHUD : MonoBehaviour
{
    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------

    [SerializeField] string winText;
    [SerializeField] string loseText;
    [SerializeField] string finalScoreText;
    [SerializeField] ScoreSection currentScoreInfo;

    TMP_Text finalScoreTextArea;

    // True if game is won
    bool winOrLoss;

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------
    public void SetWinOrLoss(bool value) {
        winOrLoss = value;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    public void DisplayFinalScore() {
        if(winOrLoss) {
            finalScoreTextArea = transform.Find("Info Section").gameObject.transform.Find("Final Score Text (Win)").GetComponent<TMP_Text>();
            finalScoreTextArea.text = finalScoreText + currentScoreInfo.GetCurrentScore().ToString();
        } else {
            finalScoreTextArea = transform.Find("Info Section").gameObject.transform.Find("Final Score Text (Lose)").GetComponent<TMP_Text>();
            finalScoreTextArea.text = finalScoreText + currentScoreInfo.GetCurrentScore().ToString();
        }
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
