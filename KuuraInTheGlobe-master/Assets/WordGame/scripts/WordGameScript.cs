using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * This script is the main gameplay loop for the Word Quiz Minigame.
 */
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
    private int lastIndex;              //Stores the previous attempt's last question index here, so if the level is restarted, the player wont reveive the same question twice in a row

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
    public GameObject FinalPanel;

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
    /**
     *  Controls the game states and checks for the single debugging input
     */
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

    /**
     * Initializes the WordGameSystem or fetches it if it exists already
     */
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

    /**
     * Called after level restart or after beating a level
     * Resets every game state variable to their default value
     */
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
    
    /**
     * Initializes UI elements, questions and game state controllers
     */
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

    /**
     * Increments the fail count by 1 and changes the game state to LOSE afterwards.
     */
    void addFail()
    {
        fails++;
        Debug.Log("Incorrect answer");
        if(fails >= 1)
        {
            isLose = true;
        }
    }

    /**
     * Increments the count of correct answers by 1 and plays a sound effect. If the count >= 3, this function changes the game state to WIN afterwards.
     */
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

    /**
     * Game state that is triggered if the user's answer was incorrect. Prompts the user to play again or quit.
     */
    void gameOver()
    {
        Debug.Log("Game over");
        MusicPlayer.PlayMusic(MusicTrack.GameOverJingle);
        playable = false;
        GameOverPanel.SetActive(true);
    }

    /**
     * Game state that is triggered if the user's answer was correct.
     * Prompts the user that they have acquired a cat if not collected before.
     * Also prompts the user to play the next level or to quit.
     */
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
            system.clearlevel(currentLevel);
            activateWinPrompt();
        }
    }

    /**
     * Activates the prompt that informs the user they have acquired a cat.
     * Disables all the other prompts.
     */
    public void activateCatPrompt()
    {
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(false);
        FinalPanel.SetActive(false);
        CatPanel.SetActive(true);
    }

    /**
     * Activates the prompt that lets the user know they have cleared a level.
     * If the cleared level was the last level, the game activates a special prompt.
     * Disables all the other prompts.
     */
    public void activateWinPrompt()
    {
        if(currentLevel < 9)
        {
            CatPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            FinalPanel.SetActive(false);
            NextLevelPanel.SetActive(true);
            MusicPlayer.PlayMusic(MusicTrack.VictoryJingle);
        }
        else if(currentLevel == 9)
        {
            CatPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            NextLevelPanel.SetActive(false);
            FinalPanel.SetActive(true);
            MusicPlayer.PlayMusic(MusicTrack.VictoryJingle);
        }
        
    }

    /**
     * A function that buttons A, B & C call after being pressed by the user.
     * The parameter is the button's name and it is used to determine if the answer was correct or not and the UI is updated based on the evaluation.
     * Every click the number of tries is updated in order to keep track for the UI elements.
     * If the click doesn't result in LOSE or WIN states (if the game goes on) we load a new question for the user.
     */
    public void onButtonClick(string buttonName)
    {
        if (playable)
        {
            tries++;
            if (isCorrectAnswer(buttonName))    //if the answer was correct
            {
                addCorrect();
                updateStarImages(true);
            }
            else                                //if the answer was incorrect
            {
                addFail();
                updateStarImages(false);
            }
            if(!isLose && !isWin)
                updateCurrentQuestion();
        }
     
    }

    /**
     * If the gameOverPrompt is active, the buttons on the prompt call this function.
     * The user can either restart the level or quit to the level selection screen.
     */
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

    /**
     * A function that evaluates if the user's answer was correct.
     * Returns a boolean value.
     */
    private bool isCorrectAnswer(string button)
    {
        if (currentQ.answer == button)
            return true;
        else
            return false;
    }

    /**
     * Parses the JSON files into an list that contains all the question data.
     * The given parameter defines the question that needs to be loaded and added to the list.
     * level[0] = level 1 question data, level[5] = level 6 question data, etc.
     */
    public void loadQuestionData(string level)
    {
        questions = JsonUtility.FromJson<WordGameQuestionData>(questionList[Int32.Parse(level)-1].text);
        levels.Add(questions);
        Debug.Log("Level " + level + " questionData loaded!");
    }
    
    /**
     * Reloads every buttons' images based on the current question and the options available.
     * Options are defined in every questions' JSON file.
     */
    private void updateButtonImages()
    {
        buttonA.sprite = Resources.Load<Sprite>(currentQ.optionA);
        buttonB.sprite = Resources.Load<Sprite>(currentQ.optionB);
        buttonC.sprite = Resources.Load<Sprite>(currentQ.optionC);
    }

    /**
     * Updates the stars based on the number of tries and if the player's answer was correct or not.
     * The star will turn from empty into yellow one if the answer was correct and to a crossed one if the answer was incorrect.
     */
    private void updateStarImages(bool wasCorrect)
    {
        int cor = (wasCorrect) ? 1 : 0;

        /** Glorious switch-case to determine which star should be updated
         *  If cor = 1, the updated star will be yellow
         *  If cor = 0, the updated star will be crossed over
         */

        if (tries == 1)         //if star 1 needs to be updated
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

        if (tries == 2)         //if star 2 needs to be updated
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
        if (tries == 3)         //if star 3 needs to be updated
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

    /**
     * A function that loads questions for all levels and calls another function that parses and adds the questions into a list.
     */
    private void initQuestionList()
    {
        for (int i = 0; i < questionList.Capacity; i++)
            loadQuestionData((i+1).ToString());
    }

    /**
     * Initializes all the buttons so that by referencing them we can alter the images that are displayed on the buttons.
     */
    private void initButtons()
    {
        buttonA = GameObject.Find("ButtonA/ButtonImageA").GetComponent<Image>();
        buttonB = GameObject.Find("ButtonB/ButtonImageB").GetComponent<Image>();
        buttonC = GameObject.Find("ButtonC/ButtonImageC").GetComponent<Image>();
    }

    /**
     * Initializes all the stars that represent the user's progress throughout the levels.
     */
    private void initStars()
    {
        star1 = GameObject.Find("star1").GetComponent<Image>();
        star2 = GameObject.Find("star2").GetComponent<Image>();
        star3 = GameObject.Find("star3").GetComponent<Image>();
    }

    /**
     * Resets each stars' images back to empty star.
     */
    private void resetStars()
    {
        star1.sprite = Resources.Load<Sprite>("UI/blkstar");
        star2.sprite = Resources.Load<Sprite>("UI/blkstar");
        star3.sprite = Resources.Load<Sprite>("UI/blkstar");
    }

    /**
     * Checks the current level index and loads the question data into the currentQ variable.
     * Updates the question text and the buttons that are used to represent the options to the user.
     */
    private void updateCurrentQuestion()
    {
        currentQ = levels[currentLevel].questionData[getNextQIndex()];
        Debug.Log("Question data loaded for level " + (currentLevel + 1));
        questionText.text = currentQ.question;
        updateButtonImages();
    }

    /**
     * Creates a list of random integers in range of 0 to 4 (5 numbers in total) and contains no dublicates.
     * Each level contains 5 possible questions and this list is used to determine in which order the questions are presented to the user.
     * This function also takes care that when a level is restarted, the user won't see the same question twice in a row.
     */
    private void initQuestionIndexes()
    {
        questionIndexes.Clear();
        System.Random rnd = new System.Random();
        while(questionIndexes.Count < 5)
        {
            int nextIndex = rnd.Next(5);                //nextIndex = 0 <= x < 5
            if (!questionIndexes.Contains(nextIndex))   //if the index is not already in the list
            {
                if(!(questionIndexes.Count == 0 && nextIndex == lastIndex))     //if the index is valid for the list
                {
                    questionIndexes.Add(nextIndex);
                }
            }
        }
    }

    /**
     * Returns the first integer from the questionIndexes list.
     */
    private int getNextQIndex()
    {
        if (questionIndexes.Count > 0)          //if the list is not empty
        {
            int nextIndex = questionIndexes[0];
            lastIndex = nextIndex;              //keeps track of the current question for the next reindexing of the questionList 
            questionIndexes.Remove(nextIndex);  //removes the returned value from the list
            return nextIndex;
        }
        else Debug.LogError("No more questions available!");        //this should not happen
        return -1;
    }

    /**
     * Resets the current level by reseting the game state, reindexing the question list and reseting the questions and buttons.
     */
    private void resetLevel()
    {
        resetGameState();
        initQuestionIndexes();
        updateCurrentQuestion();
        updateButtonImages();
        resetUI();
        Debug.Log("Level restarted");
    }

    /**
     * Returns the user to the levels select screen fo the quiz minigame.
     */
    public void exitMinigame()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.dontBuy, 1);
        Debug.Log("Exiting quiz minigame");
        SceneManager.LoadScene("WordGameLevelSelect", LoadSceneMode.Single);
    }

    /**
     * Increments the currentLevel variable up to 9 and "resets" the level which means that the game loads new questions and resets the game state and UI to represent the new level.
     */
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

    /**
     * Used to clear the prompt that is brought up after clearing the final level.
     * Return the player to the level select screen.
     */
    public void clearOK()
    {
        FinalPanel.SetActive(false);
        exitMinigame();
    }

    /**
     * Resets the stars back to "empty" and hides any prompt that could be activated.
     */
    private void resetUI()
    {
        resetStars();
        GameOverPanel.SetActive(false);
        NextLevelPanel.SetActive(false);
        CatPanel.SetActive(false);
        FinalPanel.SetActive(false);
    }
}