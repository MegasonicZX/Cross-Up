using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    float regularMoveSpeed;

    

    public float jumpSpeed;
    [SerializeField] float maxJumpHeight;
    [SerializeField] float jumpAccel;
    [SerializeField] float jumpDecel;
    [SerializeField] float maxFallSpeed;

    public float dashSpeed;
    float regularDashSpeed;

    Wall_Collision stop;
    
    [SerializeField] bool facingRight = true;
    

   
    Ground_Checker checkThis;
    bool isJumping;

    public bool isDashing;
    public float dashTime;
    [SerializeField] float dashSubtractor;
    float maxDashTime;
    int dashCount = 1;

    PlayerHealth life;
    bool paused;
    void Start()
    {
        stop = GetComponent<Wall_Collision>();
        checkThis = GetComponent<Ground_Checker>();
        life = GetComponent<PlayerHealth>();

        maxDashTime = dashTime;
        regularMoveSpeed = moveSpeed;
        regularDashSpeed = dashSpeed;
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        } 

        if (paused == true)
        {
            Time.timeScale = 0;
        }
        if (life.isDamaged == false)
        {
            CharacterMovement();
        }
        
        
        if (Input.GetButtonDown("Fire1"))
        {
            isDashing = true;
        }

        if (Input.GetButtonDown("Fire1") && checkThis.isGrounded == false)
        {
            dashCount -= 1;
        }

        if (isDashing == true && dashCount > -1)
        {
            dashTime -= dashSubtractor * Time.deltaTime;
            Dash();
        }

        if (dashTime <= 0)
        {
            isDashing = false;
            dashTime = maxDashTime;
        }
    }

    private void FixedUpdate()
    {
        if (life.isDamaged == false)
        {
            Jump();
        }
        
        
    }
    private void CharacterMovement()
    {
        float hMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
        }

        if (facingRight == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        if (facingRight == false)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
            
        }

        if (stop.collidingWithWall == true)
        {
            moveSpeed = 0;
            dashSpeed = 0;
        } else
        {
            moveSpeed = regularMoveSpeed;
            dashSpeed = regularDashSpeed;
        }
        transform.position += new Vector3(hMove, 0, 0);
    }

    void Jump()
    {
        float jumpUp = Input.GetAxisRaw("Jump");

        if (jumpSpeed < maxJumpHeight && jumpUp > 0 && checkThis.isGrounded == true)
        {
            isJumping = true;
        }
        
        if (isJumping == true)
        {
            jumpSpeed += jumpAccel * Time.deltaTime;
        }

        if (jumpUp != 1 || jumpSpeed > maxJumpHeight)
        {
            isJumping = false;
        }

        if (isJumping == false && checkThis.isGrounded == false && isDashing == false)
        {
            jumpSpeed -= jumpDecel * Time.deltaTime;
        }

        if(checkThis.isGrounded == true && isJumping == false)
        {
            jumpSpeed = -1;
        }

        if (checkThis.isGrounded == true)
        {
            dashCount = 1;
        }

        if (jumpSpeed <= maxFallSpeed)
        {
            jumpSpeed = maxFallSpeed;
        }

        transform.position += new Vector3(0, jumpSpeed * Time.deltaTime, 0);

    }


    void Dash()
    {
         if (facingRight == true)
        {
            transform.position += new Vector3(dashSpeed * Time.deltaTime, 0, 0);
        } else
        {
            transform.position -= new Vector3(dashSpeed * Time.deltaTime, 0, 0);
        }
    }
}
