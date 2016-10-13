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
        //ShelfGameManager.manager.RestartLevel();

        RunnerTimer.StartGame();        //Aloitetaan Runnerin ajastin alusta.

        Scene scene = SceneManager.GetActiveScene();
        //Application.LoadLevel (Application.loadedLevel);
        //base.RestartLevel();
        //Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
    }

}
