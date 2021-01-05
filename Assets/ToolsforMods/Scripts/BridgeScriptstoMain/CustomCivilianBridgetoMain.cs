using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomCivilianBridgetoMain : ModBehaviour {

	public Mesh modMesh;
	public Material[] customMats;

	public Vector3 modelScale;

	public float walkSpeed = 1.5f;
	public float runSpeed = 5f;
	public int minFearLevel;
	public int maxFearLevel;
	public int minCourageLevel;
	public int maxCourageLevel;

	public float flashbangedDuration; 
	public float stunnedDuration;
	public float pepperedDuration; 

	public bool surprisable = false; 

	public AudioSource[] seeplayerAudio;
	public AudioSource[] injuredAudio;
	public AudioSource[] surrenderingAudio;
	public AudioSource[] refusalAudio;
	public AudioSource[] restrainedAudio;
	public AudioSource[] runawayAudio;
	public AudioSource[] crowdcontrolledAudio;
	public AudioSource[] reloadweaponAudio;

	//enemyHP stuff
	public int mainHp = 20;
	public int headHp = 25;
	public int leftlegHp = 25;
	public int rightlegHp = 25;
	public int leftarmHp = 25;
	public int rightarmHp = 25;

	public GameObject headGib;
	public GameObject leftarmGib;
	public GameObject rightarmGib;
	public GameObject leftlegGib;
	public GameObject rightlegGib;

	public AnimationClip customIdleAnimation;
	public AnimationClip customRunAnimation;
	public float viewDistance = 15f; 


	// Use this for initialization
	public void passthroughCustomEnemyData () {
		CustomCivSpawnBridge enemyBridge = this.gameObject.AddComponent<CustomCivSpawnBridge> ();

		enemyBridge.civScale = modelScale;
		enemyBridge.modMesh = modMesh;
		enemyBridge.customMats = customMats;

		enemyBridge.walkSpeed = walkSpeed;
		enemyBridge.runSpeed = runSpeed;

		enemyBridge.minFearLevel = minFearLevel;
		enemyBridge.maxFearLevel = maxFearLevel;
		enemyBridge.minCourageLevel = minCourageLevel;
		enemyBridge.maxCourageLevel = maxCourageLevel;

		enemyBridge.flashbangedDuration = flashbangedDuration;
		enemyBridge.stunnedDuration = stunnedDuration;
		enemyBridge.pepperedDuration = pepperedDuration;

		enemyBridge.customIdleAnimation = customIdleAnimation;
		enemyBridge.customRunAnimation = customRunAnimation;

		enemyBridge.viewDistance = viewDistance;


		if (seeplayerAudio!=null) {
			enemyBridge.seeplayerAudio = new AudioSource[seeplayerAudio.Length];
			seeplayerAudio.CopyTo (enemyBridge.seeplayerAudio,0);
			//enemyBridge.alertedAudio = alertedAudio;
		}

		if (injuredAudio!=null) {
			enemyBridge.injuredAudio = new AudioSource[injuredAudio.Length];
			injuredAudio.CopyTo (enemyBridge.injuredAudio,0);
			//enemyBridge.injuredAudio = injuredAudio;

		}
		if (surrenderingAudio!=null) {
			enemyBridge.surrenderingAudio = new AudioSource[surrenderingAudio.Length];
			surrenderingAudio.CopyTo (enemyBridge.surrenderingAudio,0);
			//enemyBridge.surrenderingAudio = surrenderingAudio;

		}
		if (refusalAudio!=null) {
			enemyBridge.refusalAudio = new AudioSource[refusalAudio.Length];
			refusalAudio.CopyTo (enemyBridge.refusalAudio,0);
			//enemyBridge.fakeSurrenderAudio = fakeSurrenderAudio;

		}
		if (restrainedAudio!=null) {
			enemyBridge.restrainedAudio = new AudioSource[restrainedAudio.Length];
			restrainedAudio.CopyTo (enemyBridge.restrainedAudio,0);
			//enemyBridge.restrainedAudio = restrainedAudio;

		}
		if (runawayAudio!=null) {
			enemyBridge.runawayAudio = new AudioSource[runawayAudio.Length];
			runawayAudio.CopyTo (enemyBridge.runawayAudio,0);
			//enemyBridge.runawayAudio = runawayAudio;

		}
		if (crowdcontrolledAudio!=null) {
			enemyBridge.crowdcontrolledAudio = new AudioSource[crowdcontrolledAudio.Length];
			crowdcontrolledAudio.CopyTo (enemyBridge.crowdcontrolledAudio,0);
			//enemyBridge.crowdcontrolledAudio = crowdcontrolledAudio;

		}

		enemyBridge.mainHp = mainHp;
		enemyBridge.headHp = headHp;
		enemyBridge.leftarmHp = leftarmHp;
		enemyBridge.rightarmHp = rightarmHp;
		enemyBridge.leftlegHp = leftlegHp;
		enemyBridge.rightlegHp = rightlegHp;

		if (headGib != null) {
			enemyBridge.headGib = headGib;
		}
		if (leftarmGib != null) {
			enemyBridge.leftarmGib = leftarmGib;
		}
		if (rightarmGib != null) {
			enemyBridge.rightarmGib = rightarmGib;
		}
		if (leftlegGib != null) {
			enemyBridge.leftlegGib = leftlegGib;
		}
		if (rightlegGib != null) {
			enemyBridge.rightlegGib = rightlegGib;
		}

		enemyBridge.runenemyprefabMethod ();
		enemyBridge.enabled = true;
	}
}
