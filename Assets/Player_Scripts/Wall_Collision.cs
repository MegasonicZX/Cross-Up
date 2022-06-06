using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Collision : MonoBehaviour
{
    public float rayDist;
    public LayerMask walls;

    public bool collidingWithWall;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SideRays();
        
    }

    void SideRays()
    {
       // RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, rayDist, walls);
       if (Physics2D.Raycast(transform.position, transform.right, rayDist, walls))
        {
            collidingWithWall = true;
        } else
        {
            collidingWithWall = false;
        }

    }
}
