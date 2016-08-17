using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LabManager : GameManager
{
    bool levelComplete;

    //Singleton check
    protected override void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        //Debug.Log("managero " + manager);
    }
    public override void PlayerWin()
    {
		
		SceneManager.LoadScene("LabyrinthLevelSelect");

       
    }
    public override void PlayerLose()
    {
        base.PlayerLose();
    }
    public override void CheckForWin(bool hasKisse)
    {
        if (hasKisse)
        {
            PlayerWin();
        }
    }
}