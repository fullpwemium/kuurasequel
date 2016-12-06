using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{

	Button lvlSelect;
    public string levelName;
    private int levelsCompleted = 0;

    // Use this for initialization
    void Start ()
    {
		lvlSelect = GetComponent<Button> ();
		lvlSelect.onClick.AddListener (LevelSelect);

        if (RunnerManager.score != 0)
        {
            RunnerManager.score = 0;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

	void LevelSelect()
	{
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        switch(GlobalGameManager.GGM.currentScene) {
            case "Warehouse": 
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
                    SceneManager.LoadScene(levelName);
                }
                break;
            case "Mine":
                Debug.Log("Cutscenes watched: " + GlobalGameManager.GGM.labyrinthCutscenesWatched);
                for (int i = 0; i <= 10; i++)
                {
                    if (LabyGameManager.manager.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                Debug.Log("levelscompleted " + levelsCompleted);
                if ((GlobalGameManager.GGM.labyrinthCutscenesWatched < 1 && levelsCompleted < 5) || (GlobalGameManager.GGM.labyrinthCutscenesWatched < 2 && levelsCompleted > 4) || (GlobalGameManager.GGM.labyrinthCutscenesWatched < 3 && levelsCompleted > 9))
                {
                    SceneManager.LoadScene("CutScene");
                }
                else
                {
                    SceneManager.LoadScene(levelName);
                }
                break;
            case "Forest":
                Debug.Log("Cutscenes watched: " + GlobalGameManager.GGM.runnerCutscenesWatched);
                for (int i = 0; i <= 10; i++)
                {
                    if (RunnerManager.manager.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                Debug.Log("levelscompleted " + levelsCompleted);
                if ((GlobalGameManager.GGM.runnerCutscenesWatched < 1 && levelsCompleted < 5) || (GlobalGameManager.GGM.runnerCutscenesWatched < 2 && levelsCompleted > 4) || (GlobalGameManager.GGM.runnerCutscenesWatched < 3 && levelsCompleted > 9))
                {
                    SceneManager.LoadScene("CutScene");
                }
                else
                {
                    SceneManager.LoadScene(levelName);
                }
                break;
                /*
            default:
                SceneManager.LoadScene(levelName);
                break;
                */
        }
        
        //SceneManager.LoadScene(levelName);
    }
        
}
