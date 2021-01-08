using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class EnemyModBridgeMain : ModBehaviour {

	public bool patroller = false;
	public bool shotgunner = false;
	public bool sitting = false;

	public bool suicideCharge=false;

	public int patrolPath;

	public string enemyType;

	EnemySpawnBridge mainEnemySpawn;


	// Use this for initialization
	public void passthroughenemyData () {
		mainEnemySpawn = this.gameObject.AddComponent<EnemySpawnBridge> ();

		mainEnemySpawn.patroller = patroller;
		mainEnemySpawn.shotgunner = shotgunner;
		mainEnemySpawn.sitting = sitting;
		mainEnemySpawn.suicideCharge = suicideCharge;
		mainEnemySpawn.patrolPath = patrolPath;
		mainEnemySpawn.enemyType = enemyType;

		mainEnemySpawn.runenemyprefabMethod ();

		mainEnemySpawn.enabled = true;
	}

}
