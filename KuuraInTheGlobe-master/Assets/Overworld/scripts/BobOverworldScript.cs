using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

/*
 * BobOverWorldScript
 * Script that oversees Bob's animation and movement on the overworld. 
*/

public class BobOverworldScript : MonoBehaviour
{
	private Animator BobPlayerAnimator;
	private PathFollower pathfinder;

	public static bool Moving;

	void Start ()
	{

		BobPlayerAnimator = transform.FindChild("BobPlayer").GetComponent<Animator>();

		// Set player's position
		GameObject startingNode = GameObject.Find (
			                          GlobalGameManager.GGM.getPlayerPositionOnMap ()
		                          );

		Vector3 vec = startingNode.GetComponent<Transform>().position;
		this.transform.position = new Vector3 (vec.x, vec.y, this.transform.position.z);

		// Set current node to the pathfinder
		pathfinder = this.GetComponent<PathFollower> ();
		pathfinder.setParent (this.transform.gameObject);
		pathfinder.setCurrentNode (
			startingNode.GetComponent<Node> ()
		);

		// Print current position to console
		Debug.Log ("Bobin alotusnode: " + pathfinder.getCurrentNode());

		// Scale bob based on current position
		BobScale();
	
	}
		

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Moving) { 
			Moving = pathfinder.run ();
			Animate ();
			BobScale ();
			if (!Moving) {
				storePosition ();
			}
		} 
			
	}

	/*
	 * startMoving()
	 * Params: 
	 *  - List<Node> path : List of nodes that map player's path
	 * Desc: Assign the path to pathfinder script and start moving.
	*/
	public void startMoving ( List<Node> path )
	{
		if (path.Count == 0) {
			return;
		}
			
		Moving = true;
		pathfinder.init ( path );

	}

	/*
	 * getCurrentNode() 
	 * Params: -
	 * Desc: Return the current node player is currently standing on
	*/
	public Node getCurrentNode ( )
	{
		return pathfinder.getCurrentNode ();
	}

	/*
	 * BobScale()
	 * Params: -
	 * Desc: handles scaling Bob on the overworld based on his y-position on the screen
	 * Change the scaleFactor inside the Unity editor to change by how much his sprite is affected.
	 * The bigger scaleFactor is, the bigger Bob becomes.
	*/
	public float scaleFactor = 0.05F;
	void BobScale() 
	{
		transform.transform.localScale = new Vector2(
			Mathf.Abs(transform.transform.position.y * scaleFactor), 
			Mathf.Abs(transform.transform.position.y * scaleFactor)
		);
	}

	/*
	 * Animate()
	 * Params: -
	 * Desc: animates bob based on if he's moving or not. If Bob is moving, check's the last direction
	 * moved towards in the pathfinder script (pathfinder.getLastDirection). animationState is also used
	 * to control the current animation, namely by activating the idle stance if animationState == -1.
	*/
	int animationState = -1;
	void Animate()
	{
		// Check if Bob is standing still
		if (!Moving && animationState > -1) {
			BobPlayerAnimator.SetTrigger("BobDown");
			animationState = -1;
			return;
		}

		// Get last direction
		Vector2 dir = pathfinder.getLastDirection ();

		// Adjust the angles at which Bob picks between "up" or "down" animations instead of "left" or "right"
		double constant = 0.35; 
		if (dir.y < 0) {
			if (dir.x > constant) {
				if (animationState != 0) {
					BobPlayerAnimator.SetTrigger ("BobUp");
					animationState = 0;
				}
			} else if (dir.x < -constant) {
				if (animationState != 1) {
					BobPlayerAnimator.SetTrigger ("BobDown");
					animationState = 1;
				}
			} else {
				if (animationState != 2) {
					BobPlayerAnimator.SetTrigger ("BobLeft");
					animationState = 2;
				}
			}
		} else {

			if (dir.x > constant) {
				if (animationState != 0) {
					BobPlayerAnimator.SetTrigger ("BobUp");
					animationState = 0;
				}
			} else if (dir.x < -constant) {
				if (animationState != 1) {
					BobPlayerAnimator.SetTrigger ("BobDown");
					animationState = 1;
				}
			} else {
				if (animationState != 3) {
					BobPlayerAnimator.SetTrigger ("BobRight");
					animationState = 3;
				}
			}
		}
	}

	/*
	 * storePosition() 
	 * Params: -
	 * Desc: Store's bob's current node position inside GlobalGameManager. This is used in order
	 * to recover and later move Bob to the correct position after the overworld scene is loaded
	 * or exited.
	*/
	public void storePosition () {
		GlobalGameManager.GGM.setPlayerPositionOnMap (pathfinder.getCurrentNode().gameObject.name);
	}

	// Guard release builds from any troublemakers!
	#if UNITY_EDITOR
	void Update() {
		DELETE_PLAYERPREFS ();
	}
	#endif

	/*
	 * DELETE_PLAYERPREFS()
	 * Params: -
	 * Desc: Delete all progress player has gained from the playerprefs. 
	 * Intended for debug purposes only!
	 */
	public void DELETE_PLAYERPREFS() {
		//Combination: Z + X + C
		if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.C)) && Input.GetKeyDown(KeyCode.Z))
		{
			PlayerPrefs.DeleteAll ();
		}
	}

}
