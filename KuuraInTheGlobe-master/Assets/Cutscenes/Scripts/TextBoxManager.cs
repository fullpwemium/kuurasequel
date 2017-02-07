using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public GameObject buttons;
    public Text dialogue;

    public string[] dialogueLines;
    public string[] oneLiners; //The comment on the menu after dialogue

    private string currentScene = EventHandler.currentScene;
    private string sceneProgression = EventHandler.sceneProgression;
    private int levelsCompleted = EventHandler.levelsCompleted;

    private int currentLine = 0;
    private int endAtLine;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed; //How fast the text shows up, smaller is faster. Default is 0.02
    bool showingOneliner = false;

    public string language="Eng"; //Language (if different settings are made) should probably be set elsewhere

    private int cutscenesWatched = EventHandler.cutScenesWatched;

    private void Awake()
    {
        currentScene = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene;
        Debug.Log("current scene is " + currentScene);
    }
    // Use this for initialization
    void Start () {
        sceneProgression = EventHandler.sceneProgression;
        Debug.Log(sceneProgression);
        TextAsset textFile = Resources.Load("Text/" + language + "/Cutscenes/" + currentScene + "/" + sceneProgression) as TextAsset; //get text from file
        TextAsset oneLinerFile = Resources.Load("Text/" + language + "/Cutscenes/" + currentScene + "/OneLiners") as TextAsset;
        if (textFile != null)
        {
            dialogueLines = (textFile.text.Split('\n')); //parse text to array
        }

        if (oneLinerFile != null)
        {
            oneLiners = (oneLinerFile.text.Split('\n')); //parse text to array
        }

        if (endAtLine == 0)
        {
            endAtLine = dialogueLines.Length; //stop showing lines after the last line
        }
        StartCoroutine(TextScroll(dialogueLines[currentLine]));
        currentLine++;
    }
    

	// Update is called once per frame
	void Update () {
        currentScene = EventHandler.currentScene;
        cutscenesWatched = EventHandler.cutScenesWatched;
        string sceneProgression = EventHandler.sceneProgression;

        if ((cutscenesWatched > 0 && sceneProgression == "IntroScene") || (cutscenesWatched > 1 && sceneProgression == "MidScene") || cutscenesWatched > 2 && sceneProgression == "EndScene")
        {
            showOneLiner();
            buttons.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && !buttons.activeSelf)
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
                    if (GlobalGameManager.GGM.labyrinthCutscenesWatched == 3 && GlobalGameManager.GGM.warehouseCutscenesWatched == 3 && GlobalGameManager.GGM.runnerCutscenesWatched == 3 && GlobalGameManager.GGM.memoryCutscenesWatched == 3) 
                    {
                        GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene = "Theater";
                        SceneManager.LoadScene("Theater");
                    }
                    showOneLiner();
                    buttons.SetActive(true);
                }
        } 
	}

    private void addCutsceneWatched()
    {
        switch (currentScene)
        {
            case "Mine":
                GlobalGameManager.GGM.labyrinthCutscenesWatched++;
                break;
            case "Warehouse":
                GlobalGameManager.GGM.warehouseCutscenesWatched++;
                break;
            case "Forest":
                GlobalGameManager.GGM.runnerCutscenesWatched++;
                break;
            case "Memory":
                GlobalGameManager.GGM.memoryCutscenesWatched++;
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
        GlobalGameManager.GGM.CutSceneSave();
    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        dialogue.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length -1) && showingOneliner == false)
        {
            dialogue.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogue.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void enableTextBox()
    {
        textBox.SetActive(true);
    }
    public void disableTextBox()
    {
        textBox.SetActive(false);
    }

    public void showOneLiner()
    {
        showingOneliner = true;
        levelsCompleted = EventHandler.levelsCompleted;
        if (levelsCompleted > 9)
            dialogue.text = oneLiners[4];
        if (levelsCompleted < 10)
            dialogue.text = oneLiners[3];
        if (levelsCompleted < 7)
            dialogue.text = oneLiners[2];
        if (levelsCompleted < 4)
            dialogue.text = oneLiners[1];
        if (levelsCompleted < 2)
            dialogue.text = oneLiners[0];
    }

}