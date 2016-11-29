using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//These are used to reduce risk of error when determining a music track to be played.
public enum MusicTrack
{
    WorldMap = 0, BubbleWarehouse = 1, BubbleWarehouseCutscene = 2, EndingCutscene = 3, GameOverJingle = 4, HedgeMaze = 5,
    HedgeMazeCutscene = 6, MysticCards = 7, MysticCardsCutscene = 8, VictoryJingle = 9, WinterForestMarathon = 10, WinterForestMarathonCutscene = 11
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

    private int worldMapMusicTimeSamples = 0;
    private string currentSceneName ="";

    public static MusicPlayer musicPlayerInstance;



    private void Awake()
    {

        if (musicPlayerInstance == null)
        {
            musicPlayerInstance = this;
            DontDestroyOnLoad(musicPlayerInstance);
            SceneManager.activeSceneChanged += musicPlayerInstance.StartMusicWhenSceneChanges;
            audioSources = gameObject.GetComponents<AudioSource>();
            Debug.Log("MusicPlayer Singleton created.");
        }
        else
        {
            Debug.Log("MusicPlayer already exists, deleting the new instance.");
            Destroy(this);
        }

    }


    // Use this for initialization
    void Start()
    {
        audioSources[0].Play();
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
        musicPlayerInstance.Play(musicTrack);
    }


    /*
    * This is a static method that other classes can use to stop the current music track. It uses non-static methods/variables
    * from a static context by calling the methods from a static instance of itself.
    */
    public static void StopMusic()
    {
        musicPlayerInstance.Stop();
    }


    /*
    * This is a static method that other classes can use to pause the current music track.
    */
    public static void PauseCurrentlyPlayingMusic()
    {
        musicPlayerInstance.Pause();
    }


    /*
    * This is a static method that other classes can use to resume the paused music track.
    */
    public static void ResumePausedMusic()
    {
        musicPlayerInstance.Resume();
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
     * Stops all the currently playing music tracks. It also stores the worldMapMusic's current time if it happens to be 
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

                audioSource.Stop();
                Debug.Log("Music track stopped.");

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
        //Resume the paused track if it is defined and the scene is still the same as when pausing it.
        if (pausedTrack != null && currentSceneName.Equals(SceneManager.GetActiveScene().name)) {
            try
            {
                pausedTrack.UnPause();
                Debug.Log("Music track resumed from pause.");
            }
            catch (System.Exception) {
                Debug.Log("There was an exception related to resuming a music track.");
            } 
        }
        


    }


}

