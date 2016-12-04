using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShelfGameManager: MonoBehaviour// : GameManager
{
	bool levelComplete;
	public Transform destroyPoint;
	public float xMinPoint, xMaxPoint;
	//public bool gyroOn = false;

	Transform desPoint;
    //static public Toggle gyroButton;

    public static ShelfGameManager manager;

    public int[] levelIndex;
    public List<int> completedLevels = new List<int>(100);
    public int currentLevel;
    public int levelSelectScene;
    public float catSpeedMultiplier = 1;
    public float spawnSpeedMultiplier = 1;
    public float extraTime = 10;
    public int kissaMultiplier = 0;
    public int brokenItemMultiplier = 1;
    public int stars;
    public int[] levelStars = new int[200];
    public float aika = 1f;
    public bool aikamuutettu = false;
    public int snowFlakeSpeedMultiplier = 7;

    public void Awake()
    {

        //MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouse);

        //Debug.Log("listener lisätty");
        /*
        GameObject gyro = GameObject.Find("GyroToggle");
		if(gyro == null)
			return;

		gyroButton = gyro.GetComponent<Toggle>();
        gyroButton.onValueChanged.AddListener((delegate { ShelfGameManager.GyroToggle(); }));
        
        if (ShelfGameManager.gyroOn == true)
        {
            gyroButton.isOn = true;
        }
        else
        {
            gyroButton.isOn = false;
        }
        */

        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);

            manager = this;
        }
        else if (manager != this )
        {
            Destroy(gameObject);
            Debug.Log("Destroy ShelfManager");
        }
    }

	public void PlayerWin()
	{
		if (completedLevels.Contains(currentLevel) == false)
		{
			completedLevels.Add(currentLevel);
            GlobalGameManager.GGM.bubbleWarehouseSave();
        }
        if (stars > levelStars[currentLevel])
        {
            levelStars[currentLevel] = stars;
        }
    }

    public virtual void PlayerLose()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void CheckForWin(bool hasKisse)
	{
		/*if (hasKisse)
		{
			PlayerWin();
		}*/
	}

	public void RestartLevel()
	{

        aikamuutettu = false;

        Scene scene = SceneManager.GetActiveScene();
        //Application.LoadLevel (Application.loadedLevel);
        //base.RestartLevel();
        //Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);

    }

	void OnLevelWasLoaded()
	{
		Time.timeScale = 1f;
	}
	public void LoadNextLevel()
	{

        //base.LoadNextLevel ();
        if (completedLevels.Contains(currentLevel) == true)
        {
            LoadLevel(currentLevel + 1);
        }
        else
        {
            //pistä joku popuppi tähän.
        }
	}

    /*
    static public void GyroToggle()
	{
        
        gyroButton = GameObject.Find ("GyroToggle").GetComponent<Toggle> ();
        
        if (gyroButton.isOn == true) 
		{
			gyroOn = true;
			Debug.Log ("Gyro Päällä");
		} 
		else if (gyroButton.isOn == false) 
		{
			gyroOn = false;
			Debug.Log ("Gyro Poissa Päältä");
		}
	}
    
	public bool ReturnToggle()
	{
		return gyroOn;
	}
    */

    public void LoadLevel(int levelToLoad)
    {
        //Add check to not go over array bounds
        //if (levelToLoad < levelIndex.Length)
        //{
        aikamuutettu = false;
        currentLevel = levelToLoad;
        Debug.Log(currentLevel);

        //            SceneManager.LoadScene("LoadScene");      //Ladataan tyhjä scene ennen varsinaisen kentän avaamista

        SceneManager.LoadScene("ShelfLevel1");
        //}
        if (currentLevel == 0)
        {
            catSpeedMultiplier = 0.5f;     //Määritellään kissojen nopeus.
            spawnSpeedMultiplier = 1.5f;        //Määritellään esineiden ilmestymisnopeus.
            extraTime = 21;     //Määritellään aikaraja. Kun 0, niin neljä sekuntia.
            kissaMultiplier = 0;        //Määritellään kissojen määrä. Kun 0, niin kaksi kissaa.
            brokenItemMultiplier = 1;       //Määritellään rikkoutuvien esineiden maksimi. Kun 1, niin kolmen rikotun jälkeen Game Over.
            snowFlakeSpeedMultiplier = 8;
        }
        else if (currentLevel == 1)
        {
            catSpeedMultiplier = 0.75f;
            spawnSpeedMultiplier = 4;
            extraTime = 21;
            kissaMultiplier = 0;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 2)
        {
            catSpeedMultiplier = 0.5f;
            spawnSpeedMultiplier = 3;
            extraTime = 21;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 3)
        {
            catSpeedMultiplier = 0.75f;
            spawnSpeedMultiplier = 4;
            extraTime = 21;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 4)
        {
            catSpeedMultiplier = 0.5f;
            spawnSpeedMultiplier = 9;
            extraTime = 21;
            kissaMultiplier = 2;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 5)
        {
            catSpeedMultiplier = 0.75f;
            spawnSpeedMultiplier = 4;
            extraTime = 21;
            kissaMultiplier = 2;
            brokenItemMultiplier = 1;
            snowFlakeSpeedMultiplier = 2;

        }
        else if (currentLevel == 6)
        {
            catSpeedMultiplier = 1F;
            spawnSpeedMultiplier = 9;
            extraTime = 21;
            kissaMultiplier = 0;
            brokenItemMultiplier = 2;

        }
        else if (currentLevel == 7)
        {
            catSpeedMultiplier = 1F;
            spawnSpeedMultiplier = 6;
            extraTime = 21;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;
            snowFlakeSpeedMultiplier = 2;

        }
        else if (currentLevel == 8)
        {
            catSpeedMultiplier = 1F;
            spawnSpeedMultiplier = 9;
            extraTime = 21;
            kissaMultiplier = 2;
            brokenItemMultiplier = 3;

        }
        else if (currentLevel == 9)
        {
            catSpeedMultiplier = 1.25f;
            spawnSpeedMultiplier = 9;
            extraTime = 21;
            kissaMultiplier = 1;
            brokenItemMultiplier = 3;

        }
        else if (currentLevel == 10)
        {
            catSpeedMultiplier = 1.25f;
            spawnSpeedMultiplier = 4;
            extraTime = 35;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 11)
        {
            catSpeedMultiplier = 1.5f;
            spawnSpeedMultiplier = 4;
            extraTime = 45;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 12)
        {
            catSpeedMultiplier = 1.5f;
            spawnSpeedMultiplier = 4;
            extraTime = 50;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 13)
        {
            catSpeedMultiplier = 1.5f;
            spawnSpeedMultiplier = 4;
            extraTime = 30;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 14)
        {
            catSpeedMultiplier = 1.5f;
            spawnSpeedMultiplier = 6;
            extraTime = 35;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 15)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 10;
            extraTime = 30;
            kissaMultiplier = 0;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 16)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 8;
            extraTime = 35;
            kissaMultiplier = 0;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 17)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 6;
            extraTime = 40;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 18)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 4;
            extraTime = 45;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 19)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 4;
            extraTime = 60;
            kissaMultiplier = 1;
            brokenItemMultiplier = 1;

        }
        else if (currentLevel == 20)
        {
            catSpeedMultiplier = 1.625f;
            spawnSpeedMultiplier = 6;
            extraTime = 20;
            kissaMultiplier = 7;
            brokenItemMultiplier = 1;
            snowFlakeSpeedMultiplier = 10;

        }

    }
    public void GoToMenu()
    {
        aikamuutettu = false;
        SceneManager.LoadScene(levelSelectScene);
    }
}