using UnityEngine;

public class BounceAnimation : MonoBehaviour
{
    public AnimationCurve bounceAnim; // bounce animation curve for the objects
    public float timer; // timer for the animation curve
    public float maxTimer; // maximum timer for the animation curve
    public Vector3 savePosition; // saves the inital position
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        loopingAnimation(); // plays the looping animation
    }
    // animation player for looping animation
    void loopingAnimation()
    {
        Vector3 changePosition = transform.position; // saves the position of the object
        timer += Time.deltaTime; // adds to the timer
        float positionAnim = bounceAnim.Evaluate(timer); // obtains the value for the current pos in the animation
        changePosition.y += positionAnim; // changes the position of the animation
        /// checks if the value should loop
        if(timer > maxTimer){
            timer = 0; // resets timer
            changePosition = savePosition; // sets changePosition equal to savepos
        }
        transform.position = changePosition; // sets the objects position to the change the position value
    }
}
