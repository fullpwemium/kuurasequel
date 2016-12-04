using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnPause : MonoBehaviour {

    public GameObject Pauseimg;

    public void OnButtonClick ()
    {
        Time.timeScale = 1;
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
        MusicPlayer.ResumePausedMusic();
        Pauseimg.SetActive(false);
    }
}
