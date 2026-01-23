using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    public float posSpeed;
    public float rotSpeed;
    public SpriteRenderer spriteRenderer;
    public Color color;
    public List<SpriteRenderer> controllableRend;
    public Camera cam;
    public List<Transform> controlledTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer.color = color;
        bool isInsideSprite = spriteRenderer.bounds.Contains(transform.position);
        controlledTransform.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curMousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = cam.ScreenToWorldPoint(curMousePos);
        worldMousePos.z = 0;
        bool isLeftMousePressed = Mouse.current.leftButton.IsPressed();
        if(isLeftMousePressed)
        {
            // find any renderes currently hovered over
            for (int i = 0; i < controllableRend.Count; i++)
            {
                bool ishovered = controllableRend[i].bounds.Contains(worldMousePos);
                if (ishovered)
                {
                    controlledTransform.Add(controllableRend[i].transform);
                }
            }
        }
        for (int i = 0; i < controlledTransform.Count; i++)
        {
            Transform currentTransform = controlledTransform[i];
            ControllingAssignment(currentTransform);
        }


        
    }
    void ControllingAssignment(Transform transf)
    {

        bool upHeld = Keyboard.current.upArrowKey.isPressed;
        if (upHeld)
        {

            transf.position += transform.up * posSpeed * Time.deltaTime;

        }
        bool downHeld = Keyboard.current.downArrowKey.isPressed;
        if (downHeld)
        {

            transf.position -= transform.up * posSpeed * Time.deltaTime;
        }
        bool leftRotHeld = Mouse.current.leftButton.isPressed;
        if (leftRotHeld)
        {
            transf.eulerAngles += transform.forward * rotSpeed * Time.deltaTime;
        }
        bool rightRotHeld = Mouse.current.rightButton.isPressed;
        if (rightRotHeld)
        {
            transf.eulerAngles -= transform.forward * rotSpeed * Time.deltaTime;
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
