using System;
using UnityEngine;

public class GreenBallCollisionManager : BallCollisionManager
{

    public AudioSource myClip;
    public override void CollideWithBall(GameObject OtherBall)
    {
        Debug.Log("Green Ball Collision Manager Function");

        // Homework: Do something interesting here
        //Should play the Yippee sound when green ball collides with red ball
        if(OtherBall.GetComponent<RedBallCollisionManager>() != null)
        {
            myClip.Play();
            Debug.Log("Sound should play");
        }
        
    }
}

