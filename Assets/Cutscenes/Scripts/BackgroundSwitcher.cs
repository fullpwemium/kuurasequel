using UnityEngine;
using System.Collections;

public class BackgroundSwitcher : MonoBehaviour {
    public Sprite[] mineBackgrounds;
    public Sprite[] runnerBackgrounds;
    public int currentScene = 0;
    public int scenePosition = 0;
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
        switch (currentScene)
        {
            case 0:
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition];
                if (scenePosition == 0) { 
                    Debug.Log("Mine scene");
                }
                if (scenePosition == 1) { 
                    Debug.Log("Mine scene 2");
                }
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = runnerBackgrounds[scenePosition];
                Debug.Log("Mine scene2");
                break;
            default:
                Debug.Log("default scene");
                break;

        }
    }
}
