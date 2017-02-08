﻿using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {
    public GameObject background;
    public static string currentScene; // Mine/Warehouse/Memory/Forest
    public static string sceneProgression = "IntroScene"; // IntroScene/MidScene/EndScene (which of the three scenes is played)
    public static int scenePosition = 0; // default 0, can be set to higher values for testing
    private float waitTime = 6;
    public GameObject cam;
    public GameObject dialogueBox;
    public GameObject textBoxManager;
    public GameObject NPC;
    public IEnumerator timer;
    public static int levelsCompleted;
    public static int cutScenesWatched;

    private void Awake()
    {
        currentScene = GameObject.Find("Global_Gamemanager").GetComponent<GlobalGameManager>().currentScene;
    }

    // Use this for initialization
    void Start () {
        //GameObject.Find("Fader").GetComponent<Fading>().BeginFade(-1);
        timer = CutSceneTimer(waitTime);
        StartCoroutine(timer);
        levelsCompleted = completedLevels();
        progressedInStory();
        cutScenesWatched = watchedScenes();
        playMusic();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown (0) && scenePosition <2 && cam.GetComponent<CameraPan>().enabled == true) {
			scenePosition = 2;
			NPC.SetActive(true);
			dialogueBox.SetActive(true);
            textBoxManager.SetActive(true);
            StopCoroutine(timer);
        }
	}

    private IEnumerator CutSceneTimer(float waitTime)
    {
        yield return new WaitForSeconds(2); //slight wait before camera pan
        cam.GetComponent<CameraPan>().enabled = true;
        while (scenePosition < 2)
        {
            if (scenePosition == 0)
            {
                yield return new WaitForSeconds(waitTime); //just an extra wait time for the first screen, because of the camera pan
            }
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Waited " + waitTime + " seconds. Current scene is " + scenePosition);
            GameObject.Find("Fader").GetComponent<Fading>().BeginFade(1);
            yield return new WaitForSeconds(1);
            GameObject.Find("Fader").GetComponent<Fading>().BeginFade(-1);
            scenePosition++;
        }
        //StopCoroutine(CutSceneTimer(waitTime));
        if (scenePosition == 2)
        {
            //enable the NPC and dialogue at the third screen
            NPC.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            dialogueBox.SetActive(true);
            textBoxManager.SetActive(true);
        }
    }

    int completedLevels()
    {
        //Get completed levels from global game manager
        levelsCompleted = 0;
        switch (currentScene)
        {
            case "Mine":
                for (int i = 0; i <= 10; i++)
                {
                    if (LabyGameManager.manager.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                break;
            case "Warehouse":
                for (int i = 0; i <= 10; i++)
                {
                    if (ShelfGameManager.manager.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                break;
            case "Forest":
                for (int i = 0; i <= 10; i++)
                {
                    if (RunnerManager.manager.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                break;
            case "Memory":
                for (int i = 0; i <= 10; i++)
                {
                    if (MemoryGameLevelSelecterLimitter.completedLevels.Contains(i))
                    {
                        levelsCompleted++;
                    }
                }
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
        Debug.Log("levels completed is " + levelsCompleted);
        return levelsCompleted;
    }
    void progressedInStory()
    {
        if (levelsCompleted < 10)
        {
            sceneProgression = "MidScene";
        }
        if (levelsCompleted < 5)
        {
            sceneProgression = "IntroScene";
        }
        if (levelsCompleted > 9)
        {
            sceneProgression = "EndScene";
        }
    }
    
    private void playMusic()
    {
        switch (currentScene)
        {
            case "Mine":
                MusicPlayer.PlayMusic(MusicTrack.HedgeMazeCutscene);
                break;
            case "Warehouse":
                MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouseCutscene);
                break;
            case "Forest":
                MusicPlayer.PlayMusic(MusicTrack.WinterForestMarathonCutscene);
                break;
            case "Memory":
                MusicPlayer.PlayMusic(MusicTrack.MysticCardsCutscene);
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
        if (sceneProgression == "EndScene" && cutScenesWatched < 3)
        {
            MusicPlayer.PlayMusic(MusicTrack.EndingCutscene);
        }
    }

    int watchedScenes()
    {
        switch (currentScene)
        {
            case "Mine":
                cutScenesWatched = GlobalGameManager.GGM.labyrinthCutscenesWatched;
                break;
            case "Warehouse":
                cutScenesWatched = GlobalGameManager.GGM.warehouseCutscenesWatched;
                break;
            case "Forest":
                cutScenesWatched = GlobalGameManager.GGM.runnerCutscenesWatched;
                break;
            case "Memory":
                cutScenesWatched = GlobalGameManager.GGM.memoryCutscenesWatched;
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
        return cutScenesWatched;
    }
}