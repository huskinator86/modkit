using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class PresetDoorDefinition : ModBehaviour {

	public bool doorhandleRight=false;
	public enum doormeshcolor{brown,blue,green,red,black}
	public doormeshcolor doorColor;

	public enum framemeshcolor{brown,darkgrey,lightgrey,beige}
	public framemeshcolor frameColor;

	public enum dooropenangle{max100,max110,max170}
	public dooropenangle dooropenAngle;
		 
	#region
	// Use this for initialization
	void Awake () {
		PresetDoorBridgetoMain doorBridge = this.gameObject.AddComponent<PresetDoorBridgetoMain> ();

		doorBridge.doorPosition = this.transform.position;
		doorBridge.doorRotation = this.transform.rotation;
		doorBridge.doorScale = this.transform.localScale;

		doorBridge.doorhandleRight = doorhandleRight;
		doorBridge.doorColor = doorColor.ToString ();
		doorBridge.frameColor = frameColor.ToString ();
		doorBridge.dooropenangle = dooropenAngle.ToString ();

		doorBridge.passthroughDoorData ();

		doorBridge.enabled = true;
	}
	#endregion
}
