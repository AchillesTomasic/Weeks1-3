using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class NoteMovement : MonoBehaviour
{
    //changes the score value
    public Score scoreScript; // obtains the score script
    public Camera camera;
    // manages the character bounce // 
    public AnimationCurve characterBounce; // animation curve for the players small bounce
    public bool ActiveBounce; // checks if the animation curve can be played
    public float bounceTimeCurrent; // the current position of the animation curve
    // manages the different note gameObjects
    public List<Transform> noteObj = new List<Transform>();// holds the note objects
    public List<Transform> effectObject = new List<Transform>();// holds the effect objects
    public AnimationCurve effectMovements; // animation curve for the note effects
    public List<NoteTimer> noteTimers = new List<NoteTimer>();// holds the note times
    // transforms for the different character game objects
    public List<Transform> charObj = new List<Transform>(); // holds the different character game objects
    public bool swapActive = false; // actuvates when the player hits a note
    public bool damageActive = false; // activates when the player takes damage

    public Transform playerObject; // character objects position
    public float moveSpeed; // speed of the notes lerp movement
    public float MaxResetTime; // maximum timer for the reset position function
    public float spawnDistance; // the spawn distance for the different notes
    // variables for player damage // 
    public float damageRadius; // damage radius of the player
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // manages each of the notes 
        for(int i = 0; i < noteObj.Count; i++)
        {
        movement(noteObj[i]); // movement for the note
        mouseOverNote(noteObj[i], i); // detects if mouse is over note
        changeNotePos(noteObj[i], i); // changes the position of note when mouse is overtop for some time
        damageEffect(noteObj[i]); // checks if the player has been damaged and preforms damage moves
        effectsScale(effectObject[i], i); // preforms the effects for movement
        }
        charBounce(); // preforms the animation bounce for the character
        charChanger(); // preforms the swapping character sprite system.
    }
    // change the position of the notes
    void changeNotePos(Transform noteTran, int posInTimerList)
    {
       // changes position of note and resets note timer
       if(noteTimers[posInTimerList].timer > MaxResetTime)
       {
        Vector3 notePos = positionSelector();// sets vector3 to a random boarder position
        Vector3 worldNotePos = camera.ScreenToWorldPoint(notePos); // allows equation to be preformed in worldspace
        noteTran.position = worldNotePos; //sets new not position to this transforms position
        ActiveBounce = true; // activates the bool for the players bounce
        scoreScript.scoreValue += 1; //  adds to the players score
        swapActive = true; // activates the character swap gameObject
        noteTimers[posInTimerList].timer = 0; // sets the time to new value
       }
    }
    // selects a random position on the boarder of the screen, then returns the value
    Vector3 positionSelector(){
        int corner = Random.Range(0,3); // selects one of the three corners to spawn the note within
        // left corner of the screen
        if(corner == 0)
        {
            return new Vector3(-spawnDistance,Random.Range(0,Screen.height),0); // chooses a new random position on the left of screen
        }
        // top corner of screen
        if(corner == 1)
        {
            return new Vector3(Random.Range(0,Screen.width),Screen.height + spawnDistance,0); // chooses a new random position on top of screen
        }
        // right of the screen
        else{
            return new Vector3(Screen.width + spawnDistance,Random.Range(0,Screen.height),0); // chooses a new random position on the right of screen
        }
    }
    // resets the position of the mouse
    void mouseOverNote(Transform noteTran,int posInTimerList)
    {
        Vector3 mousePos = Mouse.current.position.ReadValue(); // mouse pos relative to screen
        Vector3 mouseToWorldPos = camera.ScreenToWorldPoint(mousePos); // sets position from the screens pixels to the world points
        mouseToWorldPos.z = 0;// sets the x axis relative to other object
        float noteToMouseDist = Vector3.Distance(mouseToWorldPos,noteTran.position); // gets the difference between mouse pos and note pos
        // checks if the mouse is inside the note
        if(noteToMouseDist < noteTran.localScale.x)
        {
            noteTimers[posInTimerList].timer += Time.deltaTime; // adds to the note timer
        }
        // checks if the mouse is outside the note and it is still running
        if(noteToMouseDist > noteTran.localScale.x && noteTimers[posInTimerList].timer > 0)
        {
            noteTimers[posInTimerList].timer -= Time.deltaTime; // minus to the note timer
        }
    }
    // moves the position of the note
    void movement(Transform noteTran)
    {
        Vector2 pos = Vector2.Lerp(noteTran.position, playerObject.position,moveSpeed * Time.deltaTime);// lerps the position of the note from its current position to the characters position
        noteTran.position = pos; // sets the notes positon to the lerp pos
    }
    // manages the playerAnimationCurve bounce
    void charBounce()
    {
        if(ActiveBounce){
            bounceTimeCurrent += Time.deltaTime * 3; // adds to the timer
            float bounceScale = characterBounce.Evaluate(bounceTimeCurrent); // grabs the position of the 
            // system to change size
            Vector3 currentScale = playerObject.localScale; // grabs the current scale vector
            currentScale.y = bounceScale; // changes the size of the character to follow the animation curves value
            playerObject.localScale = currentScale; //  sets the local scale of the character transform
            // checks if the timer has fully run
            if(bounceTimeCurrent > 1)
            {
                ActiveBounce = false; // deactivates the bounce animation
            }
        }
        else
        {
            bounceTimeCurrent = 0; // reset the bounce timer
        }
    }
    // detects if the note enters the players damage radius
    void damageEffect(Transform noteTran)
    {
        float distanceBetweenPlayer = Vector3.Distance(playerObject.position,noteTran.position); // gets the difference between chracter pos and note pos
        // checks if the note is within damage radisu
        if(distanceBetweenPlayer < damageRadius)
        {
            Vector3 notePos = positionSelector(); // sets vector3 to a random boarder position
            Vector3 worldNotePos = camera.ScreenToWorldPoint(notePos); // allows equation to be preformed in worldspace
            noteTran.position = worldNotePos; //sets new not position to this transforms position
            damageActive = true; // activates the character swap gameObject
            scoreScript.scoreValue = 0; // resets the players score to 0
        }
    }
    void charChanger()
    {
        // swaps the character sprite if note is collected
        if(swapActive)
        {
            int charPose = Random.Range(1,4); // chooses a random number for the character sprite
            // loops over each sprite instance
            for(int i = 0; i < charObj.Count; i++){
                // checks if the charObjects index is equal to the randomly selected number
                if(i == charPose){
                    charObj[i].position = new Vector3(0,-3,0); // sets the position of the character on screen
                }
                else{
                    charObj[i].position = new Vector3(-35,-35,0); // sets the position of the character off screen
             }
            }
            swapActive = false; // deactives the swap variable
        }
        // swaps the character game object to the damage sprite
        if(damageActive)
        {
            charObj[0].position = new Vector3(0,-3,0); // sets the position of the damaged character on screen
            // deactives all other sprites
            for(int i = 1; i < charObj.Count; i++){
                charObj[i].position = new Vector3(-35,-35,0); // sets the position of the character off screen
            }
            damageActive = false; // deactives the damage variable
        }
    }
    // changes the scale of the effects
    void effectsScale(Transform eff,int timerEffect){
        float effectScale = effectMovements.Evaluate(noteTimers[timerEffect].timer); //changes the scale of the effects object
        eff.localScale = new Vector3(effectScale ,effectScale ,0); // changes the scale of the effects object
    }
}
