using UnityEngine;
public class Searching : MonoBehaviour
{
public float speed = 0;
public AnimationCurve curve;
public Camera cam;
public Vector2 startPos;
public Vector2 endPos;
public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        endPos = new Vector2(Random.Range(0,Screen.width),Random.Range(0,Screen.height));
        endPos = cam.ScreenToWorldPoint(endPos);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        bobbing();
    }
    void movement()
    {
        timer += Time.deltaTime * 2;
        
        Vector2 pos = Vector2.Lerp(startPos,endPos, timer);
        transform.position = pos;
        Vector2 compare = transform.position;

        if(compare == endPos){
            startPos = endPos;
            timer = 0;
            endPos = new Vector2(Random.Range(0,Screen.width),Random.Range(0,Screen.height));
            endPos = cam.ScreenToWorldPoint(endPos); 
        }
    }
    void bobbing() 
    {
        speed += Time.deltaTime /2;
        float overtime = curve.Evaluate(speed);
        Vector2 posbob = transform.position;
        posbob.y = overtime;
        print(overtime);
        transform.position = posbob;
        if(speed > 1)
        {
        speed = 0;
        }

    }
}
