using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using ModTool.Interface;

public class CustomAIdefinition : ModBehaviour {

	public SkinnedMeshRenderer meshRenderer; // can allow modder to input a mesh from imported model. Mohawk will be used if left Empty
	Mesh customMesh;
	Material[] customMats;

	public enum baseweaponType{Pistol,DualPistol,DualSMG,SingleUZI,Shotgunner,RifleAK,RifleG36};
	public baseweaponType weaponType;

    public float walkSpeed = 1.5f;
    public float runSpeed = 5f;

    //Enemy Interaction is based on Fear and Courage. Enemies will surrender with a Fear Level of 7 and Higher
    //Enemies with a Courage Level <= 4 will try to run for Cover
    //Enemies with a Courage Level >4 and <8 will hold their ground and shoot the player
    //Enemies with a Courage Level >8 will chase the player if out of line of sight.
    //Enemies with a Courage Level >5 and a Fear Level between 4 and 6 will attempt a Fake Surrender.
    public int minFearLevel;
    public int maxFearLevel;
    public int minCourageLevel;
    public int maxCourageLevel;

    public float flashbangedDuration; //how many (s) this enemy will remain flashbanged. putting 0 makes them immune
    public float stunnedDuration; //how many (s) this enemy will remain stunned. putting 0 makes them immune
    public float pepperedDuration; //how many (s) this enemy will remain peppersprayed. putting 0 makes them immune

    public bool surprisable = false; //choose if this enemy will be surprised to see player (if unalerted)

	//Misc Stats
	//public bool meleeUser = false;
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


	public enum animationType{PistolSideways,PistolProper,DualWieldSideways,DualWieldVertical,DualWieldHipfire,SMGOnehand,SMGHipfire, ShotgunHipfire,RifleProper};
	public animationType animType;

	CustomAIWeaponRdefinition mainhandWeaponinfo;
	CustomAIWeaponLdefinition offhandWeaponinfo;
	CustomAIHealthandGibs enemyHealthGibs;

	public AnimationClip customIdleAnimation;
	public AnimationClip customWalkAnimation;
	public AnimationClip customRunAnimation;
	public AnimationClip customShootAnimation;
	public AnimationClip customReloadAnimation;

    public void Awake() {
		CustomEnemyBridgetoMain enemyBridge = this.gameObject.AddComponent<CustomEnemyBridgetoMain> ();

		customMesh = meshRenderer.sharedMesh;
		customMats = meshRenderer.materials;

		enemyBridge.modelScale = this.transform.localScale;
		enemyBridge.modMesh = customMesh;
		enemyBridge.customMats = customMats;

		mainhandWeaponinfo = this.GetComponent<CustomAIWeaponRdefinition> ();
		offhandWeaponinfo = this.GetComponent<CustomAIWeaponLdefinition> ();
		enemyHealthGibs = this.GetComponent<CustomAIHealthandGibs> ();

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

		//enemyBridge.mainWeapon = mainhandWeaponinfo.mainWeapon;
		//enemyBridge.mainWeaponMuzzleFlash= mainhandWeaponinfo.mainWeaponMuzzleFlash;
		//enemyBridge.mainWeaponsound = mainhandWeaponinfo.mainWeaponsound;

		enemyBridge.mainWeaponFirerate = mainhandWeaponinfo.mainWeaponFirerate;
		enemyBridge.enemyAccuracy = mainhandWeaponinfo.enemyAccuracy;
		enemyBridge.reloadTimer = mainhandWeaponinfo.reloadTimer;
		enemyBridge.minshotsperInterval = mainhandWeaponinfo.minshotsperInterval;
		enemyBridge.maxshotsperInterval = mainhandWeaponinfo.maxshotsperInterval;

		enemyBridge.maxBullets = mainhandWeaponinfo.maxBullets;
		enemyBridge.attackRange = mainhandWeaponinfo.attackRange;

		//enemyBridge.offhandWeapon = offhandWeaponinfo.offhandWeapon;
		//enemyBridge.offhandWeaponMuzzleFlash = offhandWeaponinfo.offhandWeaponMuzzleFlash;
		//enemyBridge.offhandWeaponsound = offhandWeaponinfo.offhandWeaponsound;
		enemyBridge.offhandWeaponFirerate = offhandWeaponinfo.offhandWeaponFirerate;

		//enemyBridge.meleeUser = meleeUser;
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

		enemyBridge.mainHp = enemyHealthGibs.mainHp;
		enemyBridge.headHp = enemyHealthGibs.headHp;
		enemyBridge.leftarmHp = enemyHealthGibs.leftarmHp;
		enemyBridge.rightarmHp = enemyHealthGibs.rightarmHp;
		enemyBridge.leftlegHp = enemyHealthGibs.leftlegHp;
		enemyBridge.rightlegHp = enemyHealthGibs.rightlegHp;

		if (enemyHealthGibs.headGib != null) {
			enemyBridge.headGib = enemyHealthGibs.headGib;
		}
		if (enemyHealthGibs.leftarmGib != null) {
			enemyBridge.leftarmGib = enemyHealthGibs.leftarmGib;
		}
		if (enemyHealthGibs.rightarmGib != null) {
			enemyBridge.rightarmGib = enemyHealthGibs.rightarmGib;
		}
		if (enemyHealthGibs.leftlegGib != null) {
			enemyBridge.leftlegGib = enemyHealthGibs.leftlegGib;
		}
		if (enemyHealthGibs.rightlegGib != null) {
			enemyBridge.rightlegGib = enemyHealthGibs.rightlegGib;
		}


		enemyBridge.animationType = animType.ToString ();
		enemyBridge.weaponType = weaponType.ToString ();

		enemyBridge.passthroughCustomEnemyData ();
		//System.GC.Collect ();
    }

}
