using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Checker : MonoBehaviour
{
    public GameObject ground_check;
    [SerializeField] Vector2 boxSize;
    public LayerMask ground;

    public bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics2D.OverlapBox(ground_check.transform.position, boxSize, 0, ground))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(ground_check.transform.position, boxSize);
    }
}
