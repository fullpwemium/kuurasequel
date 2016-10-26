using System;
using UnityEngine;
using System.Collections;


public class PlatformerCharacter2D : MonoBehaviour
{
    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField]
    private float m_JumpForce = 400f;
    [SerializeField]
    private float m_pushForce = 200f;
    public float M_Jumpforce
    {
        set
        {
            m_JumpForce = value;
        }
        get
        {
            return m_JumpForce;
        }
    }
    [SerializeField]
    private float m_FlyForce = 100f;
    [Range(0, 1)]
    [SerializeField]
    private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField]
    private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    public static Rigidbody2D m_Rigidbody2D;
    private bool doublejump = false;
    private bool m_FacingRight = true;
    private float rotateSpeed = 1f;
    public static float previousVelocity;
    Vector3 birdRotation = Vector3.zero;

    //This is an array of all the audio source components that are added to this GameObject.
    AudioSource[] audioSources;
    AudioSource crouchSound;
    AudioSource jumpSound;

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        audioSources = GetComponents<AudioSource>();
        crouchSound = audioSources[0];
        jumpSound = audioSources[1];
    }
    private void FixedUpdate()
    {
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_Anim.SetBool("Ground", m_Grounded);
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.x);
        // If player is not moving, stop background.
        if (m_Rigidbody2D.velocity.x < 1)
        {
            GameObject.Find("Background").GetComponent<ScrollScript>().scroll = false;
            //m_Anim.SetBool("Idle", true);
        }
        else
        {
            GameObject.Find("Background").GetComponent<ScrollScript>().scroll = true;
           // m_Anim.SetBool("Idle", false);
        }

        Movement();
    }
    private void Movement()
    {
        switch (RunnerManager.manager.currentState)
        {
            case GameState.Begin:
                m_Anim.SetFloat("Speed", Mathf.Abs(m_MaxSpeed));
                    // m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed, previousVelocity);
                m_Rigidbody2D.velocity = new Vector2(m_MaxSpeed, m_Rigidbody2D.velocity.y);
                break;
            case GameState.Pause:
                m_Anim.SetFloat("Speed", 0);
                if(m_Rigidbody2D.velocity.x > 1)
                previousVelocity = m_Rigidbody2D.velocity.y;
                m_Rigidbody2D.velocity = new Vector2(0, .9f);
                break;

            case GameState.Died:
                m_Anim.SetFloat("Speed", 0);
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
                break;
        }
        
    }

    public void Move(bool roll, bool jump)
    {
        // Set whether or not the character is crouching in the animator
        m_Anim.SetBool("StartRoll", roll);
        m_Anim.SetBool("Roll", roll);
        //If player is rolling either becouse jumping or pressing crouch, switch colliders from box to the circle and vise-versa
        if ((roll || !m_Grounded) )
        {
            gameObject.GetComponentInChildren<CircleCollider2D>().enabled = true;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = false;
        }
        else if(m_Grounded) {
            //crouchSound.Play();
            gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider2D>().enabled = true;

        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // The Speed animator parameter is set to the absolute value of the horizontal input.

        }
        if (jump)
        {
            if (m_Grounded && m_Anim.GetBool("Ground"))
            {
                jumpSound.Play();
                doublejump = true;
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.velocity = Vector2.zero;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
            else
            {
                if (doublejump)
                {
                    jumpSound.Play();
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                    doublejump = false;
                    m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                }
            }
        }
    }
    public void Fly()
    {
        m_Rigidbody2D.AddForce(new Vector2(0f, m_FlyForce));
    }
    public void Rotation()
    {
        birdRotation = new Vector3(0f, 0f, Mathf.Clamp(m_Rigidbody2D.velocity.y * 2f, -30f, 30f));
        this.transform.eulerAngles = birdRotation;
    }
    IEnumerator AddForce()
    {
        yield return new WaitForSeconds(0.1f);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void OnColliderEnter2D(Collider2D c)
    {
        m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
    }
}

