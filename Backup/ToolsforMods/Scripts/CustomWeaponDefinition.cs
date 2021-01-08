using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomWeaponDefinition : ModBehaviour {
	public string WeaponName;

	[Tooltip("Full Auto?")]
	public bool automaticFire;
	[Tooltip("Full Auto Fire Rate")]
	public float autofireRate = 10f;
	[Tooltip("Physical Impact on Target")]
	public float impactForce = 1f;
	[Tooltip("Range that the weapon alerts Enemies")]
	public float enemyalertRange = 10f;

	public float bulletDamage = 10f;

	public float minSpread = 0.01f;
	public float maxSpread = 0.1f;
	public float spreadIncrease = 30f;
	public float spreadDecrease = 30f;
	public float recoil = 5f;
	public float bracedRecoil = 2f;

	[Tooltip("Ammo Per Magazine")]
	public int magSize = 30;
	[Tooltip("Max Ammo in Pouch when Spawned")]
	public int maxAmmo = 120;

	[Tooltip("Pellets Shot by Shotgun. Only applies to Shotguns")]
	public int shotgunPellets; 

	public Transform AmmoCounter;

	public Transform ironSightPosition;

	public GameObject Muzzle;

	public Transform RightGrabHandle;
	public Transform LeftGrabHandle;
	public Transform RightOffhandGrabHandle;
	public Transform LeftOffhandGrabHandle;
	public Transform BulletEjectionPoint;
	public Transform MagazineDropPoint;
	public GameObject MagazinePrefab;	

	public AudioSource dryfireAudio;
	public AudioSource livefireAudio;
	public AudioSource magInsertAudio;
	public AudioSource magReleaseAudio;
	public AudioSource hammerPullAudio;
	public AudioSource hammerReleaseAudio;

	[Tooltip("Will the Slide Move when Gun is Fired? Mainly for Pistols")]
	public bool hammerslidebackonFire=false;

	public GameObject GunFrame;

	public GameObject Magazine;


	public GameObject GunBulletSlide;
	public Vector3 GunBulletSlideOpenPosition;

	public GameObject GunBolt;

	//public Vector3 GunBoltMaxPulledPosition;


	public enum shellcaliber{Small,Large}
	public shellcaliber shellCaliber;


	public void Awake(){	
		CustomWeaponBridgetoMain custWeapon = this.gameObject.AddComponent<CustomWeaponBridgetoMain> ();

		custWeapon.WeaponName = WeaponName;

		custWeapon.bulletDamage = bulletDamage;
		custWeapon.automaticFire = automaticFire;
		custWeapon.autofireRate = autofireRate;
		custWeapon.impactForce = impactForce;
		custWeapon.enemyalertRange = enemyalertRange;

		custWeapon.maxSpread = maxSpread;
		custWeapon.spreadIncrease = spreadIncrease;
		custWeapon.spreadDecrease = spreadDecrease;
		custWeapon.recoil = recoil;
		custWeapon.bracedRecoil = bracedRecoil;

		custWeapon.minSpread = minSpread;
		custWeapon.magSize = magSize;
		custWeapon.maxAmmo = maxAmmo;

		if (ironSightPosition != null) {
			custWeapon.ironSightPosition = ironSightPosition.localPosition;
		}

		if (Muzzle != null) {
			custWeapon.customMuzzleFlash = Muzzle;

			custWeapon.muzzlePosition = Muzzle.transform.localPosition;
			custWeapon.muzzleRotation = Muzzle.transform.localRotation;
		}

		if (RightGrabHandle != null) {
			custWeapon.grabHandleRscale = RightGrabHandle.transform.localScale;
			custWeapon.grabHandleRposition = RightGrabHandle.transform.localPosition;
			custWeapon.grabHandleRrotation = RightGrabHandle.transform.localRotation;
			custWeapon.grabHandleRcolliderCenter = RightGrabHandle.GetComponent<BoxCollider> ().center;
			custWeapon.grabHandleRcolliderSize = RightGrabHandle.GetComponent<BoxCollider> ().size;
		}

		if (LeftGrabHandle != null) {
			custWeapon.grabHandleLscale = LeftGrabHandle.transform.localScale;
			custWeapon.grabHandleLposition = LeftGrabHandle.transform.localPosition;
			custWeapon.grabHandleLrotation = LeftGrabHandle.transform.localRotation;
			custWeapon.grabHandleLcolliderCenter = LeftGrabHandle.GetComponent<BoxCollider> ().center;
			custWeapon.grabHandleLcolliderSize = LeftGrabHandle.GetComponent<BoxCollider> ().size;
		}

		if (RightOffhandGrabHandle != null) {
			custWeapon.offhandgrabHandleRscale = RightOffhandGrabHandle.transform.localScale;
			custWeapon.offhandgrabHandleRposition = RightOffhandGrabHandle.transform.localPosition;
			custWeapon.offhandgrabHandleRrotation = RightOffhandGrabHandle.transform.localRotation;
			custWeapon.offhandgrabHandleRcolliderCenter = RightOffhandGrabHandle.GetComponent<BoxCollider> ().center;
			custWeapon.offhandgrabHandleRcolliderSize = RightOffhandGrabHandle.GetComponent<BoxCollider> ().size;
		}

		if (LeftOffhandGrabHandle != null) {
			custWeapon.offhandgrabHandleLscale = LeftOffhandGrabHandle.transform.localScale;
			custWeapon.offhandgrabHandleLposition = LeftOffhandGrabHandle.transform.localPosition;
			custWeapon.offhandgrabHandleLrotation = LeftOffhandGrabHandle.transform.localRotation;
			custWeapon.offhandgrabHandleLcolliderCenter = LeftOffhandGrabHandle.GetComponent<BoxCollider> ().center;
			custWeapon.offhandgrabHandleLcolliderSize = LeftOffhandGrabHandle.GetComponent<BoxCollider> ().size;
		}

		custWeapon.magazineDropPoint = MagazineDropPoint.localPosition;

		custWeapon.magazinePrefab = MagazinePrefab;	

		custWeapon.hammerslidebackonFire = hammerslidebackonFire;

		if (BulletEjectionPoint != null) {
			custWeapon.bulletshellEjectionPosition = BulletEjectionPoint.transform.localPosition;
			custWeapon.bulletshellEjectionRotation = BulletEjectionPoint.transform.localRotation;
		}

		if (dryfireAudio != null) {
			if (dryfireAudio.clip != null) {
				custWeapon.dryfireAudio = dryfireAudio;
			}
		}

		if (livefireAudio != null) {
			if (livefireAudio.clip != null) {
				custWeapon.livefireAudio = livefireAudio;
			}
		}

		if (magInsertAudio != null) {
			if (magInsertAudio.clip != null) {
				custWeapon.magInsertAudio = magInsertAudio;
			}
		}

		if (magReleaseAudio != null) {
			if (magReleaseAudio.clip != null) {
				custWeapon.magReleaseAudio = magReleaseAudio;
			}
		}

		if (GunFrame != null) {
			custWeapon.gunframeMesh = GunFrame.GetComponent<MeshFilter> ().mesh;
			custWeapon.gunframePosition = GunFrame.transform.localPosition;
			custWeapon.gunframeRotation = GunFrame.transform.localRotation;
			custWeapon.gunframeScale = GunFrame.transform.localScale;
			custWeapon.gunframeMats = GunFrame.GetComponent<MeshRenderer> ().materials;
		}

		if (Magazine != null) {
			custWeapon.magazineMesh = Magazine.GetComponent<MeshFilter> ().mesh;
			custWeapon.magazinePosition = Magazine.transform.localPosition;
			custWeapon.magazineRotation = Magazine.transform.localRotation;
			custWeapon.magazineScale = Magazine.transform.localScale;
			custWeapon.magazineMats = Magazine.GetComponent<MeshRenderer> ().materials;
		}

		if (GunBolt != null) {
			custWeapon.hammerMesh = GunBolt.GetComponent<MeshFilter> ().mesh;
			custWeapon.hammerPosition = GunBolt.transform.localPosition;
			custWeapon.hammerRotation = GunBolt.transform.localRotation;
			custWeapon.hammerScale = GunBolt.transform.localScale;
			custWeapon.hammerMats = GunBolt.GetComponent<MeshRenderer> ().materials;
		}

		//custWeapon.GunBoltMaxPulledPosition = GunBoltMaxPulledPosition;
		if (GunBulletSlide != null) {
			custWeapon.ejectorslideMesh = GunBulletSlide.GetComponent<MeshFilter> ().mesh;
			custWeapon.ejectorslidedefaultPosition = GunBulletSlide.transform.localPosition;
			custWeapon.ejectorslideRotation = GunBulletSlide.transform.localRotation;
			custWeapon.ejectorslideScale = GunBulletSlide.transform.localScale;
			custWeapon.ejectorslideMats = GunBulletSlide.GetComponent<MeshRenderer> ().materials;
		}

		custWeapon.ammoCounterPosition = AmmoCounter.localPosition;
		custWeapon.ammoCounterRotation = AmmoCounter.localRotation;

		if(shellCaliber==shellcaliber.Small){
			custWeapon.shellCaliber = "SmallCaliber";
		}
		if(shellCaliber==shellcaliber.Large){
			custWeapon.shellCaliber = "LargeCaliber";
		}

		custWeapon.runcustomweaponbridge ();
		custWeapon.enabled = true;

	}
}
