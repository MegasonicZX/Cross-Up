using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hot_Head_Behavior : MonoBehaviour
{
    public float climbSpeed;
    public float maxHeight;
    public float climbAccel;
    public float climbDecel;

    bool goUp;
    bool rotate;

    Vector3 targetRotation;
    void Start()
    {
        goUp = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (goUp == true)
        {
            climbSpeed += climbAccel * Time.deltaTime;
        }

        if (climbSpeed >= maxHeight)
        {
            goUp = false;
            //Flip();
        }

        if (goUp == false)
        {
            climbSpeed -= climbDecel * Time.deltaTime;
            
        }

        

        transform.position += new Vector3(0, climbSpeed * Time.deltaTime, 0);
    }

    void Flip()
    {
        transform.Rotate(0, 0, 180f);
    }
}
