using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    AudioSource worldMapMusic;
    public static MusicPlayer musicPlayerInstance;

    private void Awake() {

        if (musicPlayerInstance == null)
        {
            musicPlayerInstance = this;
            DontDestroyOnLoad(musicPlayerInstance);
            SceneManager.activeSceneChanged += musicPlayerInstance.StartMusicWhenSceneChanges;
        }
        else {
            Destroy(this);
        }

    }

	// Use this for initialization
	void Start () {

        worldMapMusic = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name.Equals("Map2") && !musicPlayerInstance.worldMapMusic.isPlaying)
        {
            musicPlayerInstance.worldMapMusic.Play();
        }

    }
	
	// Update is called once per frame
	void Update () {
        

    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= StartMusicWhenSceneChanges; // unsubscribe
    }


    void StartMusicWhenSceneChanges(Scene previousScene, Scene newScene) {
        
        if (newScene.name.Equals("Map2") && previousScene.name.Equals("Map2") && !musicPlayerInstance.worldMapMusic.isPlaying)
        {
            musicPlayerInstance.worldMapMusic.Play();
        }
        else {
            musicPlayerInstance.worldMapMusic.Stop();
            Destroy(this);
        }
        
    }

}
