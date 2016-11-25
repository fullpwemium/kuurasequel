using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    public RunnerCollector collector;
    public bool m_Jump;
    private bool activeJetPack;
    private bool doublejump;
    public bool m_Crouch;

    public static bool doubleCancel;
    public static bool magnetCancel;

    AudioSource[] audioSources;
    AudioSource crouchSound;
    AudioSource jumpSound;

    private void Awake()
    {
        //collector = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<Collector> ();
        collector = gameObject.GetComponentInChildren<RunnerCollector>();
        m_Character = GetComponent<PlatformerCharacter2D>();

        audioSources = GetComponents<AudioSource>();
        crouchSound = audioSources[0];
        jumpSound = audioSources[1];

        MusicPlayer.PlayMusic(MusicTrack.WinterForestMarathon);
    }
    private void Update()
    {
        if (!collector.flyMode)
        {
            if (!m_Jump)
            {
                m_Jump = Input.GetKeyDown(KeyCode.Space);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
                m_Jump = false;
        }
        //  m_Crouch = Input.GetKey(KeyCode.LeftControl);
        if (!m_Crouch)
        {
            m_Crouch = Input.GetKeyDown(KeyCode.LeftControl);
            //crouchSound.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            m_Crouch = false;
        }
        //m_Crouch = CrossPlatformInputManager.GetButtonDown("Fire1");
        
    }
    private void FixedUpdate()
    {
        if (RunnerManager.manager.currentState == GameState.Begin)
        {
            if (!collector.flyMode)
            {
                m_Character.Move(m_Crouch, m_Jump);
                m_Jump = false;
            }
            if (collector.flyMode)
            {
                m_Character.Rotation();
                activeJetPack = Input.GetButton("Fire1");
                if (activeJetPack)
                {
                    m_Character.Fly();
                }
            }
        }
    }
    public void Jump()
    {
        m_Jump = true;
    }
    public void BeginCrouch()
    {
        crouchSound.Play();
        m_Crouch = true;   
    }
    public void StopCrouch()
    {
        m_Crouch = false;
    }
    public void Pause()
    {
        RunnerManager.manager.PlayerPause();

        //doubleCancel = true;
        //magnetCancel = true;
    }
}

