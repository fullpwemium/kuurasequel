using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifferenceUI : MonoBehaviour
{
    public GameObject losingPanel;
    public GameObject winningPanel;
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public GameObject Cat1, Cat2;
    GameObject CatX, CatY;
    public Text winText;
    public Text loseText;
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
        Debug.Log("Start position = " + startPosition);
        //MusicPlayer.PlayMusic(MusicTrack.MysticCards);

        //gameOverPanel.SetActive(GOPanel);
        winningPanel.SetActive(GOPanel);
        losingPanel.SetActive(GOPanel);
        //winningPanel.SetActive(false);
        //losingPanel.SetActive(false);
        //pausePanel.SetActive(false);

        Cat1.SetActive(false);
    }

    public void GameOverPanelToggle()
    {
        if (GOPanel == true)
        {

            winningPanel.SetActive(false);
            losingPanel.SetActive(false);

            //Time.timeScale = GameManager.aika;
        }
        else
        {
            GOPanel = true;
            winningPanel.SetActive(true);
            losingPanel.SetActive(true);
            //Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameOverPanel.SetActive(true);
        float timeSinceStarted = Time.time - lerpStartTime;
        float percentageComplete = timeSinceStarted / 1f;
        //Debug.Log(percentageComplete);
        winningPanel.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
        losingPanel.transform.position = Vector3.Lerp(startPosition, destination, percentageComplete);
        //Debug.Log(percentageComplete);

        //Debug.Log(startPosition);


        if (percentageComplete >= 1.0f)
        {
            moving = false;
            //                Time.timeScale = 0f;
        }
    }

    public void TextSwitcher(bool won)      //Activates panel by winning or losing.
    {
        //GlobalGameManager.GGM.DifferenceSave();
        //DifferenceManager.manager.DifferenceSave();

        //gameOverPanel.SetActive(true);      //Setting gameOverPanel active and visible.

        if (won == false)
        {
            //StartCoroutine("slowDown");
            losingPanel.SetActive(true);
            loseText.text = "YOU LOSE!";
            StartLoseLerping();
            destination = new Vector3(0, 11, 0);
            Debug.Log(destination);
            moving = true;

            Debug.Log("Hävisit2");
        }
        else if (won == true)
        {
            //MusicPlayer.PlayMusic(MusicTrack.VictoryJingle);

            /*lista = FindObjectsOfType<GameObject>();
            for (int i = 0; i > lista.Length; i++)
            {
                lista[i].SetActive(false);
            }*/
            //StartCoroutine("slowDown");
            GOPanel = false;
            winningPanel.SetActive(true);
            Score();
            StartWinLerping();
            destination = new Vector3(0, 11, 0);    //Move panel in defined location.
            Debug.Log(destination);
            moving = true;

            StartCoroutine("CatRotateDelay");
            winText.text = "You WON!";
        }

        //DifferenceManager.manager.DifferenceSave();
    }

    void StartWinLerping()     //Animates moving panel.
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = winningPanel.transform.position;
        Debug.Log("StartWinLerping");
        Debug.Log("Start position = " + startPosition);
    }

    void StartLoseLerping()     //Animates moving panel.
    {
        moving = true;
        lerpStartTime = Time.time;
        startPosition = losingPanel.transform.position;
        Debug.Log("StartLoseLerping");
        Debug.Log("Start position = " + startPosition);
    }

    IEnumerator CatRotate()     //Animates winnable points/cat heads.
    {
        GameObject Cat, CatSlotti;

        Cat = CatX;
        CatSlotti = CatY;

        CatY.SetActive(false);
        Cat.SetActive(true);

        for (int i = 0; i <= 5; i++)
        {

            Cat.transform.Rotate(0, 0, 2);

            //Debug.Log("pyörii" + i);
            yield return 5;
        }
        for (int i = 0; i <= 10; i++)
        {
            Cat.transform.Rotate(0, 0, -2);

            yield return 5;
        }
        for (int i = 0; i <= 5; i++)
        {
            Cat.transform.Rotate(0, 0, 2);

            //Debug.Log("pyörii" + i);
            yield return 5;
        }
    }

    IEnumerator CatRotateDelay()    //Define animating to won points/cat heads.
    {
        for (int i = 0; i <= 115; i++)
        {
            if (stars >= 1 && i == 71)
            {
                CatX = Cat1;
                CatY = Cat2;
                //BlingBling(bling1);
                //StartCoroutine("blingLerp");
                //BlingScript.moving = true;
                StartCoroutine("CatRotate");
            }
            yield return null;
        }
    }

    void Score()
    {
        //if (TimeAndClicks.Mistakes == 0)
        //{
        //    stars = 1;
        //}

        if (FindingTimer.timeLeft > 0)
        {
            stars = 1;
        }

        //Replace old score with new better score.
        if (stars > DifferenceManager.levelCats[DifferenceManager.manager.currentLevel])
        {
            DifferenceManager.levelCats[DifferenceManager.manager.currentLevel] = stars;
            Debug.Log("levelikissat: " + DifferenceManager.levelCats[0]);

            DifferenceManager.manager.DifferenceSave();
        }
    }
}
