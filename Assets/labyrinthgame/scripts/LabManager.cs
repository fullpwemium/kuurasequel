using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LabManager : GameManager
{
    bool levelComplete;
	public static int cats;
	public int Coins;
	public static int score;

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

        if (LabyGameManager.manager.completedLevels.Contains(currentLevel) == false)
        {
            LabyGameManager.manager.completedLevels.Add(currentLevel);
        }


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
			Pisteet ();
        }
    }

	//Tähän alapuolelle sitte se tähtisysdemi

	public void Pisteet()
	{
        Debug.Log("bananaaa");

		if (score > 8) 
		{
			cats = 3;
			Debug.Log ("3 tähtee");
		}
		else if (score > 6) 
		{
			cats = 2;
			Debug.Log ("2 tähtee");
		}
		else if (score > 4) 
		{
			cats = 1;
			Debug.Log ("1 tähtee");
		}
		if (cats > LabManager.levelStars[LabManager.manager.currentLevel])
		{
			LabManager.levelStars[LabManager.manager.currentLevel] = cats;
		}
		else
		{

		}
	}
}