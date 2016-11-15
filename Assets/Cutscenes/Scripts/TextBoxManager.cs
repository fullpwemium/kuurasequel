using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;

    public Text dialogue;

    public string[] dialogueLines;
    private int currentScene = EventHandler.currentScene;
    private string sceneProgression = EventHandler.sceneProgression;
    public int currentLine;
    public int endAtLine;
    public string language="Eng"; //Language (if different settings are made) should probably be set elsewhere

    // Use this for initialization
    void Start () {
        TextAsset textFile = Resources.Load("Text/" + language + "/Cutscenes/" + currentScene + "/" + sceneProgression) as TextAsset; //get text from file
        if (textFile != null)
        {
            dialogueLines = (textFile.text.Split('\n')); //parse text to array
        }

        if (endAtLine == 0)
        {
            endAtLine = dialogueLines.Length - 1; //stop showing lines after the last line
        }
    }
    

	// Update is called once per frame
	void Update () {
        dialogue.text = dialogueLines[currentLine]; //change dialogue text to show the current line
        currentScene = EventHandler.currentScene;
        string sceneProgression = EventHandler.sceneProgression;
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++; //move to next line when clicking or tapping anywhere
        }

        if (currentLine > endAtLine)
        {
            //sets currentline back to 0 after showing all text lines, disables textbox
            disableTextBox();
            currentLine = 0; 
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
}
