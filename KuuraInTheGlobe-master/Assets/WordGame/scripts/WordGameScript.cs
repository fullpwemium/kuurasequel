using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordGameScript : MonoBehaviour {

    private bool isWin;
    private bool isLose;
    private bool playable;

    private int fails;
    private int corrects;
    private int tries;
    private List<int> questionIndexes;

    private Button buttonA;
    private Button buttonB;
    private Button buttonC;
    private Image star1;
    private Image star2;
    private Image star3;
    private Text questionText;

    public List<TextAsset> questionList;
    private WordGameQuestionData questions;
    private WordGameQuestion currentQ;

    // Use this for initialization
    void Start() {
        fails = 0;
        corrects = 0;
        tries = 0;
        isLose = false;
        isWin = false;
        playable = true;

        questionText = GameObject.Find("QuestionText").GetComponent<Text>();

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
        if (Input.GetKeyDown("r"))
        {
            resetLevel();
        }
		
	}

    private void initGame()
    {
        initButtons();
        initStars();
        initQuestionList();
        initQuestionIndexes();
        updateCurrentQuestion();
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
    }

    void gameOver()
    {
        Debug.Log("Game over");
        playable = false;
        //TODO
        //Show gameover screen & retry buttton
    }

    void gameWin()
    {
        Debug.Log("You win!");
        playable = false;
        //show game win screen & next stage / quit buttons
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
                loadNewQuestion();
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
        questions = JsonUtility.FromJson<WordGameQuestionData>(questionList[0].text);
        Debug.Log("Level " + level + " questionData loaded!");
    }

    private void updateButtonImages()
    {
        buttonA.image.sprite = Resources.Load<Sprite>(currentQ.optionA);
        buttonB.image.sprite = Resources.Load<Sprite>(currentQ.optionB);
        buttonC.image.sprite = Resources.Load<Sprite>(currentQ.optionC);
        //buttonA.image.sprite = Resources.Load<Sprite>("bluecat");
    }

    private void updateStarImages(bool wasCorrect)
    {
        int cor;

        if (wasCorrect)
            cor = 1;
        else cor = 0;

        if (tries == 1)
        {
            switch (cor)
            {
                case 0:
                    star1.sprite = Resources.Load<Sprite>("failstar");
                    break;
                case 1:
                    star1.sprite = Resources.Load<Sprite>("ylwstar");
                    break;
            }
                
        }

        if (tries == 2)
        {
            switch (cor)
            {
                case 0:
                    star2.sprite = Resources.Load<Sprite>("failstar");
                    break;
                case 1:
                    star2.sprite = Resources.Load<Sprite>("ylwstar");
                    break;
            }
        }
        if (tries == 3)
        {
            switch (cor)
            {
                case 0:
                    star3.sprite = Resources.Load<Sprite>("failstar");
                    break;
                case 1:
                    star3.sprite = Resources.Load<Sprite>("ylwstar");
                    break;
            }
        }
    } 

    private void initQuestionList()
    {
        for (int i = 0; i < questionList.Capacity; i++)
            loadQuestionData(i+1.ToString());
    }

    private void initButtons()
    {
        buttonA = GameObject.Find("ButtonA").GetComponent<Button>();
        buttonB = GameObject.Find("ButtonB").GetComponent<Button>();
        buttonC = GameObject.Find("ButtonC").GetComponent<Button>();
    }

    private void initStars()
    {
        star1 = GameObject.Find("star1").GetComponent<Image>();
        star2 = GameObject.Find("star2").GetComponent<Image>();
        star3 = GameObject.Find("star3").GetComponent<Image>();
    }

    private void resetStars()
    {
        star1.sprite = Resources.Load<Sprite>("blkstar");
        star2.sprite = Resources.Load<Sprite>("blkstar");
        star3.sprite = Resources.Load<Sprite>("blkstar");
    }

    private void updateCurrentQuestion()
    {
        currentQ = questions.questionData[getNextQIndex()];
        questionText.text = currentQ.question;
        updateButtonImages();
    }

    private void initQuestionIndexes()
    {
        questionIndexes = new List<int>();
        System.Random rnd = new System.Random();
        while(questionIndexes.Count < 5)
        {
            int nextIndex = rnd.Next(5);                //nextIndex = 0 <= x < 5
            if (!questionIndexes.Contains(nextIndex))
            {
                questionIndexes.Add(nextIndex);
            }
        }
    }

    private int getNextQIndex()
    {
        if (questionIndexes.Count > 0)
        {
            int nextIndex = questionIndexes[0];
            questionIndexes.Remove(nextIndex);
            return nextIndex;
        }
        else Debug.LogError("No more questions available!");
        return -1;
    }

    private void loadNewQuestion()
    {
        updateCurrentQuestion();
    }

    private void resetLevel()
    {
        tries = 0;
        fails = 0;
        corrects = 0;
        isWin = false;
        isLose = false;
        playable = true;
        initQuestionIndexes();
        updateCurrentQuestion();
        updateButtonImages();
        resetStars();
        Debug.Log("Level restarted");
    }
}