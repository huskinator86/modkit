using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class DestructableBridgetoMain : ModBehaviour {

	public float itemHp;
	public bool alertsEnemyonDeath = false;

	public GameObject destroyedgibPrefab;

	public Mesh mesh;

	DestroyableItemBridge destructableBridge;

	// Use this for initialization
	public void passthroughdestructableData () {
		destructableBridge = this.gameObject.AddComponent<DestroyableItemBridge> ();
		destructableBridge.itemHp = itemHp;
		destructableBridge.alertsenemyonDeath = alertsEnemyonDeath;
		destructableBridge.gibReference = destroyedgibPrefab;		
		destructableBridge.customMesh = mesh;

		destructableBridge.rundestructablecreationMethod ();

		destructableBridge.enabled = true;
	}

}
