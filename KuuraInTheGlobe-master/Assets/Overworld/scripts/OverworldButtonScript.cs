using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverworldButtonScript : MonoBehaviour
{
	public string sceneToLoad;

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
			MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuOk, 1);

			switch (sceneToLoad) {
				case "Shop":
				case "Theater":
				case "Bob_apartment":
					SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
					break;
				default:
					GlobalGameManager.GGM.currentScene = sceneToLoad;
					SceneManager.LoadScene ("Cutscene", LoadSceneMode.Single);
					break;
			}
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
