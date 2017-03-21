using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverworldButtonScript : MonoBehaviour
{
	public string sceneToLoad;
	public int gameNumber;

	private Node nodeScript;
	BobOverworldScript Bob;


	// Use this for initialization
	void Start ()
	{
		nodeScript = GetComponent<Node>();
		Bob = GameObject.Find("BobObject").GetComponent<BobOverworldScript>();
		Button but = gameObject.GetComponent<Button>();

		but.onClick.AddListener(() => MoveHere());
	}

	void MoveHere ()
	{
		
		if (Bob.getCurrentNode() == nodeScript) {
			Bob.storePosition ();
			SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
			return;
		}

		if (!BobOverworldScript.Moving )
		{       
			//GameLoader();
			Bob.startMoving ( 
				nodeScript.findPath (
					nodeScript,
					true,
					0, 
					Bob.getCurrentNode()
				)
			);
		}
	}
		
}
