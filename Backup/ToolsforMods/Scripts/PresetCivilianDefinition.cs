using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class PresetCivilianDefinition : ModBehaviour {

	//Is the Civilian Male? Unchecked = Female
	public bool genderMale = false;

	// Use this for initialization
	void Awake () {
		/*
		GameObject civbridgePrefab = Instantiate (Resources.Load ("Prefabs/civbridgePrefab")) as GameObject;
		CivModBridgeMain civBridge = civbridgePrefab.gameObject.GetComponent<CivModBridgeMain>();

		*/

		CivModBridgeMain civBridge = this.gameObject.AddComponent<CivModBridgeMain> ();

		civBridge.maleCiv = genderMale;

		this.GetComponent<MeshRenderer> ().enabled = false;		

		civBridge.passthroughCivData ();

		civBridge.enabled = true;
	}

}
