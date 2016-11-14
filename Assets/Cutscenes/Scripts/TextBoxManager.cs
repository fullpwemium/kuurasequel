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
    public string language="Eng";

    //public PlayerInput player;

    // Use this for initialization
    void Start () {
        //player = FindObjectOfType<PlayerInput>();
        TextAsset textFile = Resources.Load("Text/" + language + "/Cutscenes/" + currentScene + "/" + sceneProgression) as TextAsset;
        if (textFile != null)
        {
            dialogueLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = dialogueLines.Length - 1;
        }
    }
    

	// Update is called once per frame
	void Update () {
        dialogue.text = dialogueLines[currentLine];
        currentScene = EventHandler.currentScene;
        string sceneProgression = EventHandler.sceneProgression;
        if (Input.GetMouseButtonDown(0))
        {
            currentLine++;
        }

        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
            currentLine = 0;
        }
        
	}
}
