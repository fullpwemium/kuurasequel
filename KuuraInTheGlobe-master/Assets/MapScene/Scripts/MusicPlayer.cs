using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//These are used to reduce risk of error when determining a music track to be played.
public enum MusicTrack
{
    WorldMap = 0, BubbleWarehouse = 1, BubbleWarehouseCutscene = 2, EndingCutscene = 3, GameOverJingle = 4, HedgeMaze = 5,
    HedgeMazeCutscene = 6, MysticCards = 7, MysticCardsCutscene = 8, VictoryJingle = 9, WinterForestMarathon = 10, WinterForestMarathonCutscene = 11, SoundEffects = 12
};

/*
 * This is a Singleton class which job is to manage the music tracks of the game. It is created in the World map scene when the game starts. This
 * class in notified every time the scene is changed, and it changes the music track accordingly. You can also call this class' public static
 * methods PlayMusic(), PauseCurrentlyPlayingMusic(), ResumePausedMusic() and StopMusic() to manage music manually.
 */
public class MusicPlayer : MonoBehaviour
{

    //These are all the audio components this GameObject has.
    private AudioSource[] audioSources;

    //This is used to store the track to be resumed later.
    private AudioSource pausedTrack;

    public AudioClip bookClose;
    public AudioClip bookOpen;
    public AudioClip bubbleBurst1;
    public AudioClip bubbleBurst2;
    public AudioClip bubbleBurst3;
    public AudioClip buy;
    public AudioClip catHeadCollected;
    public AudioClip coinCollected;
    public AudioClip crouch;
    public AudioClip dontBuy;
    public AudioClip doorUnlocked;
    public AudioClip itemCatchGood;
	public AudioClip itemCatchBad;
	public AudioClip menuEffect;
    public AudioClip jump;
    public AudioClip keyCollected;
    public AudioClip purringCat;
    public AudioClip menuCancel;
    public AudioClip menuOk;
    public AudioClip pageTurn;
    public AudioClip purr1;
    public AudioClip purr2;
    public AudioClip roll;



    private int worldMapMusicTimeSamples = 0;
    private string currentSceneName ="";

    public static MusicPlayer instance = null;



    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.activeSceneChanged += instance.StartMusicWhenSceneChanges;
            audioSources = gameObject.GetComponents<AudioSource>();
            Debug.Log("MusicPlayer Singleton created.");
        }
        else
        {
            Debug.Log("MusicPlayer already exists, deleting the new instance.");
            Destroy(gameObject);
        }

    }


    // Use this for initialization
    void Start()
    {
        //audioSources[0].Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        // Unsubscribe from being notified about Scene changes.
        SceneManager.activeSceneChanged -= StartMusicWhenSceneChanges;
    }



    /*
     * This is a static method that other classes can use to play music tracks. It uses non-static methods/variables
     * from a static context by calling the methods from a static instance of itself.
     */
    public static void PlayMusic(MusicTrack musicTrack)
    {
        instance.Play(musicTrack);
    }


    /*
    * This is a static method that other classes can use to stop the current music track. It uses non-static methods/variables
    * from a static context by calling the methods from a static instance of itself.
    */
    public static void StopMusic()
    {
        instance.Stop();
    }


    /*
    * This is a static method that other classes can use to pause the current music track.
    */
    public static void PauseCurrentlyPlayingMusic()
    {
        instance.Pause();
    }


    /*
    * This is a static method that other classes can use to resume the paused music track.
    */
    public static void ResumePausedMusic()
    {
        instance.Resume();
    }




    /*
     * This method gets notified every time when the scene changes. It is used to start the approppriate
     * background music automatically based on the new scene's name.
    */
    void StartMusicWhenSceneChanges(Scene previousScene, Scene newScene)
    {

        switch (newScene.name)
        {

            //The World map.
            case "Map2":
			case "Overworld":

                //The World map track is already playing, so no need to restart it.
                if (audioSources[0].isPlaying) { break; }

                Play(MusicTrack.WorldMap);
                Debug.Log("World map theme playing based on scene change.");
                break;

            //The Bubble warehouse.
            case "CatchTheCatLevelSelect":

                if (audioSources[1].isPlaying) { break; }

                Play(MusicTrack.BubbleWarehouse);
                Debug.Log("Bubble warehouse playing based on scene change.");
                break;

            //Hedge maze.
            case "LabyrinthLevelSelect":

                if (audioSources[5].isPlaying) { break; }

                Play(MusicTrack.HedgeMaze);
                Debug.Log("Hedge maze theme playing based on scene change.");
                break;

            //Mystic cards.
            case "LevelMap":

                if (audioSources[7].isPlaying) { break; }

                Play(MusicTrack.MysticCards);
                Debug.Log("Mystic cards theme playing based on scene change.");
                break;

            //Winter forest marathon.
            case "RunnerLevelMap":
			case "_rocketGame-Gameplay": 
			case "_rocketGameLevelSelect": 
			case "WordGameScene":

                if (audioSources[10].isPlaying) { break; }

                Play(MusicTrack.WinterForestMarathon);
                Debug.Log("Runner theme playing based on scene change.");
                break;


            default:
                break;
        }

    }



    /* 
     * This method plays a music track based on the enum MusicTrack parameter value. The values are as follows:
     * The used enum values: WorldMap = 0, BubbleWarehouse = 1, BubbleWarehouseCutscene = 2, EndingCutscene = 3, GameOverJingle = 4, HedgeMaze = 5,
     * HedgeMazeCutscene = 6, MysticCards = 7, MysticCardsCutscene = 8, VictoryJingle = 9, WinterForestMarathon = 10, 
     * WinterForestMarathonCutscene = 11
     */
    private void Play(MusicTrack musicTrack)
    {

        AudioSource currentlyPlayingTrack = GetCurrentlyPlayingMusicTrack();

        int trackIndex = (int)musicTrack;

        //The track is a jingle that pauses the current track and resumes it after the jingle has played.
        if (trackIndex == 4 || trackIndex == 9)
        {
            StartCoroutine(PlayJingle(audioSources[trackIndex]));
            return;
        }

        //Ignore this function if the track is already playing.
        if (currentlyPlayingTrack.Equals(audioSources[(int)musicTrack]) && audioSources[(int)musicTrack].isPlaying ) {
            return;
        }

        Stop();

        //If the track is the World map theme, it's starting time is loaded from the worldMapMusicSamples variable
        //which is updated in the Stop() -method.
        if (trackIndex == 0)
        {
            audioSources[0].timeSamples = worldMapMusicTimeSamples;
        }

        audioSources[trackIndex].Play();
        Debug.Log("New music track playing.");

    }


    /* 
     * Stops all the currently playing music tracks (not the sound effect channel). It also stores the worldMapMusic's current time if it happens to be 
     * the currently playing track.
    */
    private void Stop()
    {

        foreach (AudioSource audioSource in audioSources)
        {

            if (audioSource.isPlaying)
            {

                if (audioSource.Equals(audioSources[0]))
                {
                    worldMapMusicTimeSamples = audioSource.timeSamples;
                    Debug.Log("World map theme's timeSamples saved.");
                }
                //Don't stop the sound effect channel.
                if (audioSource != audioSources[12]) {
                    audioSource.Stop();
                    Debug.Log("Music track stopped.");
                }
                

            }


        }
    
    }


    /*
     * Returns the current music track. If there is no track being played, it returns the World map theme.
     */
    private AudioSource GetCurrentlyPlayingMusicTrack()
    {

        AudioSource currentlyPlayingTrack = audioSources[0];

        foreach (AudioSource audioSource in audioSources)
        {

            if (audioSource.isPlaying)
            {

                currentlyPlayingTrack = audioSource;
                return currentlyPlayingTrack;

            }
        }

        return currentlyPlayingTrack;

    }


    /* 
     * Pauses the currently playing music track, plays a given jingle AudioSource and resumes the previous one after it's finished.
     */
    private IEnumerator PlayJingle(AudioSource jingle)
    {
        Pause();
        jingle.Play();
        Debug.Log("Jingle played.");
        yield return new WaitForSeconds(jingle.clip.length);
        Resume();
        
    }

    /* 
    * Pauses the currently playing music track and stores it to the pausedTrack AudioSource.
    */
    private void Pause() {

        pausedTrack = GetCurrentlyPlayingMusicTrack();
        currentSceneName = SceneManager.GetActiveScene().name;

        if (pausedTrack.isPlaying) {
            pausedTrack.Pause();
        }

        Debug.Log("Music track paused.");

    }


    /* 
    * Resumes a paused AudioSource that the pausedTrack refers.
    */
    private void Resume()
    {
        /*
        //if (pausedTrack != GetCurrentlyPlayingMusicTrack()) {
        if (SceneManager.GetActiveScene().name.Equals(currentSceneName))
            {
	            try
	            {
	                pausedTrack.UnPause();
	                Debug.Log("Music track resumed from pause.");
	            }
	            catch (System.Exception) {
	                Debug.Log("There was an exception related to resuming a music track.");
	            } 
        }
        */
    }


    public void PlaySoundEffect(AudioClip clip, float volume)
    {
        audioSources[12].PlayOneShot(clip, volume);
    }

    /*
    public void PlaySoundEffect(AudioClip clip)
    {
        audioSources[12].clip = clip;
        audioSources[12].Play();
    }
    */


}

