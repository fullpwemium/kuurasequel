using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpLevelShelfGame : MonoBehaviour
{
    Button button;
    private int levelsCompleted = 0;

    //Temporal skip button
    void Start ()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(WarpToNext);
    }
    void WarpToNext ()
    {
		ShelfGameManager.manager.PlayerWin();
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
            ShelfGameManager.manager.LoadNextLevel();
        }
        
    }
}
