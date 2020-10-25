using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class DestroyableItemDefinition : ModBehaviour {

	public float itemHp;
	public bool alertsEnemyonDeath = false;

	public GameObject destroyedgibPrefab;


	// Use this for initialization
	void Awake () {
		DestructableBridgetoMain destructableBridge = this.gameObject.AddComponent<DestructableBridgetoMain> ();

		destructableBridge.mesh = this.gameObject.GetComponent<MeshFilter> ().mesh;
		destructableBridge.itemHp = itemHp;
		destructableBridge.alertsEnemyonDeath = alertsEnemyonDeath;
		destructableBridge.destroyedgibPrefab = destroyedgibPrefab;	

		destructableBridge.passthroughdestructableData ();

		destructableBridge.enabled = true;
	}
}
