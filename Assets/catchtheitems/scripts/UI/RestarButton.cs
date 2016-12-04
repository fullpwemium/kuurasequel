using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestarButton : MonoBehaviour {

	Button restart;


	// Use this for initialization
	void Start () {
		restart = GetComponent<Button> ();
		restart.onClick.AddListener (Restart);
	}
	
	void Restart()
	{
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
        //ShelfGameManager.manager.RestartLevel();

        RunnerTimer.StartGame();        //Aloitetaan Runnerin ajastin alusta.
        RunnerManager.score = 0;

        Scene scene = SceneManager.GetActiveScene();
        //Application.LoadLevel (Application.loadedLevel);
        //base.RestartLevel();
        //Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
    }

}
