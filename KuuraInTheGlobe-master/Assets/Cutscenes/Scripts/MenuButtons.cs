using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    private string currentScene = EventHandler.currentScene;
    public GameObject backgroundSwitcher;

    // Use this for initialization
    void Start () {
	    currentScene = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Play()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        switch (currentScene) {
            case "RocketGame":
                SceneManager.LoadScene("_rocketGameLevelSelect");
                break;
            case "WordQuiz":
				SceneManager.LoadScene("WordGameScene");
				break;
            default:
                break;
        }
        backgroundSwitcher.GetComponent<BackgroundSwitcher>().enabled = false;
        EventHandler.scenePosition = 0;
    }

    public void BackToMap()
    {
        Debug.Log("Back to map");
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        backgroundSwitcher.GetComponent<BackgroundSwitcher>().enabled = false;
        SceneManager.LoadScene("Overworld");
        EventHandler.scenePosition = 0;
    }
}
