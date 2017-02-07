using UnityEngine;
using System.Collections;

public class Storage : MonoBehaviour
{
    public static int[] MemoryGameStars = new int[200];
    public static Storage manager; 
	// Use this for initialization
	void Awake ()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
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
