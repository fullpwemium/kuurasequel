using UnityEngine;
using System.Collections;

public class BackgroundSwitcher : MonoBehaviour {
    public Sprite[] mineBackgrounds;
    public Sprite[] warehouseBackgrounds;
    public Sprite[] memoryBackgrounds;
    public Sprite[] forestBackgrounds;
    
    private string currentScene = EventHandler.currentScene;
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
            case "Mine":
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition]; //change background for the cutscene intro transitions
                break;
            case "Warehouse":
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition]; //temporary solution until other bg's are made.
                //GetComponent<SpriteRenderer>().sprite = warehouseBackgrounds[scenePosition];
                break;
            case "Memory":
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition]; //temporary solution until other bg's are made.
                //GetComponent<SpriteRenderer>().sprite = memoryBackgrounds[scenePosition];
                break;
            case "Forest":
                GetComponent<SpriteRenderer>().sprite = mineBackgrounds[scenePosition]; //temporary solution until other bg's are made.
                //GetComponent<SpriteRenderer>().sprite = forestBackgrounds[scenePosition];
                break;
            default:
                Debug.Log("This scene should not exist.");
                break;
        }
    }

}
