using UnityEngine;
using UnityEngine.InputSystem;

public class TankObj : MonoBehaviour
{
    public float posSpeed = 1f;
    public Camera cam;
    public Transform gunbarrel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mover();
        gun();
    }
    void mover()
    {
        Vector3 pos = transform.position;
        bool upHeld = Keyboard.current.rightArrowKey.isPressed;
        if (upHeld)
        {

            pos.x += posSpeed * Time.deltaTime;

        }
        bool downHeld = Keyboard.current.leftArrowKey.isPressed;
        if (downHeld)
        {

            pos.x -= posSpeed * Time.deltaTime;
        }
        
        transform.position = pos;

        


    }
    void gun()
    {

        Vector3 curMousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = cam.ScreenToWorldPoint(curMousePos);
        worldMousePos.z = 0;
        gunbarrel.up = worldMousePos - gunbarrel.position;
        
    }
}
