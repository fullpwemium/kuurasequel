using UnityEngine;
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
		int ret = 0;
        switch (currentScene)
        {
			case "RocketGame": 
				ret = GlobalGameManager.GGM.getNumberOfBeatenLevels ("rocketGame"); //Note the lower r!
				break;
			case "WordQuiz":
				ret = GlobalGameManager.GGM.getNumberOfBeatenLevels ("quizGame"); //Note that WordQuiz != quizGame!
				break;
            case "DifferenceGame":
                ret = GlobalGameManager.GGM.getNumberOfBeatenLevels("difGame"); //
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
		return ret;
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
			case "RocketGame":
				MusicPlayer.PlayMusic(MusicTrack.WinterForestMarathonCutscene);
                break;
			case "WordQuiz":
                MusicPlayer.PlayMusic(MusicTrack.MysticCardsCutscene);
                break;
            case "DifferenceGame":
                MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouseCutscene);
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
			case "RocketGame":
			case "WordQuiz":
				cutScenesWatched = GlobalGameManager.GGM.checkCutsceneProgress (currentScene);
				break;
            case "DifferenceGame":
                //cutScenesWatched = GlobalGameManager.GGM.differenceCutscenesWatched;
                cutScenesWatched = GlobalGameManager.GGM.checkCutsceneProgress(currentScene);
                break;
            default:
                Debug.Log("Scene doesn't exist");
                break;
        }
        return cutScenesWatched;
    }
}
