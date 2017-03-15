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
    private List<int> questionIndexes;

    private Button buttonA;
    private Button buttonB;
    private Button buttonC;
    private Text questionText;

    public List<TextAsset> questionList;
    private WordGameQuestionData questions;
    private WordGameQuestion currentQ;

    // Use this for initialization
    void Start() {
        fails = 0;
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
		
	}

    private void initGame()
    {
        initButtons();
        initQuestionList();
        initQuestionIndexes();
        updateCurrentQuestion();
        updateButtonImages();
    }

    void addFail()
    {
        fails++;
        Debug.Log("Incorrect answer");
        if(fails >= 3)
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
        Debug.Log("Shiaaat");
        playable = false;
        //TODO
        //Show gameover screen & retry buttton
    }

    void gameWin()
    {
        Debug.Log("Winnnn");
        playable = false;
        //show game win screen & next stage / quit buttons
    }

    public void onButtonClick(string buttonName)
    {
        //Debug.Log("Button " + buttonName + " clicked");
        //if button is correct
        if (isCorrectAnswer(buttonName))
        {
            addCorrect();
        }
        else
        {
            addFail();
        }

        if(playable)
            loadNewQuestion();
     
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
}