using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;

    public Text dialogue;

    public TextAsset textFile;
    public string[] dialogueLines;

    public int currentLine;
    public int endAtLine;

    //public PlayerInput player;

    // Use this for initialization
    void Start () {
        //player = FindObjectOfType<PlayerInput>();
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
