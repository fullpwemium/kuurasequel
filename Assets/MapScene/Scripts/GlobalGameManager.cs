using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GlobalGameManager : MonoBehaviour
{
    //Do global functions
    public static GlobalGameManager GGM;
    public int gameSelectScene;
    public int[] gameScenes;
    int currentGame;
    public List<int> completedGames;

    int[] MemoryGameStars;

    List<int> memoryGamecompletedLevels;

    List<int> MemoryGamecompletedLevels = new List<int>();

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
    }

    void Start()
    {
        //InsertScore(5,bwhStars, "banana", 10);
        haeData();
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
        SceneManager.LoadScene("map_scene");
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
        MemoryGameStars = GameManager.levelStars;
        MemoryGamecompletedLevels = MemoryGameLevelSelecterLimitter.completedLevels;
        MemoryGamecompletedLevels.Add(1);
        MemoryGamecompletedLevels.Add(2);


        for (int i = 0; i <= 100; i++)
        {
            PlayerPrefs.SetInt("stars" + i, MemoryGameStars[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (MemoryGameLevelSelecterLimitter.completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("memorylevels" + i, i);
                Debug.Log(bwhcompletedLevels[i]);
            }
        }
    }

    public void MemoryGameLoad()
    {
        for (int i = 0; i <= 100; i++)
        {
            GameManager.levelStars[i] = PlayerPrefs.GetInt("stars" + i);
        }
        for (int i = 0; i <= 5; i++)
        {

            MemoryGamecompletedLevels.Add(PlayerPrefs.GetInt("levels" + i));

            MemoryGameLevelSelecterLimitter.completedLevels.Add(i);
            Debug.Log((MemoryGameLevelSelecterLimitter.completedLevels));

            if (MemoryGamecompletedLevels.Contains(i))
            {
                MemoryGameLevelSelecterLimitter.completedLevels.Add(i);
            }
        }
    }
}
