using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpForce = 1.0f;
    [SerializeField] float gravity = -1.0f;


    [SerializeField] Transform myCamera;

    [SerializeField] Animator myAnimator;

    CharacterController Controller;

    Vector3 movement;
    bool grounded;

    [SerializeField] PlayerStats myStats;

    [SerializeField] GameManager myGameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controller = GetComponent<CharacterController>();

        speed = myStats.moveSpeed;
        jumpForce = myStats.jumpForce;
        gravity = myStats.gravity;

        //reset player's health
        myStats.health = myStats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        if(xInput != 0 || yInput != 0)
        {
            myAnimator.SetBool("IsJogging", true);
        }
        else
        {
            myAnimator.SetBool("IsJogging", false);
        }

        //camera stuff
        Vector3 camFoward = myCamera.forward;
        Vector3 camRight = myCamera.right;

        camFoward.y = 0;
        camFoward.Normalize();

        camRight.y = 0;
        camRight.Normalize();

        Vector3 fowardRelativeMovementVector = yInput * camFoward;
        Vector3 rightRelativeMovement = xInput * camRight;


        var relativeMovement = (fowardRelativeMovementVector + rightRelativeMovement) * speed;

        //rotate character
        if (xInput != 0f || yInput != 0f)
        {
            transform.forward = relativeMovement;
        }


        relativeMovement.y = movement.y;
        movement = relativeMovement;

        movement.y += gravity * Time.deltaTime;

        if (Controller.isGrounded)
        {
            movement.y = 0f;
        }

        grounded = (Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1));

        myAnimator.SetBool("OnGround", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            movement.y = jumpForce;
            myAnimator.SetTrigger("Jumping");
        }

        Controller.Move(movement * Time.deltaTime);

        //check health for game over
        if(myStats.health <= 0)
        {
            myGameManager.GameOver();
        }

    }

    public void Damage()
    {
        myStats.health -= 1;
    }

}
