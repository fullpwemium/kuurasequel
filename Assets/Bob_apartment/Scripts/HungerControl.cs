using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HungerControl : MonoBehaviour {

    HappinessController hc1;
    public static System.DateTime currenttime;
    public static System.DateTime newtime;
    // Use this for initialization
    void Awake()
    {
        //We make sure that this doesn't get destroyed when it's loaded
        DontDestroyOnLoad(this);
        currenttime = System.DateTime.Now;
    }

	void Start ()
    {
   
	}
	
	// Update is called once per frame
	void Update ()
    {
        newtime = System.DateTime.Now;
	}
   
}
