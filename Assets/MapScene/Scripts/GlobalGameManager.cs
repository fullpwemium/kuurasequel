using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour
{
    //Do global functions
    public static GlobalGameManager GGM;
    public int gameSelectScene;
    public int[] gameScenes;

    public bool GreyHatOwned;
    public bool OrangeHatOwned;
    public bool RedHatOwned;
    public bool GreenHatOwned;
    public bool WhiteHatOwned;

    public bool GreyJacketOwned;
    public bool OrangeJacketOwned;
    public bool RedJacketOwned;
    public bool GreenJacketOwned;
    public bool WhiteJacketOwned;

    public bool GreyBootsOwned;
    public bool OrangeBootsOwned;
    public bool RedBootsOwned;
    public bool GreenBootsOwned;
    public bool WhiteBootsOwned;

    int currentGame;
    public List<int> completedGames;

    int[] MemoryGameStars = new int[200];

    public static int MagicDust;
    public static Text AllMagicDust;

    int[] RunnerStars;

    int LabyrinthStars;

    List<int> memoryGamecompletedLevels;

    List<int> MemoryGamecompletedLevels = new List<int>();

    List<int> RunnercompletedLevels = new List<int>();

    //Pelienomat

    //Mappi muuttujat
    float ukkoX = 0.0f;
    float ukkoY = 0.0f;

    //BWH:n omat muuttujat
    int[] bwhStars = new int[200];
    List<int> bwhcompletedLevels = new List<int>();
    List<int> completetlevels;

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

        //MagicDust = 50000;
        //PlayerPrefs.SetInt("Magic Dust ", MagicDust);

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
        //PlayerPrefs.DeleteAll();
//        Debug.Log("Kaikki tuhottu");

        //InsertScore(5,bwhStars, "banana", 10);
        haeData();            

        //MemoryGameLoad();
        //RunnerLoad();
        //bubbleWarehouseLoad();
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
        for (int i = 0; i <= 100; i++)
        {
            GameManager.levelStars[i] = PlayerPrefs.GetInt("stars" + i);
        }
        for (int i = 0; i <= 20; i++)
        {

            bwhcompletedLevels.Add(PlayerPrefs.GetInt("levels" + i));

            if (bwhcompletedLevels.Contains(i))
            {
                GameManager.manager.completedLevels.Add(i);
            }
        }
    }

    public void bubbleWarehouseSave()
    {
        bwhStars = GameManager.levelStars;
        bwhcompletedLevels = GameManager.manager.completedLevels;


        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("stars" + i, bwhStars[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (GameManager.manager.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("levels" + i, i);
                Debug.Log(bwhcompletedLevels[i]);
            }
        }
    }

    public void MemoryGameSave()
    {
        Debug.Log("aloitetaan tallennus memorygame"); 
        //laitetaan tähän vielä memorystars sijoitus.
        MemoryGamecompletedLevels = MemoryGameLevelSelecterLimitter.completedLevels;

        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("memorystars" + i, MemoryGameStars[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (MemoryGameLevelSelecterLimitter.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("memorylevels" + i, i);
                //Debug.Log(bwhcompletedLevels[i]);
            }
        }
    }

    public void MemoryGameLoad()
    {
        Debug.Log("ladataan MemoryGame");
        for (int i = 0; i <= 100; i++)
        {
            GameManager.levelStars[i] = PlayerPrefs.GetInt("memorystars" + i);
        }
        for (int i = 0; i <= 10; i++)
        {

            MemoryGamecompletedLevels.Add(PlayerPrefs.GetInt("memorylevels" + i));

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
        for (int i = 0; i <= 100; i++)
        {
            GameManager.levelStars[i] = PlayerPrefs.GetInt("runnerstars" + i);
        }
        for (int i = 0; i <= 5; i++)
        {

            RunnercompletedLevels.Add(PlayerPrefs.GetInt("runnerlevels" + i));

            //RunnerManager.manager.completedLevels.Add(i);
            //Debug.Log((MemoryGameLevelSelecterLimitter.completedLevels));

            //if (MemoryGamecompletedLevels.Contains(i))
            if (RunnercompletedLevels.Contains(i))
            {
//                RunnerManager.manager.completedLevels.Add(i);
                RunnerLevelSelectLimiter.completedLevels.Add(i);
//                RunnerLevelSelectLimitter.completedLevels.Add(i);
            }
        }
    }

    public void RunnerSave()
    {
        RunnerStars = GameManager.levelStars;
        RunnercompletedLevels = RunnerManager.manager.completedLevels;

        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("runnerstars" + i, RunnerStars[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (RunnerManager.manager.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("runnerlevels" + i, i);
                Debug.Log(RunnercompletedLevels[i]);
            }
        }
    }

    public void LabyrinthSave()
    {
        LabyrinthStars = LabManager.cats;
    }

    public void LabyrinthLoad()
    {

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

    //--------------------------------------------------------------------------------------------------------------------------------------------
}
