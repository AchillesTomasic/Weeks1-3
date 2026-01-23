using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    public float posSpeed;
    public float rotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ControllingAssignment();
    }
    void ControllingAssignment()
    {

        bool upHeld = Keyboard.current.upArrowKey.isPressed;
        if (upHeld)
        {

            transform.position += transform.up * posSpeed * Time.deltaTime;

        }
        bool downHeld = Keyboard.current.downArrowKey.isPressed;
        if (downHeld)
        {

            transform.position -= transform.up * posSpeed * Time.deltaTime;
        }
        bool leftRotHeld = Mouse.current.leftButton.isPressed;
        if (leftRotHeld)
        {
            transform.eulerAngles += transform.forward * rotSpeed * Time.deltaTime;
        }
        bool rightRotHeld = Mouse.current.rightButton.isPressed;
        if (rightRotHeld)
        {
            transform.eulerAngles -= transform.forward * rotSpeed * Time.deltaTime;
        }
    }

    void buttonGang()
    {
        bool leftIsHeld = Mouse.current.leftButton.isPressed;
        if (leftIsHeld)
        {
            Debug.Log("left is held");
        }
        bool leftIsPressed = Mouse.current.leftButton.wasPressedThisFrame;
        if (leftIsPressed)
        {
            Debug.Log("Left Mouse Pressed");
        }
        bool leftIsReleased = Mouse.current.leftButton.wasReleasedThisFrame;
        if (leftIsReleased)
        {
            Debug.Log("Left Mouse released");
        }

    }
}
