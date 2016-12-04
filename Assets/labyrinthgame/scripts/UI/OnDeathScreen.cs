using UnityEngine;
using System.Collections;

public class OnDeathScreen : MonoBehaviour {

	public GameObject confuseimg;
	public GameObject BlackScreen;
	public GameObject tryagain;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.pageTurn, 1);
            MusicPlayer.PlayMusic(MusicTrack.GameOverJingle);
			tryagain.SetActive (true);
			BlackScreen.SetActive (true);
			confuseimg.SetActive(true);
			Time.timeScale = 0;
            Collector.Coins = 0;
		}
	}
	public void OnButtonClick ()
	{
        MusicPlayer.PlayMusic(MusicTrack.HedgeMaze);
        tryagain.SetActive (false);
		BlackScreen.SetActive (false);
		confuseimg.SetActive(false);
		LabManager.manager.RestartLevel ();
		Time.timeScale = 1;
	}
}
