using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Create properties in the unity editor
    [SerializeField] private float m_WalkSpeed = 5f;
    [SerializeField] private float m_RunSpeed = 12f;
    [SerializeField] private float m_MovementSmoothing = 0.05f;

    // References variables for ease of use
    [SerializeField] Rigidbody m_Rigidbody;

    // Dynamic references
    Vector3 m_Velocity = Vector3.zero;

    // Changing property to track player movement input
    private Vector2 m_WalkingInput = Vector2.zero;
    private bool m_PlayerSprinting = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (!m_Rigidbody)
            m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // collect the AD/left-right and WS/up-down inputs
        float sideMovement = Input.GetAxis("Horizontal");
        float forwardMovement = Input.GetAxis("Vertical");

        // save inputs
        m_WalkingInput.x = sideMovement;
        m_WalkingInput.y = forwardMovement;

        // determine if the player is sprinting or not
        if (Input.GetKey(KeyCode.LeftShift))
            m_PlayerSprinting = true;
        else
            m_PlayerSprinting = false;

        //Respawn
        if (Input.GetKey(KeyCode.R))
            transform.position = new Vector3(10, 10, 0);
    }



    void FixedUpdate()
    {
        Move(m_WalkingInput);
    }

    private void Move(Vector2 move)
    {
        float currentSpeed = m_WalkSpeed;
        if (m_PlayerSprinting)
            currentSpeed = m_RunSpeed;

        Vector2 targetMovement = move;
        targetMovement.Normalize();
        targetMovement *= currentSpeed;

        Vector3 forwardMovement = transform.forward * targetMovement.y * -1;
        Vector3 sideMovement = transform.right * targetMovement.x * -1;

        Vector3 targetVelocity = forwardMovement + sideMovement + new Vector3(0f, m_Rigidbody.velocity.y, 0f);
        m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
