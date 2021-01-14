using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class GMModBridge : ModBehaviour {

	public Vector3 sp1Position;
	public Vector3 sp2Position;
	public Vector3 sp3Position;
	public Vector3 sp4Position;

	//if empty, default custom music will be used
	public AudioClip customIdleMusicLoop;
	//action music will be played when combat is initiated
	public bool useActionMusic;
	public AudioClip customActionMusicLoop;

	public int enemyCount = 5;
	public int civCount = 5;

	// Use this for initialization
	public void passthroughGMData () {
		
		GameManagerBridge gamemanagerBridge = this.gameObject.AddComponent<GameManagerBridge> ();

		gamemanagerBridge.sp1Position = sp1Position;
		gamemanagerBridge.sp2Position = sp2Position;
		gamemanagerBridge.sp3Position = sp3Position;
		gamemanagerBridge.sp4Position = sp4Position;

		gamemanagerBridge.maxEnemies = enemyCount;
		gamemanagerBridge.maxCivilians = civCount;

		if (customIdleMusicLoop != null) {
			gamemanagerBridge.customIdleMusicLoop = customIdleMusicLoop;
		}

		gamemanagerBridge.useActionMusic = useActionMusic;

		if (customActionMusicLoop != null) {
			gamemanagerBridge.customActionMusicLoop = customActionMusicLoop;
		}

		gamemanagerBridge.runcreationMethod ();

		gamemanagerBridge.enabled = true;
	}
}
