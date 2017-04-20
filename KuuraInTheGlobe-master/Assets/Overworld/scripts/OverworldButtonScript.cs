using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * OvberworldButtonScript
 * Script that is attached to points of interest
*/

public class OverworldButtonScript : MonoBehaviour
{
	// If this object is activated, what scene is to be loaded?
	public string sceneToLoad;

	private Node nodeScript;
	BobOverworldScript Bob; //Player object, used to find player's position in the world


	// Use this for initialization
	void Start ()
	{
		nodeScript = GetComponent<Node>();
		Bob = GameObject.Find("BobObject").GetComponent<BobOverworldScript>();
		Button but = gameObject.GetComponent<Button>();

		but.onClick.AddListener(() => MoveHere());
	}

	/*
	 * MoveHere()
	 * Params: -
	 * Desc: Delegate function that is called when player clicks on the object.
	 * If player is already standing on the object, the assigned scene is loaded.
	 * A special case is meant for minigame scenes, where the scene to load is 
	 * stored into the GlobalGameManager, and "Cutscene" scene is loaded instead.
	*/
	void MoveHere ()
	{
		
		if (Bob.getCurrentNode () == nodeScript) {
			Bob.storePosition ();
			MusicPlayer.instance.PlaySoundEffect (MusicPlayer.instance.menuOk, 1);

			switch (sceneToLoad) {
			// Shop, Theater and Bob's apartment are loaded immediately
			case "Shop":
			case "Theater":
			case "Bob_apartment":
				SceneManager.LoadScene (sceneToLoad, LoadSceneMode.Single);
				break;
			// Minigames go through the "Cutscene" scene before minigame is
			// actually loaded.
			default:
				GlobalGameManager.GGM.currentScene = sceneToLoad;
				//SceneManager.LoadScene ("Cutscene", LoadSceneMode.Single);
                SceneManager.LoadScene ("CutScene (2)", LoadSceneMode.Single);
				break;
			}
			return;
		} else {
			// Start moving Bob if he's not already moving
			// See node.cs for more details on how the path finding works.
			if (!BobOverworldScript.Moving) {       
				Bob.startMoving (
					nodeScript.findPath (
						nodeScript,
						true,
						0, 
						Bob.getCurrentNode ()
					)
				);
				
			}
		}
	}
		
}
