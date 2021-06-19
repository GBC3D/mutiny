using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TESTCharacterControllerThirdPerson : MonoBehaviourPunCallbacks
{

    [SerializeField] public CharacterController controller; // Reference to CharacterController
    [SerializeField] public Transform cam; // Camera transform
    [SerializeField] public Transform displayRef; // Reference to the sprite display transform
    [SerializeField] public Animator animator; // AnimatorController for the character display
    public GameObject cameraParent; //The parent of the camera gameobject.

    [SerializeField] public float speed = 6f; // Normal move speed
    [SerializeField] public float sprintAdd = 1.0f; // Sprint speed addition

    // Bool for facing right with a get property
    private bool facingRight = false;
    public bool FacingRight { get { return facingRight; } }

    private bool playerSprinting = false; // bool of player sprinting

    private Vector3 requestMoveDirection; // direction to move in the next fixed update

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Start()
    {
        //Makes sure that the player has authority of the object using the camera.
        cameraParent.SetActive(photonView.IsMine);

        // For the future, uncomment to remove cursor visibility
        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if player has ownership of this controller
        if (!photonView.IsMine)
        {
            return;
        }

        // Grab forward and size move values
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // store in direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        CheckMove(direction);
        CheckFlip(horizontal);

        if (animator != null)
        {
            if (vertical > 0)
            {
                if (horizontal != 0)
                {
                    animator.SetInteger("MoveDirection", 1);
                }
                else
                {
                    animator.SetInteger("MoveDirection", 2);
                }
            } else if (vertical < 0)
            {
                if (horizontal != 0)
                {
                    animator.SetInteger("MoveDirection", -1);
                } else
                {
                    animator.SetInteger("MoveDirection", -2);
                }
            } else
            {
                animator.SetInteger("MoveDirection", 0);
            }
        }
    }

    private void CheckMove(Vector3 direction)
    {
        // Move if the magnitude of the direction is not 0
        if (direction.magnitude != 0)
        {
            // Calculate target movement angle
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // Set the requested move direction
            requestMoveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        // Otherwise, don't move
        else
        {
            requestMoveDirection = Vector3.zero;
        }

        // Check if the player is sprinting and set corresponding speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSprinting = true;
            sprintAdd = 15f;
        }
        else
        {
            playerSprinting = false;
            sprintAdd = 0f;
        }

        //DoMove();
    }

    // Checks if the player display needs to flip directions
    private void CheckFlip(float horizontal)
    {
        if (facingRight && horizontal < 0)
        {
            Flip();
        } else if (!facingRight && horizontal > 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //Checks to see if player has ownership of the controller.
        if (!photonView.IsMine)
        {
            return;
        }
        DoMove();
    }

    private void DoMove()
    {
        // Move the player
        Vector3 movement = requestMoveDirection.normalized * (speed + sprintAdd) * Time.fixedDeltaTime;
        controller.Move(movement);

        // Update movement for animator
        if (animator != null)
            animator.SetFloat("MoveSpeed", movement.magnitude);
    }

    // Flip the player display
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 localScale = displayRef.transform.localScale;
        localScale.x *= -1;
        displayRef.transform.localScale = localScale;
    }
}
