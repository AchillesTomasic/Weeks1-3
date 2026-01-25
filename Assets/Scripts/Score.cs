using UnityEngine;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public float[] saveScore = new float[2];
    public int scoreValue; // current score of the player
    public List<Transform> numbers = new List<Transform>(); //  list of all the number objects avalible
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        findScoreAtInstance();// obtains the current saveScoreValue
        setScoreAtPos();// sets all of the score position on screen
    }
    // sets the score positions
    void setScoreAtPos()
    {
        // loop used to set the score tiles for space 1
        for(int j = 0; j <= 9; j++)
        {
            // checks if the value of savescore is equal to the current number
            if(saveScore[0] == j)
            {
                numbers[j].position = new Vector3(8, 4,0); // sets the position for the active number
                
            }
            else
            {
                setOffScreen(j);// sets non-active numbers off screen
                
            }
        }
        // loop used to set the score tiles for space 2
        for(int j = 10; j <= 19; j++)
        {
            // checks if the value of savescore is equal to the current number
            if(saveScore[1] == j - 10)
            {

                numbers[j].position = new Vector3(6.8f, 4,0); // sets the position for the active number
            }
            else
            {
                setOffScreen(j);// sets non-active numbers off screen
            }
        }
  
    }
    // funciton sets the non used score values off screen
    void setOffScreen(int currNum)
    {
        numbers[currNum].position = new Vector3(-80,40,0);// sets positions of non active numbers
    }
    // grabs the number at each placement in the score value
    void findScoreAtInstance()
    {
        saveScore[0] = scoreValue % 10; // value of smallest number
        saveScore[1] = scoreValue/ 10 % 10; // value of the number in front
    }
}
