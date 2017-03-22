using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    private Image border;
    private Button retryButton;
    private Button exitButton;
    private Image retryImage;
    private Image exitImage;
    private Text retryText;

    private void Start()
    {
        border = GameObject.Find("GameOverPrompt/Border").GetComponent<Image>();
        retryButton = GameObject.Find("GameOverPrompt/Border/RetryButton").GetComponent<Button>();
        exitButton = GameObject.Find("GameOverPrompt/Border/ExitButton").GetComponent<Button>();
        retryImage = GameObject.Find("GameOverPrompt/Border/RetryButton/RetryImage").GetComponent<Image>();
        exitImage = GameObject.Find("GameOverPrompt/Border/ExitButton/ExitImage").GetComponent<Image>();
        retryText = GameObject.Find("GameOverPrompt/Border/RetryText").GetComponent<Text>();
    }

    public void activatePrompt()
    {
        
    }

    public void deactivatePromt()
    {

    }
}
