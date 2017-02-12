using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Node script for the improved pathfinding algorithm, implements Dijkstra's algorithm*/

public class Node : MonoBehaviour {

	// List of available nodes around the tile
	public 	List<Node> nodes;
	private bool visited = false;
	private int	currentDepth = -1;
	public  int weight = 0;

	private void reset ()
	{
		visited = false;
		currentDepth = -1;
	}

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
		
	public List<Node> findPath ( Node lastVisitedNode, bool startingNode, int depth, Node targetNode ) {
		List<Node> finalPath = new List<Node>();

		if (this == targetNode) {
			//Debug.Log ("BOBI LOYTYI TAALTA: " + this);
			finalPath.Add (this);
			return finalPath;
		}


		if (startingNode) {
		//	Debug.Log ("Aloitusnode haulle: " + lastVisitedNode);
		} else {
			finalPath.Add (this);
		}
			
		List<Node> neighbouringPaths = new List<Node>();
		foreach ( Node node in nodes )
		{
			if ( lastVisitedNode != node && node.checkDepth(depth+1) ) {
				// Lähetä kysely naapurinodeihin Bobin olemassaolosta
				List<Node> temp = new List<Node>();
				temp.AddRange ( node.findPath ( this, false, depth+1+weight, targetNode ) );

				// Tarkista onko naapurinoden vastauksessa Bobin nodea,
				// ja ylitsekirjoita entinen reitti jos se on lyhyempi
				if (temp.Count > 0) {
					Node lastNode = temp [temp.Count - 1];
					if (lastNode == targetNode) {
						if (neighbouringPaths.Count == 0) {
							neighbouringPaths = temp;
						} else {
							if (temp.Count < neighbouringPaths.Count) {
								//Debug.Log ("Found shorter path");
								neighbouringPaths = temp;
							}
						}
					}
				}
			}
		}

		finalPath.AddRange (neighbouringPaths);

		// ...
		if (startingNode) {
			finalPath.Reverse ();
			finalPath.Add (this);
			finalPath.RemoveAt (0);

			//Debug.Log (finalPath.Count);

			Node[] allNodes = FindObjectsOfType (typeof(Node)) as Node[];
			foreach (Node node in allNodes) {
				node.reset ();
			}
		} 

		return finalPath;
	}
		
}
