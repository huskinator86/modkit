using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ModTool.Interface;

public class MissionInfoDefinition: ModBehaviour {

	string missionDescription;
	public Texture missionPicture;

	// Use this for initialization
	void Awake () {
		LevelDescriptionBridge gameLevelInfo = this.gameObject.AddComponent<LevelDescriptionBridge> ();

		missionDescription = this.GetComponent<Text> ().text;	

		gameLevelInfo.customlevelPic = missionPicture;
		gameLevelInfo.custommissionDesc = missionDescription;
		gameLevelInfo.missionDefinitionAdjust ();
	}
}
