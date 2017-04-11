using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Node
 * Node script for the improved pathfinding algorithm, implements Dijkstra's algorithm (if albeit messy).
*/

public class Node : MonoBehaviour {

	// List of available nodes around the tile
	// These should be set inside the 
	public 	List<Node> nodes;

	// The weight of the node this is attached to
	// Can be used to make some paths more favorable
	// than others, as each node is considered to
	// weight at least 1. Thus the path with least
	// weight is used and returned.
	public  int weight = 0;

	// Internal variables for pathfinding
	private bool visited = false;
	private int	currentDepth = -1;

	/*
	 * reset()
	 * Params: -
	 * Desc: Reset the node's internal values
	*/
	private void reset ()
	{
		visited = false;
		currentDepth = -1;
	}

	/*
	 * checkDepth()
	 * Params: 
	 *  - int depth : the current depth of the search (in nodes)
	 * Desc: Checks the current depth of the node and sees if it
	 * is lower than a previously found value. 
	*/
	private bool checkDepth ( int depth )
	{
		if (visited) {
			if (depth < currentDepth) {
				currentDepth = depth;
			}
		} else {
			visited = true;
			currentDepth = depth;
		}
		return (currentDepth == depth);
	}

	/*
	 * findPath()
	 * Params: 
	 *  - Node lastVisitedNode : last node that was used in the current search chain
	 *  - bool startingNode : boolean that is used to check if the current node called is the starting one
	 *  - Node targetNode : the target that the pathfinding algorithm is trying to reach
	 * Desc: A function that is called recursively to find the least heavy path to the target node.
	 * Of note is that the initial function call to this should always pass startingNode as "true",
	 * as the function will internally always use "false".
	*/

	public List<Node> findPath ( Node lastVisitedNode, bool startingNode, int depth, Node targetNode ) {
		List<Node> finalPath = new List<Node>();

		if (this == targetNode) {
			finalPath.Add (this);
			return finalPath;
		}
			
		if (startingNode) {
		} else {
			finalPath.Add (this);
		}
			
		List<Node> neighbouringPaths = new List<Node>();
		foreach ( Node node in nodes )
		{
			if ( lastVisitedNode != node && node.checkDepth(depth+1) ) {
				// Ask neighbouring nodes if Bob is standing on it
				List<Node> temp = new List<Node>();
				temp.AddRange ( node.findPath ( this, false, depth+1+weight, targetNode ) );

				// Check if the neighboring nodes contain Bob,
				// and if true check for length. If this path
				// is lower than what is previously found,
				// overwrite.
				if (temp.Count > 0) {
					Node lastNode = temp [temp.Count - 1];
					if (lastNode == targetNode) {
						if (neighbouringPaths.Count == 0) {
							neighbouringPaths = temp;
						} else {
							if (temp.Count < neighbouringPaths.Count) {
								// Shorter path was found; overwrite previous one
								neighbouringPaths = temp;
							}
						}
					}
				}
			}
		}

		finalPath.AddRange (neighbouringPaths);

		if (startingNode) {
			// Reverse the order of the calculated path and remove the first node,
			// which is the one Bob is already standing on.
			finalPath.Reverse ();
			finalPath.Add (this);
			finalPath.RemoveAt (0);


			Node[] allNodes = FindObjectsOfType (typeof(Node)) as Node[];
			foreach (Node node in allNodes) {
				node.reset ();
			}
		} 

		// Return final calculated path
		return finalPath;
	}
		
}
