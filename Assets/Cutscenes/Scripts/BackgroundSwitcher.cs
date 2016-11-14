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
            case 1:
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition];
                break;
            default:
                Debug.Log("default scene");
                break;
        }
    }

}
