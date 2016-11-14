using UnityEngine;
using System.Collections;

public class BackgroundSwitcher : MonoBehaviour {
    public Sprite[] mineBackgrounds;
    public Sprite[] runnerBackgrounds;
    private int currentScene = EventHandler.currentScene;
    private int scenePosition = EventHandler.scenePosition;

    // Use this for initialization
    void Start () {

    }

	// Update is called once per frame
	void Update () {
        currentScene = EventHandler.currentScene; 
        scenePosition = EventHandler.scenePosition;
        switch (currentScene) 
        {
            //cases are based on which scene's background are used
            //should consider using string for the names instead, but integers have some benefits here
            case 1:
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition]; //change background for the cutscene intro transitions
                break;
            default:
                Debug.Log("default scene");
                break;
        }
    }

}
