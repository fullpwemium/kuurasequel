using UnityEngine;
using System.Collections;

public class NPCSwitcher : MonoBehaviour {
    public Sprite[] NPCSprite;
    private string currentScene = EventHandler.currentScene;

    // Use this for initialization
    void Start () {
        currentScene = EventHandler.currentScene;
        switch (currentScene)
        {
            //cases are based on which scene's background are used
            //should consider using string for the names instead, but integers have some benefits here
            case "Mine":
                GetComponent<SpriteRenderer>().sprite = NPCSprite[0];
                break;
            case "Warehouse":
                GetComponent<SpriteRenderer>().sprite = NPCSprite[2];
                break;
            case "Memory":
                GetComponent<SpriteRenderer>().sprite = NPCSprite[1];
                break;
            case "Forest":
                GetComponent<SpriteRenderer>().sprite = NPCSprite[3];
                break;
            default:
                Debug.Log("This scene should not exist.");
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        
    }
}
