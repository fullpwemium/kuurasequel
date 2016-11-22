using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public GameObject buttons;
    public Text dialogue;

    public string[] dialogueLines;
    public string[] oneLiners; //The comment on the menu after dialogue

    private string currentScene = EventHandler.currentScene;
    private string sceneProgression = EventHandler.sceneProgression;

    public int currentLine;
    public int endAtLine;
    public string language="Eng"; //Language (if different settings are made) should probably be set elsewhere
    public int levelsCompleted = 0;

    // Use this for initialization
    void Start () {
        currentScene = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene;
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
            endAtLine = dialogueLines.Length - 1; //stop showing lines after the last line
        }

        //Get completed levels from saves
        /*
        switch (currentScene)
        {
            case "Mine":
                // levelsCompleted = PlayerPrefs.GetInt("minelevels");
                // mine save doesn't exist yet
                break;
            case "Warehouse":
                levelsCompleted = PlayerPrefs.GetInt("levels");
                break;
            case "Forest":
                levelsCompleted = PlayerPrefs.GetInt("Runnerlevels");
                break;
            case "Memory":
                levelsCompleted = PlayerPrefs.GetInt("memorylevels");
                break;
            default:
                break;
        }
        */
        
    }
    

	// Update is called once per frame
	void Update () {
        if (currentLine < endAtLine)
        {
            dialogue.text = dialogueLines[currentLine]; //change dialogue text to show the current line
            currentScene = EventHandler.currentScene;
            string sceneProgression = EventHandler.sceneProgression;
            if (Input.GetMouseButtonDown(0))
            {
                currentLine++; //move to next line when clicking or tapping anywhere
            }
        } else { 
            //sets currentline back to 0 after showing all text lines, disables textbox
            //disableTextBox();
            showOneLiner();
            buttons.SetActive(true);
            //currentLine = 0; 
            //TODO: call menu
        }
        
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
        if (levelsCompleted > 9)
            dialogue.text = oneLiners[4];
        if (levelsCompleted < 10)
            dialogue.text = oneLiners[3];
        if (levelsCompleted < 7)
            dialogue.text = oneLiners[2];
        if (levelsCompleted < 4)
            dialogue.text = oneLiners[1];
        if (levelsCompleted < 1)
            dialogue.text = oneLiners[0];
    }

}