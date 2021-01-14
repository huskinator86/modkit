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

	public bool isExplosive=false;
	public float explosionDamage;
	public float explosionForce;
	public GameObject explosionGibGO;
	public float explosionRange;


	// Use this for initialization
	public void passthroughdestructableData () {
		destructableBridge = this.gameObject.AddComponent<DestroyableItemBridge> ();
		destructableBridge.itemHp = itemHp;
		destructableBridge.alertsenemyonDeath = alertsEnemyonDeath;
		destructableBridge.gibReference = destroyedgibPrefab;		
		destructableBridge.customMesh = mesh;

		if (isExplosive) {
			destructableBridge.isExplosive = true;
			destructableBridge.explosionDamage = explosionDamage;
			destructableBridge.explosionForce = explosionForce;
			destructableBridge.explosionGibGO = explosionGibGO;
			destructableBridge.explosionRange = explosionRange;
		}

		destructableBridge.rundestructablecreationMethod ();

		destructableBridge.enabled = true;
	}

}
