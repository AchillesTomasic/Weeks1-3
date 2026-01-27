using UnityEngine;
using UnityEngine.InputSystem;

public class TitleScreen : MonoBehaviour
{
    //public NoteMovement noteScript; // script for the note objects
    public Transform playButton; // play button game object
    public Transform effectsOnPlayButton; // play button effect
    public Transform transition; // transition effect
    public Camera camera; // obtains the screens camera component
    public float playButtonMaxTimer; // maximum timer for the play button
    public float playButtonTimer; // timer for the play button
    public float effectAnimTimer;// lerp timer for the effect
    public float transitionTimer; // timer for the transition
    public AnimationCurve playbuttonHoldInditcator; // animation indicator for holding the play button
    public AnimationCurve transitionCurve; // animation curve for the transition
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(0,0,0); //sets the title screen on screen
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transitionTimer < 1.1f){
        mouseOverPlay(); // checks if the mouse is over the play button
        RemovePlayScreen();// moves the title screen when the timer is up
        playButtonEffects(); // changes the scale of the effect alongside the timer
        screenTransition(); // creates the screen transition affect
        }
    }
    // function detects if the mouse is over the play button
    void mouseOverPlay()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();// obtains the position of the mouse
        Vector3 mouseWorldPos = camera.ScreenToWorldPoint(mousePos); // converts the mouse position from screen pixels to the world point
        mouseWorldPos.z = 0; // places mouse on z axis
       // checks if the mouse is within the bounds of the play button
        if(mouseWorldPos.x > playButton.position.x - playButton.localScale.x / 2 &&
            mouseWorldPos.x < playButton.position.x + playButton.localScale.x / 2 &&
            mouseWorldPos.y > playButton.position.y - playButton.localScale.y / 2 &&
            mouseWorldPos.y < playButton.position.y + playButton.localScale.y / 2)
        {
            playButtonTimer += Time.deltaTime; // adds to the timer when it held over
        }
        else if(playButtonTimer > 0){
            playButtonTimer -= Time.deltaTime * 2; // subs to the timer when not held over
        }
    }
    void playButtonEffects()
    {
        float effectScale = playbuttonHoldInditcator.Evaluate(playButtonTimer); //  value of animation curve for effect scale
        effectsOnPlayButton.localScale = new Vector3(7f + effectScale,1.5f + effectScale,0); // changes the scale of the button effect
    }
    // moves the play screen off screen
    void RemovePlayScreen()
    {
        if(playButtonTimer > playButtonMaxTimer){
            playButtonTimer = 10000;// sets playButton to large number so animation can play
            transition.position = new Vector3(0,0,0); // puts the transition on screen
            transitionTimer += Time.deltaTime / 2; // increases the transtion timer
            // will move the transform off screen half way through the animation
            if(transitionTimer > 0.5f){
            transform.position = new Vector3(-100,-100,0); // sets the title screens position off screen
            }
            if(transitionTimer > 1){
                transition.position = new Vector3(-100,100,0); // puts the transition off screen
            }
        }
    }
    // transitions the screen to play screen
    void screenTransition()
    {
        float transitionScale = transitionCurve.Evaluate(transitionTimer); // variable for the transition curve
        transition.localScale = new Vector3(transitionScale * 15,transitionScale * 15,0); // transtiion scale
    }
}
