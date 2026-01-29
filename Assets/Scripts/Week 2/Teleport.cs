using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera cam;
    float timer;
    float timerMax = 0.5f;

    float speedX = 10;
    float speedY = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        teleport();
        bouncyBall();
    }
    void bouncyBall()
    {
        
        Vector3 pos = transform.position;
        pos.x += speedX * Time.deltaTime;
        pos.y += speedY * Time.deltaTime;
        transform.position = pos;
        Vector3 posflip = cam.WorldToScreenPoint(transform.position);
        if (posflip.x > Screen.width)
        {
            pos.x = Screen.width;
            speedX *= -1;
        }
        if(posflip.x < 0)
        {
            pos.x = 0;
            speedX *= -1;
        }
        if (posflip.y > Screen.height)
        {
            pos.y = Screen.height;
            speedY *= -1;
        }
        if (posflip.y < 0)
        {
            pos.y = 0;
            speedY *= -1;
        }
        
    }
    void teleport()
    {
        if (timer > timerMax)
        {
            Vector3 teleportPos = new Vector3(Random.Range(0,Screen.width), Random.Range(0, Screen.height), 0);
            Vector3 worldPos = cam.ScreenToWorldPoint(teleportPos); // screen to world point makes the pixels of the screen equal to the world
            worldPos.z = 0;
            transform.position = worldPos;
            timer = 0;
        }
    }
}
