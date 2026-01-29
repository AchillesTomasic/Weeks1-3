using UnityEngine;
using UnityEngine.InputSystem;

public class Hider : MonoBehaviour
{
    public Vector3 startPos = Vector3.zero;
    public Vector3 hidePos = new Vector3(11.3299999f, -0.00157342583f, 0);
    public float hideDist;
    public Camera gameCam;
    public float WaitDurration;
    private float timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        /*
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldMousePos = gameCam.ScreenToWorldPoint(mousePos);
        worldMousePos.z = 0;
        float dist = Vector3.Distance(transform.position, worldMousePos);
        print(dist);
        if (dist < hideDist)
        {
            transform.position = hidePos;
        }
        */
        timer += Time.deltaTime;
        if(timer > WaitDurration) 
        {
            transform.position = hidePos; 
        }
    }
}
