using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomDoorDefinition : ModBehaviour {

	public AudioSource doorOpenAudio;
	public AudioSource doorCloseAudio;

	public float doorHP=10f;

	public GameObject doorknobGib;
	public GameObject fulldoorGib;

	public Transform vrdoorHandle;

	// Use this for initialization
	void Awake(){
		CustomDoorBridgetoMain custdoorBridge = this.gameObject.AddComponent<CustomDoorBridgetoMain> ();

		custdoorBridge.skindoorMesh = this.gameObject.GetComponent<SkinnedMeshRenderer> ();

		custdoorBridge.doorHP = doorHP;
		custdoorBridge.doorOpenAudio = doorOpenAudio;
		custdoorBridge.doorCloseAudio = doorCloseAudio;	

		custdoorBridge.doorknobGib = doorknobGib;
		custdoorBridge.fulldoorGib = fulldoorGib;	
		custdoorBridge.vrdoorHandle = vrdoorHandle;

		custdoorBridge.passthroughdestructableData ();

		custdoorBridge.enabled = true;
	}
}
