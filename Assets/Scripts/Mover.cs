using UnityEngine;

public class Mover : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public float accX;
    public float xMax;
    public float xMin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // vector 3
        Vector3 moverXPos = transform.position;
        speed += accX;
        moverXPos.x += speed * Time.deltaTime;
        transform.position = moverXPos;
        flipper();
    }
    void flipper()
    {
        if(transform.position.x > xMax )
        {
            
            accX = -0.1f;
        }
        if (transform.position.x < xMin)
        {
            
            accX = 0.1f;
        }
        if(speed > maxSpeed) { speed = maxSpeed;}
        if (speed < -maxSpeed) { speed = -maxSpeed;}
    }
}