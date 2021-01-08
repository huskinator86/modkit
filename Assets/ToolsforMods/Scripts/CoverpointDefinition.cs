using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CoverpointDefinition : ModBehaviour {

	public enum covering{leftcover,crouchcover,rightcover};
	public covering coverType; 

	// Use this for initialization
	void Start () {/*
		GameObject cpbridgePrefab = Instantiate (Resources.Load ("Prefabs/cpbridgePrefab")) as GameObject;
		cpbridgePrefab.transform.position = this.transform.position;
		cpbridgePrefab.transform.rotation = this.transform.rotation;*/
		
		CPBridgetoMain toCPbridge = this.gameObject.AddComponent<CPBridgetoMain> ();
		//CPBridgetoMain toCPbridge = cpbridgePrefab.gameObject.GetComponent<CPBridgetoMain> ();

		this.GetComponent<MeshRenderer> ().enabled = false;

		toCPbridge.cpString = coverType.ToString ();
		toCPbridge.enabled = true;
	}

}
