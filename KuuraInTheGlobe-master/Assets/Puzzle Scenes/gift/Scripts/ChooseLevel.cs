﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    private int levelsCompleted = 0;

	public void ChangeToScene(string sceneToChangeTo)
    {
        if (GlobalGameManager.GGM.currentScene == "Memory") { 
        Debug.Log("Cutscenes watched: " + GlobalGameManager.GGM.memoryCutscenesWatched);
        for (int i = 0; i <= 10; i++)
        {
            if (MemoryGameLevelSelecterLimitter.completedLevels.Contains(i))
            {
                levelsCompleted++;
            }
        }
        Debug.Log("levelscompleted " + levelsCompleted);
        if ((GlobalGameManager.GGM.memoryCutscenesWatched < 1 && levelsCompleted < 5) || (GlobalGameManager.GGM.memoryCutscenesWatched < 2 && levelsCompleted > 4) || (GlobalGameManager.GGM.memoryCutscenesWatched < 3 && levelsCompleted > 9))
        {
            MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            SceneManager.LoadScene("CutScene");
        }
        else
        {

            if (sceneToChangeTo.Equals("MapScene/LevelMap")) {
                MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
            }
            else if(sceneToChangeTo.Contains("Puzzle Scenes/"))
            {
                MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);
            }

            Application.LoadLevel(sceneToChangeTo);
        }
        } else
        {
            Application.LoadLevel(sceneToChangeTo);
        }
        //SceneManager.LoadScene("Map2");
        Collector.Coins = 0;
	}

    //IEnumerator ChangeToScene(string sceneToChangeTo)
    //{
    //    //        Application.LoadLevel(sceneToChangeTo);
    //    AsyncOperation async = Application.LoadLevelAdditiveAsync(sceneToChangeTo);
    //    yield return async;
    //    Debug.Log("Loading complete");
    //}
}