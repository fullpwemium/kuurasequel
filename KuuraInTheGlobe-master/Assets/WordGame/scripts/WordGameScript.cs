using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordGameScript : MonoBehaviour {

    //Variables used to initialize the game system
    public GameObject systemPrefab;
    private WordGameSystemScript system;

    //Three main states of the game
    private bool isWin;
    private bool isLose;
    private bool playable;

    //Variables that control the game states
    private int fails;
    private int corrects;
    private int tries;
    private int currentLevel = 0;
    private List<int> questionIndexes;
    private int lastIndex;              //Stores the last attempt's first question index here, so when if the level is restarted, the player wont be given the same question twice in a row

    //UI objects
    private Image buttonA;
    private Image buttonB;
    private Image buttonC;
    private Image star1;
    private Image star2;
    private Image star3;
    private Text questionText;
    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;
    public GameObject CatPanel;

    //Variables that contain level data and JSON stuff
    public List<TextAsset> questionList;
    private List<WordGameQuestionData> levels;
    private WordGameQuestionData questions;
    private WordGameQuestion currentQ;

    // Use this for initialization
    void Start() {
        //Initialize or fetch the game system that contains level data
        initSystem();

        //Initialize game state
        resetGameState();

        //Initialize containers and the questionText object
        questionIndexes = new List<int>();
        levels = new List<WordGameQuestionData>();
        questionText = GameObject.Find("QuestionText").GetComponent<Text>();

        //Initialize the game itself
        initGame();

    }
	
	// Update is called once per frame
	void Update () {
        if (isLose && playable)
        {
            gameOver();
        }

        if (isWin && playable)
        {
            gameWin();
        }
        if (Input.GetKeyDown("r"))      //For debugging purposes, has no functionality in mobile platform
        {
            resetLevel();
        }
		
	}

    private void initSystem()
    {
        if (!GameObject.Find("wordGameSystem"))
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<WordGameSystemScript>();
            //system.init();
        }
        else
        {
            system = GameObject.Find("wordGameSystem").GetComponent<WordGameSystemScript>();
        }
    }

    private void resetGameState()
    {
        if(currentLevel == 0)
        {
            currentLevel = system.getStartingLevel() - 1;
        }
        fails = 0;
        corrects = 0;
        tries = 0;
        isLose = false;
        isWin = false;
        playable = true;
        MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouse);
    }

    private void initGame()
    {
        initButtons();
        initStars();
        initQuestionList();
        initQuestionIndexes();
        updateCurrentQuestion();
        resetUI();
        updateButtonImages();
    }

    void addFail()
    {
        fails++;
        Debug.Log("Incorrect answer");
        if(fails >= 1)
        {
            isLose = true;
        }
    }

    void addCorrect()
    {
        corrects++;
        Debug.Log("Correct answer");
        if(corrects >= 3)
        {
            isWin = true;
        }
        else
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
        }
    }

    void gameOver()
    {
        Debug.Log("Game over");
        MusicPlayer.PlayMusic(MusicTrack.GameOverJingle);
        playable = false;
        GameOverPanel.SetActive(true);
    }

    void gameWin()
    {
        Debug.Log("You win!");
        playable = false;
        if (!system.isCatCollected(currentLevel))       //if first time clear
        {
            system.collectCat(currentLevel);
            system.clearlevel(currentLevel);
            activateCatPrompt();
        }
        else
        {
            activateWinPrompt();
        }
    }

    public void activateCatPrompt()
    {
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(true);
        CatPanel.SetActive(true);
    }

    public void activateWinPrompt()
    {
        CatPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(true);
        MusicPlayer.PlayMusic(MusicTrack.VictoryJingle);
    }

    public void onButtonClick(string buttonName)
    {
        if (playable)
        {
            tries++;
            if (isCorrectAnswer(buttonName))
            {
                addCorrect();
                updateStarImages(true);
            }
            else
            {
                addFail();
                updateStarImages(false);
            }
            if(!isLose && !isWin)
                updateCurrentQuestion();
        }
     
    }

    public void onGameOverClick(string buttonName)
    {
        if(buttonName == "r")
        {
            resetLevel();
        }
        else if(buttonName == "e")
        {
            exitMinigame();
        }
    }

    private bool isCorrectAnswer(string button)
    {
        if (currentQ.answer == button)
            return true;
        else
            return false;
    }

    public void loadQuestionData(string level)
    {
        questions = JsonUtility.FromJson<WordGameQuestionData>(questionList[Int32.Parse(level)-1].text);
        levels.Add(questions);
        Debug.Log("Level " + level + " questionData loaded!");
    }
    
    private void updateButtonImages()
    {
        buttonA.sprite = Resources.Load<Sprite>(currentQ.optionA);
        buttonB.sprite = Resources.Load<Sprite>(currentQ.optionB);
        buttonC.sprite = Resources.Load<Sprite>(currentQ.optionC);
    }

    private void updateStarImages(bool wasCorrect)
    {
        int cor = (wasCorrect) ? 1 : 0;

        /** Glorious switch-case to determine which star should be updated
         *  If cor = 1, the updated star will be yellow
         *  If cor = 0, the updated star will be crossed over
         */

        if (tries == 1)
        {
            switch (cor)
            {
                case 0:
                    star1.sprite = Resources.Load<Sprite>("UI/failstar");
                    break;
                case 1:
                    star1.sprite = Resources.Load<Sprite>("UI/ylwstar");
                    break;
            }
                
        }

        if (tries == 2)
        {
            switch (cor)
            {
                case 0:
                    star2.sprite = Resources.Load<Sprite>("UI/failstar");
                    break;
                case 1:
                    star2.sprite = Resources.Load<Sprite>("UI/ylwstar");
                    break;
            }
        }
        if (tries == 3)
        {
            switch (cor)
            {
                case 0:
                    star3.sprite = Resources.Load<Sprite>("UI/failstar");
                    break;
                case 1:
                    star3.sprite = Resources.Load<Sprite>("UI/ylwstar");
                    break;
            }
        }
    } 

    private void initQuestionList()
    {
        for (int i = 0; i < questionList.Capacity; i++)
            loadQuestionData((i+1).ToString());
    }

    private void initButtons()
    {
        buttonA = GameObject.Find("ButtonA/ButtonImageA").GetComponent<Image>();
        buttonB = GameObject.Find("ButtonB/ButtonImageB").GetComponent<Image>();
        buttonC = GameObject.Find("ButtonC/ButtonImageC").GetComponent<Image>();
    }

    private void initStars()
    {
        star1 = GameObject.Find("star1").GetComponent<Image>();
        star2 = GameObject.Find("star2").GetComponent<Image>();
        star3 = GameObject.Find("star3").GetComponent<Image>();
    }

    private void resetStars()
    {
        star1.sprite = Resources.Load<Sprite>("UI/blkstar");
        star2.sprite = Resources.Load<Sprite>("UI/blkstar");
        star3.sprite = Resources.Load<Sprite>("UI/blkstar");
    }

    private void updateCurrentQuestion()
    {
        currentQ = levels[currentLevel].questionData[getNextQIndex()];
        Debug.Log("Question data loaded for level " + (currentLevel + 1));
        questionText.text = currentQ.question;
        updateButtonImages();
    }

    private void initQuestionIndexes()
    {
        questionIndexes.Clear();
        System.Random rnd = new System.Random();
        while(questionIndexes.Count < 5)
        {
            int nextIndex = rnd.Next(5);                //nextIndex = 0 <= x < 5
            if (!questionIndexes.Contains(nextIndex))
            {
                if(questionIndexes.Count == 0 && nextIndex == lastIndex)
                {
                    Debug.Log("Rerolling index");
                }
                else questionIndexes.Add(nextIndex);
            }
        }
    }

    private int getNextQIndex()
    {
        if (questionIndexes.Count > 0)
        {
            int nextIndex = questionIndexes[0];
            lastIndex = nextIndex;
            questionIndexes.Remove(nextIndex);
            return nextIndex;
        }
        else Debug.LogError("No more questions available!");
        return -1;
    }

    private void resetLevel()
    {
        resetGameState();
        initQuestionIndexes();
        updateCurrentQuestion();
        updateButtonImages();
        resetUI();
        Debug.Log("Level restarted");
    }

    public void exitMinigame()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.dontBuy, 1);
        Debug.Log("Exiting quiz minigame");
        SceneManager.LoadScene("WordGameLevelSelect", LoadSceneMode.Single);
    }

    private void loadNextLevel()
    {
        if (currentLevel < levels.Capacity - 1)
        {
            currentLevel++;
            Debug.Log("Current level: " + currentLevel);
            resetLevel();
        }
        else Debug.Log("No next level exists");
    }

    private void resetUI()
    {
        resetStars();
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(false);
        CatPanel.SetActive(false);
    }
}