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

    private LabyrinthUI winningUI;

    public GameObject Player;

    //Singleton check
    protected override void Awake()
    {

        //winningUI = GameObject.Find("UI").GetComponent<LabyrinthUI>();
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

        MusicPlayer.PlayMusic(MusicTrack.VictoryJingle);
        if (LabyGameManager.manager.completedLevels.Contains(LabyGameManager.manager.currentLevel) == false)
        {
            LabyGameManager.manager.completedLevels.Add(LabyGameManager.manager.currentLevel);
        }

        //        winningUI.TextSwitcher(true);     //Aktivoidaan labyrinttikentän voittamispaneeli, tällä hetkellä vasta
        //LabPuzzleLevel0:ssa. Samanlainen systeemi kuin muistipelissä, mutta
        //jostain syystä ei toimi.

        //if (Player == null)
        //{

        //}
        //else
        //{
        //    Player.SetActive(false);
        //}

        GameObject.Find("UI").GetComponent<LabyrinthUI>().TextSwitcher(true);       //Voittamispaneeli toimii tällä koodilla

//        Time.timeScale = 0;       //Kun 0, niin aika pysähtyy. Kun 2, niin nopeus tuplaantuu

//                SceneManager.LoadScene("LabyrinthLevelSelect"); //Ladataan kenttävalikko



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
//            winningUI.TextSwitcher(true);
        }
    }

	//Tähän alapuolelle sitte se tähtisysdemi

	public void Pisteet()
	{
//        winningUI.TextSwitcher(true);
        
		if (Collector.Coins >= 8) 
		{
			cats = 3;
			Debug.Log ("3 tähtee");
            Collector.Coins = 0;
		}
		else if (Collector.Coins >= 6) 
		{
			cats = 2;
			Debug.Log ("2 tähtee");
            Collector.Coins = 0;
        }
        else if (Collector.Coins >= 4) 
		{
			cats = 1;
			Debug.Log ("1 tähtee");
            Collector.Coins = 0;
        }
        else
        {
            Collector.Coins = 0;
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