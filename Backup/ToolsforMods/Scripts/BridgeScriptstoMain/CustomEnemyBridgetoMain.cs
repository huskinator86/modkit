using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomEnemyBridgetoMain : ModBehaviour {

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

	//Main Weapon Info    
	public Mesh mainWeapon;
	public ParticleSystem mainWeaponMuzzleFlash;
	public float mainWeaponFirerate=2f;
	public AudioSource mainWeaponsound;
	public float enemyAccuracy = 0.01f;
	public float reloadTimer = 0.8f;
	public int maxBullets = 15;

	public int minshotsperInterval = 5;
	public int maxshotsperInterval = 10;

	public float attackRange = 35f;

	//Offhand Weapon Info
	public Mesh offhandWeapon;
	public ParticleSystem offhandWeaponMuzzleFlash;
	public float offhandWeaponFirerate;
	public AudioSource offhandWeaponsound;

	//Misc Stats
	public bool meleeUser = false;
	public bool patroller = false;
	public int patrolPath = 1;

	public AudioSource[] alertedAudio;
	public AudioSource[] surprisedAudio;
	public AudioSource[] injuredAudio;
	public AudioSource[] attackAudio;
	public AudioSource[] injuredAttackAudio;
	public AudioSource[] surrenderingAudio;
	public AudioSource[] fakeSurrenderAudio;
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

	public string animationType;
	public string weaponType;

	public AnimationClip customIdleAnimation;
	public AnimationClip customWalkAnimation;
	public AnimationClip customRunAnimation;
	public AnimationClip customShootAnimation;
	public AnimationClip customReloadAnimation;

	// Use this for initialization
	public void passthroughCustomEnemyData () {
		CustomEnemySpawnBridge enemyBridge = this.gameObject.AddComponent<CustomEnemySpawnBridge> ();

		enemyBridge.modMesh = modMesh;
		enemyBridge.customMats = customMats;

		enemyBridge.enemyScale = modelScale;

		enemyBridge.animationType = animationType;

		enemyBridge.baseWeapon = weaponType;

		enemyBridge.walkSpeed = walkSpeed;
		enemyBridge.runSpeed = runSpeed;

		enemyBridge.minFearLevel = minFearLevel;
		enemyBridge.maxFearLevel = maxFearLevel;
		enemyBridge.minCourageLevel = minCourageLevel;
		enemyBridge.maxCourageLevel = maxCourageLevel;

		enemyBridge.flashbangedDuration = flashbangedDuration;
		enemyBridge.stunnedDuration = stunnedDuration;
		enemyBridge.pepperedDuration = pepperedDuration;

		enemyBridge.surprisable = surprisable;
		enemyBridge.mainWeapon = mainWeapon;
		enemyBridge.mainWeaponMuzzleFlash= mainWeaponMuzzleFlash;
		enemyBridge.mainWeaponsound = mainWeaponsound;

		enemyBridge.mainWeaponFirerate = mainWeaponFirerate;
		enemyBridge.enemyAccuracy = enemyAccuracy;
		enemyBridge.reloadTimer = reloadTimer;
		enemyBridge.minshotsperInterval = minshotsperInterval;
		enemyBridge.maxshotsperInterval = maxshotsperInterval;

		enemyBridge.maxBullets = maxBullets;
		enemyBridge.attackRange = attackRange;

		enemyBridge.offhandWeapon = offhandWeapon;
		enemyBridge.offhandWeaponMuzzleFlash = offhandWeaponMuzzleFlash;
		enemyBridge.offhandWeaponsound = offhandWeaponsound;

		enemyBridge.offhandWeaponFirerate = offhandWeaponFirerate;

		enemyBridge.meleeUser = meleeUser;
		enemyBridge.patroller = patroller;
		enemyBridge.patrolPath = patrolPath;

		enemyBridge.customIdleAnimation = customIdleAnimation;
		enemyBridge.customWalkAnimation = customWalkAnimation;
		enemyBridge.customRunAnimation = customRunAnimation;
		enemyBridge.customShootAnimation = customShootAnimation;
		enemyBridge.customReloadAnimation = customReloadAnimation;

		if (alertedAudio!=null) {
			enemyBridge.alertedAudio = new AudioSource[alertedAudio.Length];
			alertedAudio.CopyTo (enemyBridge.alertedAudio,0);
			//enemyBridge.alertedAudio = alertedAudio;
		}
		if (surprisedAudio!=null) {
			enemyBridge.surprisedAudio = new AudioSource[surprisedAudio.Length];
			surprisedAudio.CopyTo (enemyBridge.surprisedAudio,0);
			//enemyBridge.surprisedAudio = surprisedAudio;

		}
		if (injuredAudio!=null) {
			enemyBridge.injuredAudio = new AudioSource[injuredAudio.Length];
			injuredAudio.CopyTo (enemyBridge.injuredAudio,0);
			//enemyBridge.injuredAudio = injuredAudio;

		}
		if (attackAudio!=null) {
			enemyBridge.attackAudio = new AudioSource[attackAudio.Length];
			attackAudio.CopyTo (enemyBridge.attackAudio,0);
			//enemyBridge.attackAudio = attackAudio;

		}
		if (injuredAttackAudio!=null) {
			enemyBridge.injuredAttackAudio = new AudioSource[injuredAttackAudio.Length];
			injuredAttackAudio.CopyTo (enemyBridge.injuredAttackAudio,0);
			//enemyBridge.injuredAttackAudio = injuredAttackAudio;

		}
		if (surrenderingAudio!=null) {
			enemyBridge.surrenderingAudio = new AudioSource[surrenderingAudio.Length];
			surrenderingAudio.CopyTo (enemyBridge.surrenderingAudio,0);
			//enemyBridge.surrenderingAudio = surrenderingAudio;

		}
		if (fakeSurrenderAudio!=null) {
			enemyBridge.fakeSurrenderAudio = new AudioSource[fakeSurrenderAudio.Length];
			fakeSurrenderAudio.CopyTo (enemyBridge.fakeSurrenderAudio,0);
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
