using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class DestroyableItemDefinition : ModBehaviour {

	public float itemHp;
	public bool alertsEnemyonDeath = false;

	public GameObject destroyedgibPrefab;

	ExplosiveItemDefinition explosiveItem;

	// Use this for initialization
	void Awake () {
		DestructableBridgetoMain destructableBridge = this.gameObject.AddComponent<DestructableBridgetoMain> ();

		explosiveItem = this.GetComponent<ExplosiveItemDefinition> ();
		if (explosiveItem != null) {
			destructableBridge.isExplosive = true;	
			destructableBridge.explosionDamage = explosiveItem.explosionDamage;
			destructableBridge.explosionForce = explosiveItem.explosionForce;
			destructableBridge.explosionGibGO = explosiveItem.explosionFX;
			destructableBridge.explosionRange = explosiveItem.explosionRange;
		}

		destructableBridge.mesh = this.gameObject.GetComponent<MeshFilter> ().mesh;
		destructableBridge.itemHp = itemHp;
		destructableBridge.alertsEnemyonDeath = alertsEnemyonDeath;
		destructableBridge.destroyedgibPrefab = destroyedgibPrefab;	

		destructableBridge.passthroughdestructableData ();

		destructableBridge.enabled = true;
	}
}
