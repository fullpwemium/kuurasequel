using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject button;
    public Text dialogue;

    public string[] dialogueLines;

    public string currentScene = "Intro";
    public string sceneProgression = "main";

    private int currentLine = 0;
    private int endAtLine;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed; //How fast the text shows up, smaller is faster. Default is 0.02

    public string language = "Eng"; //Language (if different settings are made) should probably be set elsewhere

    // Use this for initialization
    void Start()
    {
        TextAsset textFile = Resources.Load("Text/" + language + "/Cutscenes/" + currentScene + "/" + sceneProgression) as TextAsset; //get text from file

        if (textFile != null)
        {
            dialogueLines = (textFile.text.Split('\n')); //parse text to array
        }

        if (endAtLine == 0)
        {
            endAtLine = dialogueLines.Length; //stop showing lines after the last line
        }

        StartCoroutine(TextScroll(dialogueLines[currentLine]));
        currentLine++;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !button.activeSelf)
        {
            if (currentLine < endAtLine)
            {
                if (!isTyping)
                {
                    StartCoroutine(TextScroll(dialogueLines[currentLine]));
                    currentLine++; //move to next line when clicking or tapping anywhere
                }
                else if (isTyping && !cancelTyping)
                {
                    cancelTyping = true;
                }
            }
            else if (!isTyping)
            {
                addCutsceneWatched();

                button.SetActive(true);
            }
        }
    }

    private void addCutsceneWatched()
    {
        //If the phone dialog is only supposed to be watched once save that info here
		
		//Both animation and dialog have been watcheded
		PlayerPrefs.SetInt("introWatched", 1);
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        dialogue.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            dialogue.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }

        dialogue.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("MapScene/Map2");
    }
}