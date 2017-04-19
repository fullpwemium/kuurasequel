using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*
 * GlobalGameManager
 * Manager class that holds and handles relevant game data such as dust, collected cats, among other things
*/

public class GlobalGameManager : MonoBehaviour
{
    //Do global functions
    public static GlobalGameManager GGM;    //Kun GGM lisätty koodiin, niin voidaan viitata Managerin ei-staattisin funktioihin.
    public int gameSelectScene;
    public int[] gameScenes;

    public bool GreyHatOwned;
    public bool OrangeHatOwned;
    public bool RedHatOwned;
    public bool GreenHatOwned;
    public bool WhiteHatOwned;
    public bool BlueHatOwned;

    public bool GreyJacketOwned;
    public bool OrangeJacketOwned;
    public bool RedJacketOwned;
    public bool GreenJacketOwned;
    public bool WhiteJacketOwned;
    public bool BlueJacketOwned;

    public bool GreyBootsOwned;
    public bool OrangeBootsOwned;
    public bool RedBootsOwned;
    public bool GreenBootsOwned;
    public bool WhiteBootsOwned;
    public bool BlueBootsOwned;

    public bool GreyGlassesOwned;
    public bool OrangeGlassesOwned;
    public bool RedGlassesOwned;
    public bool GreenGlassesOwned;
    public bool WhiteGlassesOwned;
    public bool BlueGlassesOwned;

    public string currentScene;

    int currentGame;
    public List<int> completedGames;


    public static int MagicDust;
    public static Text AllMagicDust;

    int[] RunnerStars;

    int[] LabyrinthStars;

    List<int> memoryGamecompletedLevels;

    //How many cutscenes the player has seen from each world;
	public int rocketGameCutscenesWatched = 0;
	public int wordQuizCutscenesWatched = 0;
    public int differenceCutscenesWatched = 0;

    //Singleton check
    public void Awake()
    {
        if (GGM == null)
        {
            DontDestroyOnLoad(gameObject);
            GGM = this;            
        }
        else if (GGM != this)
        {
            Destroy(gameObject);
        }

        MagicDust = PlayerPrefs.GetInt("Magic Dust "); //Ladataan kerätyt dustit

        //GameObject.FindGameObjectWithTag("MagicDust").GetComponent<Text>().text = MagicDust.ToString();

        if (GameObject.Find("MagicDust"))
        {
            AllMagicDust = GameObject.Find("MagicDust").GetComponent<Text>();
            AllMagicDust.text = MagicDust.ToString("f0");
        }
    }

    void Start()
    {
        CutSceneLoad();
    }

    public void StartMapScene()
    {
        SceneManager.LoadScene("Overworld");
    }
	//---------------------------------------------------------------------------------------------
	// Functions to store bob's position on the world map
	//---------------------------------------------------------------------------------------------

    public string getPlayerPositionOnMap()
    {
		if (PlayerPrefs.HasKey ("BobPosition")) {
        	return PlayerPrefs.GetString("BobPosition");
		} else {
			return "BobApartment";
		}
    }

	public void setPlayerPositionOnMap ( string nodeName )
    {
		PlayerPrefs.SetString("BobPosition", nodeName );
    }

	//---------------------------------------------------------------------------------------------
	// Functions to store what levels have been cleared and what haven't
	//---------------------------------------------------------------------------------------------

	public int getNumberOfBeatenLevels ( string minigame ) {
		string key = minigame + "-levelsBeaten";
		if (PlayerPrefs.HasKey ( key )) {
			return PlayerPrefs.GetInt (key);
		} else {
			return 0;
		}
	} 

	public void setNumberOfBeatenLevels ( string minigame, int levels ) {
		Debug.Log ("Set cleared levels to " + levels + " in " + minigame);
		PlayerPrefs.SetInt (minigame + "-levelsBeaten", levels);
	} 

	//---------------------------------------------------------------------------------------------
	// Functions to store cat acquisition or other special flags for given levels in minigames
	//---------------------------------------------------------------------------------------------


	public bool hasCatBeenAcquiredForGivenLevel ( string minigame, int level ) {
		string key = minigame + "-catAcquiredFromLevel" + level;
		if (PlayerPrefs.HasKey ( key ) ) {
			// the comparison turns the returned value into a bool
			return PlayerPrefs.GetInt (key) == 1;
		} else {
			return false;
		}
	}

	public void setCatAcquisitionForGivenLevel ( string minigame, int level, int status ) {
		string key = minigame + "-catAcquiredFromLevel" + level;
		PlayerPrefs.SetInt (key, status);
	}

	//---------------------------------------------------------------------------------------------
	// Functions to store high score values for a given minigame
	//---------------------------------------------------------------------------------------------

	public float getHighscore ( string minigame ) {
		string key = minigame + "-highscore";
		if (PlayerPrefs.HasKey (key)) {
			return PlayerPrefs.GetFloat (key);
		} else {
			return 0f;
		}
	}

	public void setHighscore ( string minigame, float value ) {
		string key = minigame + "-highscore";
		PlayerPrefs.SetFloat ( key, value );
	}

	//---------------------------------------------------------------------------------------------

    public void CutSceneSave()
    {

		PlayerPrefs.SetInt("rocketGameCutscenesWatched", rocketGameCutscenesWatched);
		PlayerPrefs.SetInt("wordQuizCutscenesWatched", wordQuizCutscenesWatched );
        PlayerPrefs.SetInt("differenceCutscenesWatched", differenceCutscenesWatched);
    }
    public void CutSceneLoad()
    {
		rocketGameCutscenesWatched = PlayerPrefs.GetInt("rocketGameCutscenesWatched");
		wordQuizCutscenesWatched = PlayerPrefs.GetInt("wordQuizCutscenesWatched");
        differenceCutscenesWatched = PlayerPrefs.GetInt("differenceCutscenesWatched");
    }
	//---------------------------------------------------------------------------------------------

    //Makes owning a specific hat true or false
    public void ShopSaveGreyHatOwned(bool value)
    {
        GreyHatOwned = value;
        PlayerPrefs.SetInt("greyHatOwned", value ? 1 : 0);
    }

    public void ShopSaveOrangeHatOwned(bool value)
    {
        OrangeHatOwned = value;
        PlayerPrefs.SetInt("orangeHatOwned", value ? 1 : 0);
    }

    public void ShopSaveRedHatOwned(bool value)
    {
        RedHatOwned = value;
        PlayerPrefs.SetInt("redHatOwned", value ? 1 : 0);
    }

    public void ShopSaveGreenHatOwned(bool value)
    {
        GreenHatOwned = value;
        PlayerPrefs.SetInt("greenHatOwned", value ? 1 : 0);
    }

    public void ShopSaveWhiteHatOwned(bool value)
    {
        WhiteHatOwned = value;
        PlayerPrefs.SetInt("whiteHatOwned", value ? 1 : 0);
    }

    public void ShopSaveBlueHatOwned(bool value)
    {
        BlueHatOwned = value;
        PlayerPrefs.SetInt("blueHatOwned", value ? 1 : 0);
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------

    public void ShopSaveGreyJacketOwned(bool value)
    {
        GreyJacketOwned = value;
        PlayerPrefs.SetInt("greyJacketOwned", value ? 1 : 0);
    }

    public void ShopSaveOrangeJacketOwned(bool value)
    {
        OrangeJacketOwned = value;
        PlayerPrefs.SetInt("orangeJacketOwned", value ? 1 : 0);
    }

    public void ShopSaveRedJacketOwned(bool value)
    {
        RedJacketOwned = value;
        PlayerPrefs.SetInt("redJacketOwned", value ? 1 : 0);
    }

    public void ShopSaveGreenJacketOwned(bool value)
    {
        GreenJacketOwned = value;
        PlayerPrefs.SetInt("greenJacketOwned", value ? 1 : 0);
    }

    public void ShopSaveWhiteJacketOwned(bool value)
    {
        WhiteJacketOwned = value;
        PlayerPrefs.SetInt("whiteJacketOwned", value ? 1 : 0);
    }

    public void ShopSaveBlueJacketOwned(bool value)
    {
        BlueJacketOwned = value;
        PlayerPrefs.SetInt("blueJacketOwned", value ? 1 : 0);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------

    public void ShopSaveGreyBootsOwned(bool value)
    {
        GreyBootsOwned = value;
        PlayerPrefs.SetInt("greyBootsOwned", value ? 1 : 0);
    }

    public void ShopSaveOrangeBootsOwned(bool value)
    {
        OrangeBootsOwned = value;
        PlayerPrefs.SetInt("orangeBootsOwned", value ? 1 : 0);
    }

    public void ShopSaveRedBootsOwned(bool value)
    {
        RedBootsOwned = value;
        PlayerPrefs.SetInt("redBootsOwned", value ? 1 : 0);
    }

    public void ShopSaveGreenBootsOwned(bool value)
    {
        GreenBootsOwned = value;
        PlayerPrefs.SetInt("greenBootsOwned", value ? 1 : 0);
    }

    public void ShopSaveWhiteBootsOwned(bool value)
    {
        WhiteBootsOwned = value;
        PlayerPrefs.SetInt("whiteBootsOwned", value ? 1 : 0);
    }

    public void ShopSaveBlueBootsOwned(bool value)
    {
        BlueBootsOwned = value;
        PlayerPrefs.SetInt("blueBootsOwned", value ? 1 : 0);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------

    public void ShopSaveGreyGlassesOwned(bool value)
    {
        GreyGlassesOwned = value;
        PlayerPrefs.SetInt("greyGlassesOwned", value ? 1 : 0);
    }

    public void ShopSaveOrangeGlassesOwned(bool value)
    {
        OrangeGlassesOwned = value;
        PlayerPrefs.SetInt("orangeGlassesOwned", value ? 1 : 0);
    }

    public void ShopSaveRedGlassesOwned(bool value)
    {
        RedGlassesOwned = value;
        PlayerPrefs.SetInt("redGlassesOwned", value ? 1 : 0);
    }

    public void ShopSaveGreenGlassesOwned(bool value)
    {
        GreenGlassesOwned = value;
        PlayerPrefs.SetInt("greenGlassesOwned", value ? 1 : 0);
    }

    public void ShopSaveWhiteGlassesOwned(bool value)
    {
        WhiteGlassesOwned = value;
        PlayerPrefs.SetInt("whiteGlassesOwned", value ? 1 : 0);
    }

    public void ShopSaveBlueGlassesOwned(bool value)
    {
        BlueGlassesOwned = value;
        PlayerPrefs.SetInt("blueGlassesOwned", value ? 1 : 0);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------
}
