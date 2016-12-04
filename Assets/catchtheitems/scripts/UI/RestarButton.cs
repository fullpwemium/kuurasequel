using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestarButton : MonoBehaviour {

	Button restart;
    private int levelsCompleted = 0;

    // Use this for initialization
    void Start () {
		restart = GetComponent<Button> ();
		restart.onClick.AddListener (Restart);
	}
	
	void Restart()
	{
        //ShelfGameManager.manager.RestartLevel();
        Debug.Log("Cutscenes watched: " + GlobalGameManager.GGM.warehouseCutscenesWatched);
        for (int i = 0; i <= 10; i++)
        {
            if (ShelfGameManager.manager.completedLevels.Contains(i))
            {
                levelsCompleted++;
            }
        }
        Debug.Log("levelscompleted " + levelsCompleted);
        if ((GlobalGameManager.GGM.warehouseCutscenesWatched < 1 && levelsCompleted < 5) || (GlobalGameManager.GGM.warehouseCutscenesWatched < 2 && levelsCompleted > 4) || (GlobalGameManager.GGM.warehouseCutscenesWatched < 3 && levelsCompleted > 9))
        {
            SceneManager.LoadScene("CutScene");
        }
        else
        {
            RunnerTimer.StartGame();        //Aloitetaan Runnerin ajastin alusta.
            RunnerManager.score = 0;

            Scene scene = SceneManager.GetActiveScene();
            //Application.LoadLevel (Application.loadedLevel);
            //base.RestartLevel();
            //Time.timeScale = 1f;
            SceneManager.LoadScene(scene.name);
        }
    }

}
