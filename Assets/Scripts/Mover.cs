using UnityEngine;

public class Mover : MonoBehaviour
{
    public Camera gameCamera;
    public float maxSpeed;
    public float speed;
    public float speedy;
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
        moverXPos.y += speedy * Time.deltaTime;
        transform.position = moverXPos;
        //Screen.width;
        //Screen.height;
        //gameCamera.WorldToScreenPoint(//somerandomvector);
        Vector3 screenTransformPosition = gameCamera.WorldToScreenPoint(transform.position);
        xMax = Screen.width;

        flipper(screenTransformPosition);
    }

    void flipper(Vector3 pos)
    {
        if(pos.x > xMax )
        {
            
            accX = -0.1f;
        }
        if (pos.x < xMin)
        {
            
            accX = 0.1f;
        }

        if (speed > maxSpeed) { speed = maxSpeed;}
        if (speed < -maxSpeed) { speed = -maxSpeed;}
    }
}