using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class BobOverworldScript : MonoBehaviour
{
	private Animator BobPlayerAnimator;
	//int BobDirection = 20;
	//int OldBobDirection = 15;

	bool bobstill;

	int startDestinationX, startDestinationY;

	private PathFollower pathfinder;
	public static float aboveButton;

	public static Vector3 destination;


	public static bool Moving;

	OverworldSystemScript system;
	public GameObject systemPrefab;
	// Use this for initialization
	void Start ()
	{
		if (!GameObject.Find ("OverworldGameSystem")) {
			system = GameObject.Instantiate (systemPrefab).GetComponent<OverworldSystemScript> ();
			system.init ();
		} else {
			system = GameObject.Find ("OverworldGameSystem").GetComponent<OverworldSystemScript> ();
		}

		BobPlayerAnimator = transform.FindChild("BobPlayer").GetComponent<Animator>();

		pathfinder = this.GetComponent<PathFollower> ();
		pathfinder.setParent (this.transform.gameObject);

		Vector3 vec = GameObject.Find(system.getBobNodeName ()).GetComponent<Transform>().position;
		this.transform.position = new Vector3 (vec.x, vec.y, this.transform.position.z);
		pathfinder.setCurrentNode (GameObject.Find (system.getBobNodeName ()).GetComponent<Node> ());

		Debug.Log ("Bobin alotusnode: " + pathfinder.getCurrentNode());

		BobScale();
	
		//BobPlayerAnimator.SetTrigger("BobStanding");
	}

	int ReadFile(string file)
	{ 
		if(File.Exists(file))
		{
			var sr = File.OpenText(file);
			var line = sr.ReadLine();
			while(line != null)
			{
				Debug.Log(line); // prints each line of the file
				line = sr.ReadLine();
			}
			return 5;
		}
		else
		{
			return 5;
		}
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Moving) { 
			//movePath ();
			Moving = pathfinder.run ();
			Animate ();
			BobScale ();

		} else {
			

		}

	}

	public void startMoving ( List<Node> path )
	{
		if (path.Count == 0) {
			return;
		}
			
		Moving = true;
		pathfinder.init ( path );
	}

	public Node getCurrentNode ( )
	{
		return pathfinder.getCurrentNode ();
	}

	void BobScale()     //Skaalataan Bobia perspektiivin mukaan
	{
		transform.transform.localScale = new Vector2(
			Mathf.Abs(transform.transform.position.y * 0.05F), 
			Mathf.Abs(transform.transform.position.y * 0.05F)
		);
	}

	int animationState = -1;

	void Animate()
	{
		//Escape
		if (!Moving && animationState > -1) {
			BobPlayerAnimator.SetTrigger("BobDown");
			animationState = -1;
			return;
		}

		Vector2 dir = pathfinder.getLastDirection ();
		double constant = 0.35; //Adjust the angles at which Bob picks between "up" or "down" animations instead of "left" or "right"
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

	public void storePosition () {
		system.setBobNodeName (pathfinder.getCurrentNode().gameObject.name);
	}

}
