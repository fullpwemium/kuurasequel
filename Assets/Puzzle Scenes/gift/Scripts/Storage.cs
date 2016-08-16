using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour
{
    public static int[] MemoryGameStars = new int[200];

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static void Save()
    {
        MemoryGameStars = GlobalManager.memoryGameStars;
        Debug.Log("Storage; " + MemoryGameStars);
    }
}
