using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LabManager : GameManager
{
    bool levelComplete;
	public static int stars;
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
		if (score > 8) 
		{
			stars = 3;
			Debug.Log ("3 tähtee");
		}
		else if (score > 6) 
		{
			stars = 2;
			Debug.Log ("2 tähtee");
		}
		else if (score > 4) 
		{
			stars = 1;
			Debug.Log ("1 tähtee");
		}
		if (stars > LabManager.levelStars[LabManager.manager.currentLevel])
		{
			LabManager.levelStars[LabManager.manager.currentLevel] = stars;
		}
		else
		{

		}
	}
}