using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Looker : MonoBehaviour
{
    public float rotSpeed;
    public float zMax;
    public float zMin;
    public Camera cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curMousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = cam.ScreenToWorldPoint(curMousePos);
        worldMousePos.z = 0;
        
        //use end - start to get the position, initally its set at 0,0
        transform.up = worldMousePos - transform.position;
        transform.position += transform.up * 1f * Time.deltaTime;

    }
    // rotating in a direction
    //    // if we want to move pos, use transform.position
    //    Vector3 rot = transform.eulerAngles; // use this isntead of the quaternion rotation
    //    rot.z += rotSpeed * Time.deltaTime;
    //    transform.eulerAngles = rot;
    //    Debug.Log(transform.eulerAngles);
    //    rotationAssi();
    //}
    //void rotationAssi()
    //{
    //    if (transform.eulerAngles.z > zMax)
    //        {
    //        rotSpeed *= -1;
    //    }
    //    if(transform.eulerAngles.z < zMin)
    //    {
    //        rotSpeed *= -1;
    //    }

    //}
    //public bool switchswap;
    ////changes speed
    //void rotatorSpeed()
    //{

    //    if(rotSpeed > zMax)
    //    {
    //        switchswap = false;
    //    }
    //    if(rotSpeed < zMin)
    //    {
    //        switchswap = true;
    //    }

    //    if(switchswap) { rotSpeed += 1; }
    //    if (!switchswap) { rotSpeed -= 1; }
    //}
}
