using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class PresetDoorBridgetoMain : ModBehaviour {

	public bool doorhandleRight=false;

	public string doorColor;
	public string frameColor;
	public string dooropenangle;

	public Vector3 doorPosition;
	public Vector3 doorScale;
	public Quaternion doorRotation;
	DoorPresetBridge doorBridge;

	// Use this for initialization

	public void passthroughDoorData(){
		DoorPresetBridge doorBridge = this.gameObject.AddComponent<DoorPresetBridge> ();

		doorBridge.doorPosition = this.transform.position;
		doorBridge.doorRotation = this.transform.rotation;
		doorBridge.doorScale = this.transform.localScale;

		doorBridge.doorRight = doorhandleRight;
		doorBridge.doorColor = doorColor;
		doorBridge.frameColor = frameColor;
		doorBridge.dooropenSize = dooropenangle;

		doorBridge.runcreationMethod ();

		doorBridge.enabled = true;		
	}
}
