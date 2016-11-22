using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour {
    public GameObject background;
    public static string currentScene = "Warehouse"; // Mine/Warehouse/Memory/Forest
    public static string sceneProgression = "MidScene"; // IntroScene/MidScene/EndScene (which of the three scenes is played)
    public static int scenePosition = 0; // default 0, can be set to higher values for testing
    private float waitTime = 6;
    public GameObject cam;
    public GameObject dialogueBox;
    public GameObject textBoxManager;
    public GameObject NPC;
    public IEnumerator timer;

    // Use this for initialization
    void Start () {
        timer = CutSceneTimer(waitTime);
        StartCoroutine(timer);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && scenePosition <2) {
			scenePosition = 2;
			NPC.SetActive(true);
			dialogueBox.SetActive(true);
            textBoxManager.SetActive(true);
            StopCoroutine(timer);
        }
	}

    private IEnumerator CutSceneTimer(float waitTime)
    {
        //yield return new WaitForSeconds(2); //slight wait before camera pan
        cam.GetComponent<CameraPan>().enabled = true;
        while (scenePosition < 2)
        {
            if (scenePosition == 0)
            {
                yield return new WaitForSeconds(waitTime); //just an extra wait time for the first screen, because of the camera pan
            }
            yield return new WaitForSeconds(waitTime);
            Debug.Log("Waited " + waitTime + " seconds. Current scene is " + scenePosition);
            scenePosition++;
        }
        //StopCoroutine(CutSceneTimer(waitTime));
        if (scenePosition == 2)
        {
            //enable the NPC and dialogue at the third screen
            NPC.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            dialogueBox.SetActive(true);
            textBoxManager.SetActive(true);
        }
    }

}
