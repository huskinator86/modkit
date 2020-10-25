﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModTool.Interface;

public class GameManagerDefinition : ModBehaviour {

	public GameObject[] spawnPoints;

	//if empty, default custom music will be used
	public AudioClip customIdleMusicLoop;
	//action music will be played when combat is initiated
	public bool useActionMusic;
	public AudioClip customActionMusicLoop;

	public int enemyCount = 5;
	public int civCount = 5;

	#region
	// Use this for initialization
	void Start () {
		GMModBridge gmBridge = this.gameObject.AddComponent<GMModBridge> ();

		gmBridge.sp1Position = spawnPoints [0].transform.position;
		gmBridge.sp2Position = spawnPoints [1].transform.position;
		gmBridge.sp3Position = spawnPoints [2].transform.position;
		gmBridge.sp4Position = spawnPoints [3].transform.position;

		gmBridge.enemyCount = enemyCount;
		gmBridge.civCount = civCount;

		if (customIdleMusicLoop != null) {
			gmBridge.customIdleMusicLoop = customIdleMusicLoop;
		}

		gmBridge.useActionMusic = useActionMusic;

		if (customActionMusicLoop != null) {
			gmBridge.customActionMusicLoop = customActionMusicLoop;
		}

		gmBridge.passthroughGMData ();

		gmBridge.enabled = true;

	}
	#endregion
}
