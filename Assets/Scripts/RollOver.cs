using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
public class RollOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    public Camera cam; // camera
    public Transform duck;
    bool timerIsRunning = false;
    public float distanceToActive;
    public float countdown;
    public AnimationCurve curve;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rollOverScript();
        changePos();
    }
    void rollOverScript()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue(); // mouse pos
        Vector3 mouseInWorld = cam.ScreenToWorldPoint(mousePos); // sets to world from the screen
        mouseInWorld.z = 0; // sets in the same layer as everything else
        float dist = Vector3.Distance(transform.position, mouseInWorld);
        print(dist);
        if (dist < distanceToActive)
        {
            timerIsRunning = true;
        }
        else
        {
            timerIsRunning = false;
        }


        // timer stuff
        if (timerIsRunning)
        {   
                countdown += Time.deltaTime;
        }
        else
        {
            countdown = 0;
        }

    }
    void changePos()
    {
        float output = curve.Evaluate(countdown);
        transform.localScale = Vector3.one * output;
        
    }
}
