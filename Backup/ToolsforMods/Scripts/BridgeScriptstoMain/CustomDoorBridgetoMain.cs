using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomDoorBridgetoMain : ModBehaviour {

	public SkinnedMeshRenderer skindoorMesh;

	public AudioSource doorOpenAudio;
	public AudioSource doorCloseAudio;

	public DoorCustomBridge doorBridge;
	public float doorHP;

	public GameObject doorknobGib;
	public GameObject fulldoorGib;

	public Transform vrdoorHandle;

	// Use this for initialization
	public void passthroughdestructableData () {
		doorBridge = this.gameObject.AddComponent<DoorCustomBridge> ();

		doorBridge.skindoorMesh = this.gameObject.GetComponent<SkinnedMeshRenderer> ();

		doorBridge.doorHP = doorHP;
		doorBridge.doorOpenAudio = doorOpenAudio;
		doorBridge.doorCloseAudio = doorCloseAudio;	

		doorBridge.doorknobGib = doorknobGib;
		doorBridge.gibReference = fulldoorGib;
		doorBridge.vrdoorHandle = vrdoorHandle;

		doorBridge.passthroughCustomDoorData ();

	}
}
