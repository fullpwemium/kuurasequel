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
    public static int[] levelCats = new int[200];

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

        if (LabyGameManager.manager.completedLevels.Contains(LabyGameManager.manager.currentLevel) == false)
        {
            
            LabyGameManager.manager.completedLevels.Add(LabyGameManager.manager.currentLevel);
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
        
		if (Collector.Coins >= 8) 
		{
			cats = 3;
			Debug.Log ("3 tähtee");
		}
		else if (Collector.Coins >= 6) 
		{
			cats = 2;
			Debug.Log ("2 tähtee");
		}
		else if (Collector.Coins >= 4) 
		{
			cats = 1;
			Debug.Log ("1 tähtee");
		}
        Debug.Log("kissat: " + cats);
		if (cats > LabManager.levelCats[LabyGameManager.manager.currentLevel])
		{
			LabManager.levelCats[LabyGameManager.manager.currentLevel] = cats;
            Debug.Log("levelikissat: " + LabManager.levelCats[0]);
		}
		else
		{

		}
	}
}