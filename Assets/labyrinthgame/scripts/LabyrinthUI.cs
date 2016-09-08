using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LabyrinthUI : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public GameObject hiutale1, hiutale2, hiutale3, hiutale4, hiutale5, hiutale6;
    GameObject hiutaleX, hiutaleY;
    public Text endText;
    public static bool GOPanel = false;
    public static int stars;

    GameObject[] lista;

    GameObject bling;
    Vector3 destination;
    Vector3 startPosition;
    float lerpStartTime;
    float timeStartedLerping;
    float timeTakenDuringLerp;
    bool moving;

    bool isPaused;




    // Use this for initialization
    void Start()
    {
        gameOverPanel.SetActive(GOPanel);
        pausePanel.SetActive(false);
        hiutale1.SetActive(false);
        hiutale2.SetActive(false);
        hiutale3.SetActive(false);


        //moving = false;
        //bling.transform.position = new Vector3(bling.transform.position.x, bling.transform.position.y, bling.transform.position.z);
        //destination = bling.transform.position;



        //if (ShelfGameManager.manager != null && ShelfGameManager.manager.currentLevel == 0)
        //{
        //    tutorialPanel.SetActive(true);
        //    Time.timeScale = 0f;
        //}
    }

    public void GameOverPanelToggle()
    {
        if (GOPanel == true)
        {

            gameOverPanel.SetActive(false);

            Time.timeScale = GameManager.aika;
        }
        else
        {
            GOPanel = true;
            gameOverPanel.SetActive(true);
            //Time.timeScale = 0f;
        }

    }

    void FixedUpdate()
    {
        if (moving)
        {
            gameOverPanel.SetActive(true);
            float timeSinceStarted = Time.time - lerpStartTime;
            float percentageComplete = timeSinceStarted / 1f;
            //Debug.Log(percentageComplete);
            gameOverPanel.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
            //Debug.Log(percentageComplete);
            if (percentageComplete >= 1.0f)
            {
                moving = false;
                //Time.timeScale = 0f;
            }
        }

    }

    public void Pause()
    {
        if (GOPanel)
        {

        }
        else
        {
            if (isPaused)
            {
                Time.timeScale = GameManager.aika;
                pausePanel.SetActive(false);
                tutorialPanel.SetActive(false);
                isPaused = false;

            }
            else if (isPaused == false)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
                isPaused = true;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        tutorialPanel.SetActive(false);
    }

    public void Levelselect()
    {
        ShelfGameManager.manager.GoToMenu();
    }

    //Switches text in gameoverpanel
    public void TextSwitcher(bool won)
    {

        GlobalGameManager.GGM.LabyrinthSave();
        if (won == false)
        {
            Debug.Log("ninjat on täällä");
            //StartCoroutine("slowDown");
            endText.text = "You Lost";
            StartLerping();
            destination = new Vector3(0, 9, 0);
            Debug.Log(destination);
            moving = true;
        }
        else if (won == true)
        {
            Debug.Log("ninjat on täällä");
            /*lista = FindObjectsOfType<GameObject>();
            for (int i = 0; i > lista.Length; i++)
            {
                lista[i].SetActive(false);
            }*/
            //StartCoroutine("slowDown");
            GOPanel = false;
            Score();
            StartLerping();
            destination = new Vector3(0, 9, 0);
            Debug.Log(destination);
            moving = true;

            StartCoroutine("hiutalerotatedelay");
            endText.text = "You WON!";
        }
    }

    void StartLerping()
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = gameOverPanel.transform.position;

    }

    IEnumerator slowDown()
    {
        Time.timeScale = 1f;
        for (int f = 0; f <= 49; f++)
        {

            Time.timeScale = Time.timeScale - 0.01f;
            float test = Time.timeScale;
            Debug.Log("hidastuu" + test);
            yield return null;
        }

    }



    IEnumerator hiutaleRotate()
    {
        GameObject hiutale, hiutaleSlotti;


        hiutale = hiutaleX;
        hiutaleSlotti = hiutaleY;



        hiutaleY.SetActive(false);
        hiutale.SetActive(true);

        for (int i = 0; i <= 5; i++)
        {

            hiutale.transform.Rotate(0, 0, 2);

            //Debug.Log("pyörii" + i);
            yield return 5;
        }
        for (int i = 0; i <= 10; i++)
        {
            hiutale.transform.Rotate(0, 0, -2);

            yield return 5;
        }
        for (int i = 0; i <= 5; i++)
        {
            hiutale.transform.Rotate(0, 0, 2);

            //Debug.Log("pyörii" + i);
            yield return 5;
        }
    }

    IEnumerator hiutalerotatedelay()
    {
        for (int i = 0; i <= 115; i++)
        {
            if (stars >= 1 && i == 71)
            {
                hiutaleX = hiutale1;
                hiutaleY = hiutale4;
                //BlingBling(bling1);
                //StartCoroutine("blingLerp");
                BlingScript.moving = true;
                StartCoroutine("hiutaleRotate");
            }
            else if (stars >= 2 && i == 90)
            {
                hiutaleX = hiutale3;
                hiutaleY = hiutale6;
                //BlingBling(bling2);
                StartCoroutine("hiutaleRotate");
            }
            else if (stars >= 3 && i == 110)
            {
                hiutaleX = hiutale2;
                hiutaleY = hiutale5;
                //BlingBling(bling3);
                StartCoroutine("hiutaleRotate");
            }
            yield return null;
        }

    }

    /*public void BlingBling(GameObject Glitterit)
    {
        bling = Glitterit;

        destination = new Vector3(bling.transform.position.x, bling.transform.position.y - 50, bling.transform.position.z);
        startPosition = new Vector3(bling.transform.position.x, bling.transform.position.y, bling.transform.position.z);

        float timeSinceStarted = Time.time - lerpStartTime;
        float percentageComplete = timeSinceStarted / 1.5f;
        Debug.Log(percentageComplete);
        bling.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
    }*/

    void Score()
    {
        if (Collector.Coins >= 8)
        {
            stars = 3;
        }
        else if (Collector.Coins >= 6)
        {
            stars = 2;

        }
        else if (Collector.Coins >= 4)
        {
            stars = 1;

        }

        //Debug.Log(GameManager.manager.currentLevel + "currentlevel");


        //if (stars > LabManager.levelCats[LabyGameManager.manager.currentLevel])
        //{
        //    LabManager.levelCats[LabyGameManager.manager.currentLevel] = stars;
        //    Debug.Log("levelikissat: " + LabManager.levelCats[0]);
        //}

        else
        {

        }
        //GameManager.levelStars[GameManager.manager.currentLevel] = stars;
        //GlobalGameManager.GGM.bubbleWarehouseSave();
        //Debug.Log(GameManager.levelStars[GameManager.manager.currentLevel] + "tahtienmaara");

        /*for (int i = 0; i<5; i++ )
        {
            Debug.Log(GameManager.levelStars[i]);
        }*/

        /*for (int i = 0; i <= stars; i++)
        {
            GameManager.levelStars[GameManager.manager.currentLevel * 3 + i] = 1;
            Debug.Log(GameManager.levelStars)
        }*/


    }

    /*IEnumerator blingLerp()
    {

        for (int i = 0; i <= 45; i++)
        {
            if (moving)
            {

                float timeSinceStarted = Time.time - lerpStartTime;
                float percentageComplete = timeSinceStarted / 1.5f;
                Debug.Log(percentageComplete);
                bling.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
                //Debug.Log(tausta.transform.position);
                if (percentageComplete >= 1.0f)
                {
                    moving = false;
                }
                return null;
            }

            return null;
        }

        return null;

    }*/
}

