using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomCiviliandefinition : ModBehaviour {

	[Tooltip("Can allow modder to input a mesh from imported model. StandardWhiteCivilian will be used if left Empty")]
	public SkinnedMeshRenderer meshRenderer; // can allow modder to input a mesh from imported model. StandardWhiteCivilian will be used if left Empty
	Mesh customMesh;
	Material[] customMats;

	[Tooltip("Walk Speed. Default: 1.5f")]
	public float walkSpeed = 1.5f;
	[Tooltip("Run Speed. Default: 5f")]
	public float runSpeed = 5f;
	[Tooltip("View Distace. Default: 15f. Does not affect reaction to gunshots and arrest commands")]
	public float viewDistance = 15f; 

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

	public AudioSource[] seeplayerAudio;
	public AudioSource[] injuredAudio;
	public AudioSource[] surrenderingAudio;
	public AudioSource[] refusalAudio;
	public AudioSource[] restrainedAudio;
	public AudioSource[] runawayAudio;
	public AudioSource[] crowdcontrolledAudio;

	CustomAIHealthandGibs enemyHealthGibs;

	public AnimationClip customIdleAnimation;
	public AnimationClip customRunAnimation;


    public void Awake() {
		CustomCivilianBridgetoMain enemyBridge = this.gameObject.AddComponent<CustomCivilianBridgetoMain> ();

		customMesh = meshRenderer.sharedMesh;
		customMats = meshRenderer.materials;

		enemyBridge.modelScale = this.transform.localScale;

		enemyBridge.modMesh = customMesh;
		enemyBridge.customMats = customMats;

		enemyHealthGibs = this.GetComponent<CustomAIHealthandGibs> ();

		enemyBridge.walkSpeed = walkSpeed;
		enemyBridge.runSpeed = runSpeed;

		enemyBridge.minFearLevel = minFearLevel;
		enemyBridge.maxFearLevel = maxFearLevel;
		enemyBridge.minCourageLevel = minCourageLevel;
		enemyBridge.maxCourageLevel = maxCourageLevel;

		enemyBridge.flashbangedDuration = flashbangedDuration;
		enemyBridge.stunnedDuration = stunnedDuration;

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

		enemyBridge.passthroughCustomEnemyData ();
		//System.GC.Collect ();
    }

}
