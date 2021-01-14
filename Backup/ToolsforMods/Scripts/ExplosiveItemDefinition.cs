using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class ExplosiveItemDefinition : ModBehaviour {

	[Tooltip("Explosion FX. Default Explosion used if left empty")]
	public GameObject explosionFX;
	[Tooltip("Damage done by Explosion - Default: 50")]
	public float explosionDamage = 50f;
	[Tooltip("Physics Force of Explosion - Default: 10 ")]
	public float explosionForce = 10f;
	[Tooltip("Range of Explosion - Default: 3")]
	public float explosionRange = 3f;

}
