using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public GameObject Pauseimg;

    public void OnButtonClick ()
    {
        //Pause the game.
        if (Time.timeScale != 0)
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
            MusicPlayer.PauseCurrentlyPlayingMusic();
            Pauseimg.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Paussi");
        }
        else {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
            MusicPlayer.ResumePausedMusic();
            Pauseimg.SetActive(false);
            Time.timeScale = GameManager.aika;
            Debug.Log("Jatkuu");
        }
        
    }
}
