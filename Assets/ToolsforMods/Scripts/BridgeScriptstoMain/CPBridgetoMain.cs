using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CPBridgetoMain : ModBehaviour {

	public string cpString;

	// Use this for initialization
	void Start () {
		CoverPointBridge cpMaingame = this.gameObject.AddComponent<CoverPointBridge> ();

		if (cpString == "leftcover") {
			cpMaingame.leftCover = true;
			cpMaingame.crouchCover = false;
			cpMaingame.rightCover = false;
		}
		if (cpString == "rightcover") {
			cpMaingame.leftCover = false;
			cpMaingame.crouchCover = false;
			cpMaingame.rightCover = true;
		}
		if (cpString == "crouchcover") {
			cpMaingame.leftCover = false;
			cpMaingame.crouchCover = true;
			cpMaingame.rightCover = false;
		}
	}
}
