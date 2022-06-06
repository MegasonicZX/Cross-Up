using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour
{
    public float moveSpeed;

    public Transform center;
    public float xSpread;
    public float ySpread;

    float timer = 0;
    public bool oppositeDirection;
    public float rayDist;
    public LayerMask turnPoint;
    bool flipped = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += moveSpeed * Time.deltaTime;
        
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        Raycasts();
    }

    void Raycasts()
    {
        RaycastHit2D turnAround = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), transform.right, rayDist, turnPoint);

        if (turnAround.collider == true)
        {
            Flip();
            flipped = !flipped;
        }

        if (flipped == !flipped)
        {
            
        }
    }

    void BackAndForth()
    {
        if (oppositeDirection == true)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float y = Mathf.Sin(timer) * ySpread;
            Vector3 pos = new Vector3(x, y, 0);

            transform.position = pos + center.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float y = Mathf.Sin(timer) * ySpread;
            Vector3 pos = new Vector3(x, y, 0);

            transform.position = pos + center.position;
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180f, 0);
    }
}
