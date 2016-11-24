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
 * methods PlayMusic() and StopMusic() to manage music manually.
 */
public class MusicPlayer : MonoBehaviour
{

    private AudioSource[] audioSources;

    private int worldMapMusicTimeSamples = 0;

    public static MusicPlayer musicPlayerInstance;



    private void Awake()
    {

        if (musicPlayerInstance == null)
        {
            musicPlayerInstance = this;
            DontDestroyOnLoad(musicPlayerInstance);
            SceneManager.activeSceneChanged += musicPlayerInstance.StartMusicWhenSceneChanges;
        }
        else
        {
            Destroy(this);

        }

    }


    // Use this for initialization
    void Start()
    {

        audioSources = GetComponents<AudioSource>();

        PlayMusic(MusicTrack.WorldMap);

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
    public static void StopMusic(AudioSource musicTrack)
    {
        musicPlayerInstance.Stop(musicTrack);
    }


    /*
     * This method gets notified every time when the scene changes. It is used to start the approppriate
     * background music based on the new scene's name.
    */
    void StartMusicWhenSceneChanges(Scene previousScene, Scene newScene)
    {

        switch (newScene.name)
        {

            //The World map.
            case "Map2":
                
                if (audioSources[0].isPlaying) { break; }

                Play(MusicTrack.WorldMap);
                break;

            //The Bubble warehouse.
            case "CatchTheCatLevelSelect":

                if (audioSources[1].isPlaying) { break; }

                Play(MusicTrack.BubbleWarehouse);
                break;

            //Hedge maze.
            case "LabyrinthLevelSelect":

                if (audioSources[5].isPlaying) { break; }

                Play(MusicTrack.HedgeMaze);
                break;

            //Mystic cards.
            case "LevelMap":

                if (audioSources[7].isPlaying) { break; }

                Play(MusicTrack.MysticCards);
                break;

            //Winter forest marathon.
            case "RunnerLevelMap":

                if (audioSources[10].isPlaying) { break; }

                Play(MusicTrack.WinterForestMarathon);
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
    private void Play(MusicTrack musicTrack) {

        AudioSource currentlyPlayingTrack = GetCurrentlyPlayingMusicTrack();

        int trackIndex = (int)musicTrack;

        //The track is a jingle that pauses the current track and resumes it after the jingle has played.
        if (trackIndex == 4 || trackIndex == 9) {

            int trackCurrentTime = currentlyPlayingTrack.timeSamples;

            currentlyPlayingTrack.Stop();
            audioSources[trackIndex].Play();
            StartCoroutine(PlayJingle(audioSources[trackIndex], currentlyPlayingTrack, trackCurrentTime));

            return;

        }

        Stop(currentlyPlayingTrack);

        //If the track is the World map theme, it's starting time is loaded from the worldMapMusicSamples variable
        //which is updated in the Stop() -method.
        if (trackIndex == 0) {
            audioSources[0].timeSamples=worldMapMusicTimeSamples;
        }

        audioSources[trackIndex].Play();
        
    }


    /* 
     * Stops the currently playing music track. It also stores the worldMapMusic's current time if it happens to be 
     * the currently playing track.
    */
    private void Stop(AudioSource musicTrack)
    {

        if (musicTrack.Equals(audioSources[0]))
        {

            worldMapMusicTimeSamples = musicTrack.timeSamples;

        }

        musicTrack.Stop();

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
     * Plays a given AudioSource and resumes the previous one after it's finished.
     */
    private IEnumerator PlayJingle(AudioSource jingle, AudioSource previousTrack, int trackResumeTime)
    {

        yield return new WaitForSeconds(jingle.clip.length);
        previousTrack.timeSamples = trackResumeTime;
        previousTrack.Play();
        Debug.Log("Jingle played.");
    }


}

