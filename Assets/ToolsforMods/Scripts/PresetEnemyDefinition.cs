using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class PresetEnemyDefinition : ModBehaviour {

	[Tooltip("Is this enemy a Patroller. Or Will he stand around in his postion")]
	public bool patroller = false;

	[Tooltip("Set at 1 - Enemy will travel along Waypoint1 tagged items. Set at 2 - Enemy will travel along Waypoint2 tagged items. Etc...")]
	public int patrolPath=1;

	[Tooltip("Does this enemy hold a shotgun? Does not apply for TecDragons or Fake Civilian Archetypes")]
	public bool shotgunner = false;

	[Tooltip("Does this enemy spawn in a Sitting Pose")]
	public bool sitting = false;

	[Tooltip("Only applies to SuicideBombers. Sets whether they will do a countdown or charge the player")]
	public bool suicideCharge=false;

	[Tooltip("Main Game will give priority to this spawnpoint")]
	public bool prioritySpawn = false;

	public enum gang{mohawk,tecdragon,hustler,fakeCiv,suitedMen,maskedMohawk,suicideBomber}
	public gang enemyArchetype;

	// Use this for initialization

	void Awake () {
		/*
		GameObject enemybPrefab = Instantiate (Resources.Load ("Prefabs/enemybridgePrefab")) as GameObject;
		enemyBridge = enemybPrefab.GetComponent<EnemyModBridgeMain> ();
*/

		EnemyModBridgeMain enemyBridge = this.gameObject.AddComponent<EnemyModBridgeMain> ();

		//enemyBridge.gameObject.transform.position = this.transform.position;
		//enemyBridge.gameObject.transform.rotation = this.transform.rotation;

		enemyBridge.patroller = patroller;
		enemyBridge.shotgunner = shotgunner;
		enemyBridge.sitting = sitting;
		enemyBridge.suicideCharge = suicideCharge;
		enemyBridge.patrolPath = patrolPath;

		enemyBridge.prioritySpawn = prioritySpawn;

		enemyBridge.enemyType = enemyArchetype.ToString ();

		this.GetComponent<MeshRenderer> ().enabled = false;

		enemyBridge.passthroughenemyData ();

		enemyBridge.enabled = true;
	}

}
