using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

	public float speed = 0.8f;
	private List<Node> currentPath;
	public Node currentNode;
	private Transform targetNode;
	private bool start = false;
	private GameObject obj;
	private Vector2 lastDirection;

	public Vector2 getLastDirection ()
	{
		return lastDirection;
	}

	public void setParent ( GameObject newParent )
	{
		obj = newParent;
	}

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

	public void setCurrentNode ( Node node )
	{
		currentNode = node;
	}

	public Node getCurrentNode ( )
	{
		return currentNode;
	}

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
