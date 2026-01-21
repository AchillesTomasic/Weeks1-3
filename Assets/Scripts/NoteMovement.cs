using UnityEngine;
using UnityEngine.InputSystem;

public class NoteMovement : MonoBehaviour
{
    public Camera camera;
    public Transform playerObject; // character objects position
    public float moveSpeed; // speed of the notes lerp movement
    public float resetTimer; // counter for the reset timer
    public float MaxResetTime; // maximum timer for the reset position function
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement(); // movement for the note
        mouseOverNote(); // detects if mouse is over note
        changeNotePos(); // changes the position of note when mouse is overtop for some time
    }
    // change the position of the notes
    void changeNotePos()
    {
       // changes position of note and resets note timer
       if(resetTimer > MaxResetTime)
       {
        Vector3 notePos = new Vector3(Random.Range(0,Screen.width),Random.Range(0,Screen.height),0); // chooses a new random position
        Vector3 worldNotePos = camera.ScreenToWorldPoint(notePos);
        transform.position = worldNotePos; //sets new not position to this transforms position
        resetTimer = 0; // sets the time to new value
       }
    }
    // resets the position of the mouse
    void mouseOverNote()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue(); // mouse pos relative to screen
        Vector3 mouseToWorldPos = camera.ScreenToWorldPoint(mousePos); // sets position from the screens pixels to the world points
        mouseToWorldPos.z = 0;// sets the x axis relative to other object
        float noteToMouseDist = Vector3.Distance(mouseToWorldPos,transform.position); // gets the difference between mouse pos and note pos
        // checks if the mouse is inside the note
        if(noteToMouseDist < transform.localScale.x)
        {
            resetTimer += 1 * Time.deltaTime; // adds to the reset timer
        }
    }
    // moves the position of the note
    void movement()
    {
        Vector2 pos = Vector2.Lerp(transform.position, playerObject.position,moveSpeed * Time.deltaTime);// lerps the position of the note from its current position to the characters position
        transform.position = pos; // sets the notes positon to the lerp pos
    }
}
