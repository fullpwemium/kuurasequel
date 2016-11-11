using UnityEngine;
using System.Collections;

public class BackgroundSwitcher : MonoBehaviour {
    public Sprite[] mineBackgrounds;
    public Sprite[] runnerBackgrounds;
    private int currentScene = EventHandler.currentScene;
    private int scenePosition = EventHandler.scenePosition;


    /*
    private SceneObject currentCutscene;

    void SetCurrentCutscene(ISceneObject scene) {
        this.currentCutscene = scene;
    }
    */

    // Use this for initialization
    void Start () {
        //GetComponent<SpriteRenderer>().sprite = mineBackgrounds[0];



        

        //InitializeCutscene();
        //PlayCutscene();

    }
    /*
    void PlayCutscene()
    {
        currentCutscene.PlayCutscene();
    }

    void InitializeCutscene()
    {
        currentCutscene.InitializeCutscene();
    }
	*/

	// Update is called once per frame
	void Update () {
        currentScene = EventHandler.currentScene;
        scenePosition = EventHandler.scenePosition;
        switch (currentScene)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition];
                /*
                if (scenePosition == 0) { 
                    Debug.Log("Mine scene");
                }
                if (scenePosition == 1) { 
                    Debug.Log("Mine scene 2");
                }
                if (scenePosition == 2)
                {
                    Debug.Log("Mine scene 3");
                }
                */
                break;
                /*
            case 1:
                GetComponent<SpriteRenderer>().sprite = runnerBackgrounds[scenePosition];
                Debug.Log("Mine scene2");
                break;
                */
            default:
                Debug.Log("default scene");
                break;

        }
    }



}
