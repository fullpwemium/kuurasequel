using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RocketGameLevelData
{
	public int level;
	public float spawnMin;
	public float spawnMax;

	public float startAltitude;
	public float targetAltitude;

	public float spawnFuel; // object 1
	public float spawnBadCloud; // object 2
	public float spawnEvil; // object 5
	public float spawnPoison; // object 3
	public float spawnVenom; // object 4

}
