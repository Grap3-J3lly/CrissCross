/*
 * Criss Cross, v.00000013, by James Bond
 * 
 * Inspired by: Frogger, and more recently, CrossyRoad
 * 
 * A lot of this was built as I was constantly referring to a Udemy Unity 3D tutorial.
 * I often learned different/better ways of doing things as I was creating this, which might be 
 * obvious in some of the various scripts. Anything I found from specific threads on the internet
 * I included in a comment above the area where it was used.
 * 
 * The specific course followed during this process: https://www.udemy.com/course/unitycourse2/
 * 
 * Disclaimer: The "Angry Bird Easter Egg" is a custom made model intended to resemble the primary character
 * of "Angry Birds", by Rovio Entertainment. I do not own anything in relation to the "Angry Birds" series, 
 * I just added it in to make my sister laugh.
 * 
 * On-Screen Touch Buttons used in HUD: Courtesy of Kenney - https://www.kenney.nl/assets/onscreen-controls
 */

#region TODO:
    /*
     * Start Menu
     * Info statement upon beginning the game, informing of criteria to win
     * Lane generation across complete board
     * Continuous board loop
     * Additional types of objects (hazards, environment, items)
     * Utilize real assets
     * Proper jump mechanic
     * Music
     * Sound Effects
     * Implementation of proper layers for collision detection (Need to look into this more first)
     * Generate objects/delete objects as necessary
     * Lock camera from moving along the Z axis after player object is too close to edge
     * Camera/Background boundary for max distance on each end of the board 
            (So object creation and deletion is hidden from user)
     * Improve UI (ties into using assets)
     * Better Scene/Object/File organization
     */
#endregion

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerObject : MonoBehaviour
{

    //------------------------------------------------------
    //                  VARIABLES
    //------------------------------------------------------


    // While following along with Udemy video, it was mentioned that if there are
    // multiple scenes, this may be an ineffective way of handling Canvas manipulation.
    // I need to revisit this.
    [SerializeField] Canvas winScreenCanvas;
    [SerializeField] Canvas loseScreenCanvas;
    [SerializeField] Canvas mainHUDCanvas;
    [SerializeField] WinLoseHUD finalScreenSectionWin;
    [SerializeField] WinLoseHUD finalScreenSectionLose;
    [SerializeField] int winAmount;
    [SerializeField] int livesRemaining;
    [SerializeField] int pointsCollected;
    [SerializeField] bool changeCamDirection;
    // How much the object should move per movement event
    [SerializeField] float shiftScale;

    ScoreSection scoreSection;
    LifeSection lifeSection;
    GameObject tempGameObject;
    CameraControl mainCam;
    CharacterController charController;
    EnvironmentObject currentEnvironmentObject;
    HazardObject currentHazardObject;
    Vector3 initialPos;
    Vector3 forwardMovement;
    Vector3 backwardMovement;
    Vector3 rightMovement;
    Vector3 leftMovement;
    
    int coinCount;

    //------------------------------------------------------
    //                  GETTERS/SETTERS
    //------------------------------------------------------
    
    public int GetCoinCount() {
        return coinCount;
    }

    public int GetWinAmount(){
        return winAmount;
    }

    //------------------------------------------------------
    //                  CUSTOM METHODS
    //------------------------------------------------------

    // Sets up Win HUD
    void WinGame() {
        winScreenCanvas.enabled = true;
        mainHUDCanvas.enabled = false;
        scoreSection.DeactivateHUDCoins();
        finalScreenSectionWin.SetWinOrLoss(true);
        finalScreenSectionWin.DisplayFinalScore();
        lifeSection.DeactivateAllUILifeObjects();
    }

    // Sets up Lose HUD
    void LoseGame() {
        loseScreenCanvas.enabled = true;
        mainHUDCanvas.enabled = false;
        scoreSection.DeactivateHUDCoins();
        finalScreenSectionLose.SetWinOrLoss(false);
        finalScreenSectionLose.DisplayFinalScore();
    }

    // Changes the input controls. If camera rotates, then input changes to reflect the change
    void SetMovementDirection() {
        forwardMovement = new Vector3(-shiftScale,0,0);
        backwardMovement = new Vector3(shiftScale,0,0);
        leftMovement = new Vector3(0,0,-shiftScale);
        rightMovement = new Vector3(0,0,shiftScale);
    }

    // How to interact with various game items (only the two for now);
    void HandleItemObject(GameObject otherObject) {
        
        ItemObject.ItemType objectType = otherObject.GetComponent<ItemObject>().GetCurrentType();
        
        switch(objectType) {
            case ItemObject.ItemType.Coin: 
                coinCount++;
                scoreSection.ChangeScore(pointsCollected * 2, true);
                scoreSection.UpdateHUDCoins(coinCount);
            break;
            case ItemObject.ItemType.PowerUp: 
            scoreSection.ChangeScore(pointsCollected/2, true);
            changeCamDirection = true;
            mainCam.SetStartCamRotate(true);
            break;
        }
    }

    // Decrease the number of lives for the user and show that on the HUD
    public void LoseALife() {
        // Marked for rewrite asap
        
        livesRemaining--;

        if(livesRemaining > 0) {
            lifeSection.DeactivateUILifeObeject(true);
        } else {
            lifeSection.DeactivateUILifeObeject(false);
        }
        
    }

    //------------------------------------------------------
    //                  INPUT METHODS
    //------------------------------------------------------

    // Need to iron out movement - Snap to grid?

    // Defines how input should translate into movement
    void OnMoveForward() {
        charController.Move(forwardMovement);
    }

    void OnMoveBackward() {
        charController.Move(backwardMovement);
    }

    void OnMoveRight() {
        charController.Move(rightMovement);
    }

    void OnMoveLeft() {
        charController.Move(leftMovement);
    }

    //------------------------------------------------------
    //                  STANDARD METHODS
    //------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        mainCam = FindObjectOfType<CameraControl>();
        winScreenCanvas.enabled = false;
        loseScreenCanvas.enabled = false;
        initialPos =  transform.position;
        charController = transform.gameObject.GetComponent<CharacterController>();
        SetMovementDirection();
        coinCount = 0;
        scoreSection = FindObjectOfType<ScoreSection>();
        lifeSection = FindObjectOfType<LifeSection>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the character down after stepping up onto something
        if(charController.isGrounded == false && transform.position.y > initialPos.y) {
            charController.Move(new Vector3(0,-1,0));
        }

        // Flips the movement controls with the camera change
        if(changeCamDirection) {
            shiftScale = -shiftScale;
            changeCamDirection = false;
            SetMovementDirection();
        }

        // Check for Win Condition
        if(coinCount == winAmount) {
            // Win Screen Appears
            WinGame();
        }

        // Check for Lose Condition
        if(livesRemaining < 0) {
            // Lose Screen Appears
            LoseGame();
        }
    }

    void OnTriggerEnter(Collider other) {
    
        tempGameObject = other.gameObject;

        // If Game Object is an item
        if(tempGameObject.GetComponent<ItemObject>()) {
            // Update Score
            HandleItemObject(tempGameObject);
            
            // Remove object
            tempGameObject.SetActive(false);            
        }

        
    }

    void OnControllerColliderHit(ControllerColliderHit objectHit) {

        if(objectHit.gameObject.GetComponent<HazardObject>()) {
            LoseALife();
            charController.Move(backwardMovement);
        }
        
        // Need to reapproach the water aspect - Object needs to move to negative of 
        // move that caused collision

        // Is this a moving environment object?
        if(objectHit.gameObject.GetComponent<EnvironmentObject>()) {
            
            currentEnvironmentObject = objectHit.gameObject.GetComponent<EnvironmentObject>();
            
            // Did it hit the water?
            if(currentEnvironmentObject.GetIsStationary() && currentEnvironmentObject.GetCurrentStationaryType()
            == EnvironmentObject.StationaryEnvironmentType.River) {
                charController.Move(backwardMovement);
            }

        }
    }
}
