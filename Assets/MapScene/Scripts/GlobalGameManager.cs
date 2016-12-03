using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

    int[] MemoryGameStars = new int[200];

    public static int MagicDust;
    public static Text AllMagicDust;

    int[] RunnerStars;

    int[] LabyrinthStars;

    List<int> memoryGamecompletedLevels;

    List<int> MemoryGamecompletedLevels = new List<int>();

    List<int> RunnercompletedLevels = new List<int>();

    List<int> LabyrinthcompletedLevels = new List<int>();

    //Pelienomat

    //Mappi muuttujat
    float ukkoX = 0.0f;
    float ukkoY = 0.0f;

    //BWH:n omat muuttujat
    int[] bwhStars = new int[200];
    List<int> bwhcompletedLevels = new List<int>();
    List<int> completetlevels;

    //How many cutscenes the player has seen from each world;
    public int warehouseCutscenesWatched = 0;
    public int labyrinthCutscenesWatched = 0;
    public int memoryCutscenesWatched = 0;
    public int runnerCutscenesWatched = 0;

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

        //InsertScore(5,bwhStars, "banana", 10);
        haeData();

        MemoryGameLoad();
        RunnerLoad();
        bubbleWarehouseLoad();    //Tulee "NullReferenceException: Object reference not set to an instance of an object"
        LabyrinthLoad();          //Tulee "NullReferenceException: Object reference not set to an instance of an object"
        CutSceneLoad();
    }

    private static string url = "http://www.bellegames.net/tietokantakokeilu/db.php";

    private static string insertScript = "http://bellegames.net/tietokantakokeilu/kuurainsert.php";

    void haeData()
    {
        StartCoroutine("Result");

    }
    IEnumerator Result()
    {
        // WWW www = new WWW(url + "?p=" + Time.realtimeSinceStartup.ToString());​

        WWW www = new WWW(url);
        yield return www;

        //Debug.Log(www.text);
    }


    public static void InsertScore(int GoogleID, int[] StarCount, string Name, int HiScore)
    {
        WWWForm form = new WWWForm();
        form.AddField("GoogleID", GoogleID);
        for (int i = 0; i <= 15; i++)
        {
            form.AddField("StarCount" + i, StarCount[i]);
        }
        form.AddField("Name", Name);
        form.AddField("Hiscore", HiScore);

        //form.AddField("Name", PlayerPrefs.GetString("Name"));​
        WWW www = new WWW(insertScript, form);
        Debug.Log("sent!");
    }


    public void GoToGameSelect()
    {
        SceneManager.LoadScene(gameSelectScene);
    }

    public void StartGame(int gameIndex)
    {
        currentGame = gameIndex;
        SceneManager.LoadScene(gameScenes[gameIndex]);
    }

    public void CompleteCurrentGame()
    {
        completedGames.Add(currentGame);
    }

    public void StartMapScene()
    {
        SceneManager.LoadScene("Map2");
    }

    public void mappiLoad()
    {
        ukkoX = PlayerPrefs.GetFloat("ukkoX");
        ukkoY = PlayerPrefs.GetFloat("ukkoY");
    }

    public void mappiSave()
    {
        PlayerPrefs.SetFloat("ukkoX", ukkoX);
        PlayerPrefs.SetFloat("ukkoY", ukkoY);
    }

    public void bubbleWarehouseLoad()
    {
        Debug.Log("ladataan bubble ware house");
        for (int i = 0; i <= 100; i++)
        {
            ShelfGameManager.manager.levelStars[i] = PlayerPrefs.GetInt("stars" + i);
            //Debug.Log("Bubble ware house loaded stars = " + bwhcompletedLevels[i]);
        }
        if (ShelfGameManager.manager != null) { 
            for (int i = 0; i <= 20; i++)
            {

                bwhcompletedLevels.Add(PlayerPrefs.GetInt("levels" + i));
                //Debug.Log("Bubble ware house loaded levels = " + bwhcompletedLevels[i]);

                if (bwhcompletedLevels.Contains(i))
                {
                    ShelfGameManager.manager.completedLevels.Add(i); 
                    Debug.Log("leveli ladattu " + i);
                }
            }
        } else
        {
            Debug.Log("GameManager.manager = null");
        }
    }

    public void bubbleWarehouseSave()
    {
        Debug.Log("aloitetaan tallennus catch the items");
        bwhStars = ShelfGameManager.manager.levelStars;
        bwhcompletedLevels = ShelfGameManager.manager.completedLevels;


        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("stars" + i, bwhStars[i]);
            //Debug.Log("Bubble ware house saved stars = " + bwhcompletedLevels[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (ShelfGameManager.manager.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("levels" + i, i);
                //Debug.Log("Bubble ware house saved levels = " + bwhcompletedLevels[i]);
            }
        }
    }

    public void MemoryGameSave()
    {
        Debug.Log("aloitetaan tallennus memorygame");
        //MemoryGameStars = GlobalManager.memoryGameStars;
        MemoryGameStars = Storage.MemoryGameStars;
        MemoryGamecompletedLevels = MemoryGameLevelSelecterLimitter.completedLevels;

        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("memorystars" + i, MemoryGameStars[i]);
            //Debug.Log("Memory game saved stars = " + bwhcompletedLevels[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (MemoryGameLevelSelecterLimitter.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("memorylevels" + i, i);
                //Debug.Log("Memory game saved levels = " + MemoryGamecompletedLevels[i]);
            }
        }
    }

    public void MemoryGameLoad()
    {
        Debug.Log("ladataan MemoryGame");
        for (int i = 0; i <= 100; i++)
        {
            //GameManager.levelStars[i] = PlayerPrefs.GetInt("memorystars" + i);
            Storage.MemoryGameStars[i] = PlayerPrefs.GetInt("memorystars" + i);
            //GlobalManager.memoryGameStars[i] = PlayerPrefs.GetInt("memorystars" + i);
            //Debug.Log("Memory game loaded stars = " + bwhcompletedLevels[i]);
        }
        for (int i = 0; i <= 100; i++)
        {

            MemoryGamecompletedLevels.Add(PlayerPrefs.GetInt("memorylevels" + i));
            //Debug.Log("Memory game loaded levels = " + MemoryGamecompletedLevels[i]);

            //MemoryGameLevelSelecterLimitter.completedLevels.Add(i);
            //Debug.Log((MemoryGameLevelSelecterLimitter.completedLevels));

            if (MemoryGamecompletedLevels.Contains(i))
            {
                MemoryGameLevelSelecterLimitter.completedLevels.Add(i);
                Debug.Log("leveli ladattu " + i);
            }
        }
    }

    public void RunnerLoad()
    {
        Debug.Log("ladataan runner");
        for (int i = 0; i <= 20; i++)
        {
            //GameManager.levelStars[i] = PlayerPrefs.GetInt("runnerstars" + i);
            RunnerWinningPanel.runnerCats[i] = PlayerPrefs.GetInt("runnerstars" + i);
            //Debug.Log("Runner loaded stars = " + RunnercompletedLevels[i]);
        }
        for (int i = 0; i <= 20; i++)
        {

            RunnercompletedLevels.Add(PlayerPrefs.GetInt("runnerlevels" + i));
            Debug.Log("Runner loaded levels = " + RunnercompletedLevels[i]);

            //RunnerManager.manager.completedLevels.Add(i);
            //Debug.Log((MemoryGameLevelSelecterLimitter.completedLevels));

            //if (MemoryGamecompletedLevels.Contains(i))
            if (RunnercompletedLevels.Contains(i))
            {
//                RunnerManager.manager.completedLevels.Add(i);
                RunnerLevelSelectLimiter.completedLevels.Add(i);
                Debug.Log("leveli ladattu " + i);
                //                RunnerLevelSelectLimitter.completedLevels.Add(i);
            }
        }
    }

    public void RunnerSave()
    {
        Debug.Log("aloitetaan tallennus runner");
        //RunnerStars = GameManager.levelStars;

        RunnerStars = RunnerWinningPanel.runnerCats;
        RunnercompletedLevels = RunnerManager.manager.completedLevels;
        //RunnercompletedLevels = RunnerLevelSelectLimiter.completedLevels;

        for (int i = 0; i <= 20; i++)
        {
            PlayerPrefs.SetInt("runnerstars" + i, RunnerStars[i]);
            //Debug.Log("Runner saved stars = " + RunnercompletedLevels[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (RunnerManager.manager.completedLevels.Contains(i))
            //if (RunnerLevelSelectLimiter.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("runnerlevels" + i, i);
                //Debug.Log("Runner saved levels = " + RunnercompletedLevels[i]);
            }
        }
    }

    public void LabyrinthSave()
    {
        Debug.Log("aloitetaan tallennus labyrinth");
        ////LabyrinthStars = LabManager.cats;

        LabyrinthStars = LabManager.levelCats;
        LabyrinthcompletedLevels = LabyGameManager.manager.completedLevels;

        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("LabyrinthStars" + i, LabyrinthStars[i]);
            //Debug.Log("Labyrinth saved stars = " + LabyrinthcompletedLevels[i]);
        }
        for (int i = 0; i <= 100; i++)
        {
            if (LabyGameManager.manager.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("LabyrinthLevels" + i, i);
                //Debug.Log("Labyrinth saved levels = " + LabyrinthcompletedLevels[i]);
            }
        }
    }

    public void LabyrinthLoad()
    {
        Debug.Log("ladataan labyrinth");
        for (int i = 0; i <= 100; i++)
        {
            LabManager.levelCats[i] = PlayerPrefs.GetInt("LabyrinthStars" + i);
            //Debug.Log("Labyrinth loaded stars = " + LabyrinthcompletedLevels[i]);
        }
        if (LabyGameManager.manager != null)
        {
            for (int i = 0; i <= 100; i++)
            {

                LabyrinthcompletedLevels.Add(PlayerPrefs.GetInt("LabyrinthLevels" + i));
                //Debug.Log("Labyrinth loaded levels = " + LabyrinthcompletedLevels[i]);

                if (LabyrinthcompletedLevels.Contains(i))
                {
                    LabyGameManager.manager.completedLevels.Add(i);
                    Debug.Log("leveli ladattu " + i);
                }
            }
        } else
        {
            Debug.Log("LabyGameManager.manager = null");
        }
    }

    public void CutSceneSave()
    {
        PlayerPrefs.SetInt("warehouseCutscenesWatched", warehouseCutscenesWatched);
        PlayerPrefs.SetInt("labyrinthCutscenesWatched", labyrinthCutscenesWatched);
        PlayerPrefs.SetInt("memoryCutscenesWatched", memoryCutscenesWatched);
        PlayerPrefs.SetInt("runnerCutscenesWatched", runnerCutscenesWatched);
    }
    public void CutSceneLoad()
    {
        warehouseCutscenesWatched = PlayerPrefs.GetInt("warehouseCutscenesWatched");
        labyrinthCutscenesWatched = PlayerPrefs.GetInt("labyrinthCutscenesWatched");
        memoryCutscenesWatched = PlayerPrefs.GetInt("memoryCutscenesWatched");
        runnerCutscenesWatched = PlayerPrefs.GetInt("runnerCutscenesWatched");
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
