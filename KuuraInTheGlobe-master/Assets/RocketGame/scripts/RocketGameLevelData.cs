using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * RocketGameLevelData
 * Script that is used to serialize level data from JSON files under Assets/RocketGame/rocketgamelevels.
 * Note that the game has 10 levels, and 11th level is the endless mode.
*/

[System.Serializable]
public class RocketGameLevelData
{
	// Current level in question
	public int level;

	// Minimum & maximum spawn interval for obstacles
	public float spawnMin;
	public float spawnMax;

	// Altitude player starts from in this level
	public float startAltitude;

	// Altitude player needs to reach to get to the next level
	public float targetAltitude;

	// What background objects can spawn in current level
	// This is used to start spawning stars when you reach higher altitudes
	// See gameplaySystem object in _rocketGame-Gameplay scene, 
	// and check the public BackgroundObjectList for indexes
	public int bgObjectMin;
	public int bgObjectMax;

	// Minimum & maximum spawn interval for background objects
	public int bgSpawnMin;
	public int bgSpawnMax;

	// If Nth object to be spawned is not fuel, force a guaranteed fuel drop to spawn as well
	public int spawnFuelEvery; 

	// See gameplaySystem object in _rocketGame-Gameplay scene, 
	// and check the public SpawnableObjectList for indexes
	public float spawnFuel; 		// object 0
	public float spawnBadCloud; 	// object 1
	public float spawnSnow; 		// object 2
	public float spawnLava; 		// object 3
	public float spawnPoison; 		// object 4
	public float spawnVenom; 		// object 5
	public float spawnEvil; 		// object 6

}
