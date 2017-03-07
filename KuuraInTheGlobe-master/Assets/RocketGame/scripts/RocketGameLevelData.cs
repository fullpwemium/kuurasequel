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

}
