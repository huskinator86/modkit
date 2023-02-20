using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CivModBridgeMain : ModBehaviour {

	public bool maleCiv;

	public bool prioritySpawn;

	CivilianSpawnBridge civbridgeMain;

	// Use this for initialization
	public void passthroughCivData () {
		civbridgeMain = this.gameObject.AddComponent<CivilianSpawnBridge> ();
		civbridgeMain.maleCiv = maleCiv;

		civbridgeMain.prioritySpawn = prioritySpawn;

		civbridgeMain.runcivprefabMethod ();

		civbridgeMain.enabled = true;
				
	}
}
