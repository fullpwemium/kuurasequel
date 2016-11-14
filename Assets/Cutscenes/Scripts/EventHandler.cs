using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {
    public GameObject background;
    public static int currentScene = 1; //mine scene is 1
    public static int scenePosition = 0; //default 0, can be set to higher values for testing
    private float waitTime = 6;
    public GameObject cam;
    public GameObject dialogueBox;
    public GameObject NPC;
    // Use this for initialization
    void Start () {
        StartCoroutine(CutSceneTimer(waitTime));
        /*
        switch (currentScene)
        {
            case 1:
                

                scenePosition = 1;
                Debug.Log("Current position is " + scenePosition);
                StartCoroutine(CutSceneTimer(waitTime));
                scenePosition = 2;
                Debug.Log("Current position is " + scenePosition);
                break;
            case 2:
                break;
            default:
                break;

        }
    */

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    private IEnumerator CutSceneTimer(float waitTime)
    {
        //yield return new WaitForSeconds(2);
        cam.GetComponent<CameraPan>().enabled = true;
        while (scenePosition < 2)
        {
            if (scenePosition == 0)
            {
                yield return new WaitForSeconds(waitTime);
            }
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Waited " + waitTime + " seconds. Current scene is " + scenePosition);
            scenePosition++;
        }
        //StopCoroutine(CutSceneTimer(waitTime));
        if (scenePosition == 2)
        {
            NPC.SetActive(true);
            dialogueBox.SetActive(true);
        }
    }

}
