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

	public int bgObjectMin;
	public int bgObjectMax;
	public int bgSpawnMin;
	public int bgSpawnMax;

	public int spawnFuelEvery; // If Nth object to be spawned is not fuel, force a guaranteed fuel drop to spawn as well

	public float spawnFuel; // object 0
	public float spawnBadCloud; // object 1
	public float spawnSnow; //object 2
	public float spawnLava; //object 3
	public float spawnPoison; // object 4
	public float spawnVenom; // object 5
	public float spawnEvil; // object 6


}
