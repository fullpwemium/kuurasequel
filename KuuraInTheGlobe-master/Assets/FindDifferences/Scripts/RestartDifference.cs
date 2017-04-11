using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartDifference : MonoBehaviour
{
    public static int Restart = 0;

    void Start()
    {
        Restart = 0;
    }

    public void Replay()
    {
        //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);

        Application.LoadLevel(Application.loadedLevel);     //Reload opened scene.

        //Restart = 1;

        FindingTimer.StartGame();       //Restart timer.
        ClickMistake.StartClicks();     ////Zero mistake clicks.

        Restart = 1;        //Return number of clicks back to defined starting number.

        //Redo to UI function
        //Pauseimg.SetActive(false);
    }

    public void Exit(string sceneToChangeTo)
    {
        Restart = 1;

        Application.LoadLevel(sceneToChangeTo);
    }
}
