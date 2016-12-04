﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
    [SerializeField]
    private bool doublePoints;
    [SerializeField]
    private bool safeMode;
    [SerializeField]
    private bool magnet;
    private bool powerupActive;
    public float powerLengthCounter;
    private float normalPoints;
    private GameObject doublePointsText;

    void Update()
    {
    }

    void Start()
    {
        //if (GameObject.Find("RunnerManager"))
        //{
            normalPoints = RunnerManager.manager.PointsPerCoin;
            GameObject.Find("/Canvas/DoublePoints").GetComponent<Text>().enabled = false;
        //}
        
    }

    //Starts powerup from PowerUp script.
    public void ActivatePowerup(bool points, bool safemode, bool Magnet, float time)
    {
        doublePoints = points;
        safeMode = safemode;
        magnet = Magnet;
        powerLengthCounter = time;
        powerupActive = true;
        if (points)
            StartCoroutine(StartPointsPowerUp(time));
        if (safemode)
            StartCoroutine(StartSafeModePowerUp(time));
        if (Magnet)
            StartCoroutine(StartMagnetPowerUp(time));
    }

    public bool SafeMode
    {
        get { return safeMode; }
    }

    IEnumerator StartPointsPowerUp(float PowerupTime) //Assing double of the normal coins
    {

        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.catHeadCollected, 1);

        while (PowerupTime > 0 )
        {
            GameObject.Find("/Canvas/DoublePoints").GetComponent<Text>().enabled = true;
            if(RunnerManager.manager.currentState == GameState.Begin)
                PowerupTime -= Time.deltaTime;
            else if (RunnerManager.manager.currentState == GameState.Died)      //Asetetaan tuplausvoima tauolle
                PowerupTime = 0;
            RunnerManager.manager.PointsPerCoin = normalPoints * 2;     //Tuplataan kerätyt kolikot.
           // Debug.Log("PointsPowerUp: " + PowerupTime + " PPC" +RunnerManager.manager.PointsPerCoin + "Normalpoints  " + normalPoints);
            yield return PowerupTime;
        }
        GameObject.Find("/Canvas/DoublePoints").GetComponent<Text>().enabled = false;
        
        doublePoints = false;
        RunnerManager.manager.PointsPerCoin = normalPoints;
        yield return null;

    }

    IEnumerator StartSafeModePowerUp( float PowerupTime)    //Enable and disable colliders and particle effects for safemode
    {

        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.catHeadCollected, 1);

        while (PowerupTime >0 )
        {
            if (RunnerManager.manager.currentState == GameState.Begin)
                PowerupTime -= Time.deltaTime;
            else if (RunnerManager.manager.currentState == GameState.Died)
                PowerupTime = 0;
            GameObject.Find("SafeCollider").GetComponent<CircleCollider2D>().enabled = true;
            GameObject.Find("SafeCollider").GetComponent<EllipsoidParticleEmitter>().enabled = true;
            GameObject.Find("SafeCollider").GetComponent<ParticleRenderer>().enabled = true;
           // Debug.Log("SafeModePowerUp: " + PowerupTime);
            yield return PowerupTime;
        }
        safeMode = false;
        GameObject.Find("SafeCollider").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("SafeCollider").GetComponent<EllipsoidParticleEmitter>().enabled = false;
        GameObject.Find("SafeCollider").GetComponent<ParticleRenderer>().enabled = false;
        GameObject.Find("SafeCollider").GetComponent<EllipsoidParticleEmitter>().ClearParticles();
        yield return null;

    }

    IEnumerator StartMagnetPowerUp( float PowerupTime) // Starts magnet effector
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.keyCollected, 1);

        while (PowerupTime > 0)
        {
            if (RunnerManager.manager.currentState == GameState.Begin)
                PowerupTime -= Time.deltaTime;
            else if (RunnerManager.manager.currentState == GameState.Died)      //Asetetaan mangeettivoima tauolle
                PowerupTime = 0;
            GameObject.FindGameObjectWithTag("Magnet").GetComponent<PointEffector2D>().enabled = true;      //Ongelmia kenttävalikossa
            // Debug.Log("MagnetPowerUp" + PowerupTime);
            yield return PowerupTime;
        }
        GameObject.FindGameObjectWithTag("Magnet").GetComponent<PointEffector2D>().enabled = false;

        magnet = false;
        yield return null;

    }

}


