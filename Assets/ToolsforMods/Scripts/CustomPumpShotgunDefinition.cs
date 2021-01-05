using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomPumpShotgunDefinition : ModBehaviour {
	public string WeaponName;

	[Tooltip("Fire Rate")]
	public float fireRate = 1f;
	[Tooltip("Physical Impact on Target")]
	public float impactForce = 1f;
	[Tooltip("Range that the weapon alerts Enemies")]
	public float enemyalertRange = 10f;

	public float bulletDamage = 10f;

	public float minSpread = 0.1f;
	public float maxSpread = 0.1f;
	public float spreadIncrease = 30f;
	public float spreadDecrease = 30f;
	public float recoil = 5f;
	public float bracedRecoil = 2f;

	[Tooltip("Ammo Per Magazine")]
	public int magSize = 8;
	[Tooltip("Max Ammo in Pouch when Spawned")]
	public int maxAmmo = 24;

	[Tooltip("Pellets Shot by Shotgun. Only applies to Shotguns")]
	public int shotgunPellets=8; 

	public Transform AmmoCounter;

	public Transform ironSightPosition;

	public GameObject Muzzle;

	public Transform RightGrabHandle;
	public Transform LeftGrabHandle;
	public Transform RightOffhandGrabHandle;
	public Transform LeftOffhandGrabHandle;
	public Transform BulletEjectionPoint;

	public AudioSource dryfireAudio;
	public AudioSource livefireAudio;
	public AudioSource magInsertAudio;
	public AudioSource magReleaseAudio;
	public AudioSource hammerPullAudio;
	public AudioSource hammerReleaseAudio;

	public GameObject GunFrame;
	public GameObject Pump;
	//public Vector3 PumpMaxPulledPosition;

	public GameObject GunBulletSlide;

	public void Awake(){	
		CustomWeaponBridgetoMain custWeapon = this.gameObject.AddComponent<CustomWeaponBridgetoMain> ();

		custWeapon.WeaponName = WeaponName;

		custWeapon.isShotgun = true;

		custWeapon.bulletDamage = bulletDamage;

		custWeapon.autofireRate = fireRate;
		custWeapon.impactForce = impactForce;
		custWeapon.enemyalertRange = enemyalertRange;

		custWeapon.minSpread = minSpread;
		custWeapon.maxSpread = maxSpread;
		custWeapon.spreadIncrease = spreadIncrease;
		custWeapon.spreadDecrease = spreadDecrease;
		custWeapon.recoil = recoil;
		custWeapon.bracedRecoil = bracedRecoil;

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

		if (Pump != null) {
			custWeapon.hammerMesh = Pump.GetComponent<MeshFilter> ().mesh;
			custWeapon.hammerPosition = Pump.transform.localPosition;
			custWeapon.hammerRotation = Pump.transform.localRotation;
			custWeapon.hammerScale = Pump.transform.localScale;
			custWeapon.hammerMats = Pump.GetComponent<MeshRenderer> ().materials;		
		}

		if (GunBulletSlide != null) {
			custWeapon.ejectorslideMesh = GunBulletSlide.GetComponent<MeshFilter> ().mesh;
			custWeapon.ejectorslidedefaultPosition = GunBulletSlide.transform.localPosition;
			custWeapon.ejectorslideRotation = GunBulletSlide.transform.localRotation;
			custWeapon.ejectorslideScale = GunBulletSlide.transform.localScale;
			custWeapon.ejectorslideMats = GunBulletSlide.GetComponent<MeshRenderer> ().materials;		
		}

		custWeapon.ammoCounterPosition = AmmoCounter.localPosition;
		custWeapon.ammoCounterRotation = AmmoCounter.localRotation;

		custWeapon.runcustomweaponbridge ();
		custWeapon.enabled = true;

	}
}
