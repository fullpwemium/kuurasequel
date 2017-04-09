using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * PathFollower
 * The movement script that moves Bob along a path on the overworld.
*/

public class PathFollower : MonoBehaviour {

	// Speed at which Bob moves
	public float speed = 0.8f;

	// Current list of nodes player will move through
	private List<Node> currentPath;

	// Node currently occupied
	public Node currentNode;

	// Currently targeted node in the path
	private Transform targetNode;

	// Is running?
	private bool start = false;
	private GameObject obj;
	private Vector2 lastDirection;

	/*
	 * getLastDirection()
	 * Params: -
	 * Desc: Returns the direction player last moved towards.
	*/
	public Vector2 getLastDirection ()
	{
		return lastDirection;
	}

	/*
	 * setParent()
	 * Params: 
	 *  - GameObject newParent : the parent object this script is to be attached to
	 * Desc: Sets the object this script should move when path is followed.
	*/
	public void setParent ( GameObject newParent )
	{
		obj = newParent;
	}

	/*
	 * init()
	 * Params: 
	 *  - List<Node> path : the path that player will take to find its target node
	 * Desc: Initializes the movement towards the targeted node.
	*/
	public void init ( List<Node> path )
	{
		//Debug.Log ( path.Count );
		currentPath = path;
		targetNode = path[0].GetComponent<Transform> ();
		start = true;
		if (obj == null) {
			obj = this.gameObject;
		}
	}

	/*
	 * setCurrentNode()
	 * Params: 
	 *  - Node node : the node player is currently standing on
	 * Desc: Set the node on which player stands
	*/
	public void setCurrentNode ( Node node )
	{
		currentNode = node;
	}

	/*
	 * getCurrentNode()
	 * Params: -
	 * Desc: Return the node on which player stands
	*/
	public Node getCurrentNode ( )
	{
		return currentNode;
	}

	/*
	 * run()
	 * Params: -
	 * Desc: Function that advances player's movement towards the
	 * targeted node by one tick. Call in successive frames to
	 * eventually end up at the correct target.
	*/
	public bool run ( )
	{

		bool result = true;
		if (start) {
			targetNode = currentPath[0].GetComponent<Transform> ();
			start = false;
		}

		float rads = Mathf.Atan2 (
			targetNode.position.x - obj.transform.position.x, 
			targetNode.position.y - obj.transform.position.y
		);
			
		lastDirection = new Vector2 ( Mathf.Cos (rads), Mathf.Sin(rads));

		float step = (speed + obj.transform.lossyScale.x * 10 ) * Time.fixedDeltaTime;
		float dist = Vector2.Distance (obj.transform.position, targetNode.position);
		Vector2 pos = Vector2.MoveTowards (obj.transform.position, targetNode.position, step);
		obj.transform.position = new Vector3 (pos.x, pos.y, obj.transform.position.z);

		if (dist < step) {
			step = step - dist;
			if (currentPath.Count > 0) {
				targetNode = currentPath [0].GetComponent<Transform> ();
				currentNode = currentPath [0];
				currentPath.RemoveAt (0);
			} else {
				result = false;
			}
			pos = Vector2.MoveTowards (obj.transform.position, targetNode.position, step);
			obj.transform.position = new Vector3 (pos.x, pos.y, obj.transform.position.z);
		}
		return result;
	}
}
