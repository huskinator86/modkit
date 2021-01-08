using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomWeaponBridgetoMain : ModBehaviour {
	public string WeaponName;

	public float bulletDamage;
	public bool automaticFire;
	public float autofireRate;
	public float impactForce;
	public float enemyalertRange;

	public float minSpread;
	public float maxSpread;
	public float spreadIncrease;
	public float spreadDecrease;
	public float recoil;
	public float bracedRecoil;

	public int magSize;
	public int maxAmmo;

	public int shotgunPellets; //only for shotguns

	public bool isShotgun=false;
	public bool isbreakAction = false;

	public Vector3 ironSightPosition;

	public GameObject customMuzzleFlash;
	public Vector3 muzzlePosition;
	public Quaternion muzzleRotation;

	public GameObject grabHandleR;
	public Vector3 grabHandleRscale;
	public Vector3 grabHandleRposition;
	public Quaternion grabHandleRrotation;
	public Vector3 grabHandleRcolliderCenter;
	public Vector3 grabHandleRcolliderSize;

	public GameObject grabHandleL;
	public Vector3 grabHandleLscale;
	public Vector3 grabHandleLposition;
	public Quaternion grabHandleLrotation;
	public Vector3 grabHandleLcolliderCenter;
	public Vector3 grabHandleLcolliderSize;

	public GameObject offhandgrabHandleR;
	public Vector3 offhandgrabHandleRscale;
	public Vector3 offhandgrabHandleRposition;
	public Quaternion offhandgrabHandleRrotation;
	public Vector3 offhandgrabHandleRcolliderCenter;
	public Vector3 offhandgrabHandleRcolliderSize;

	public GameObject offhandgrabHandleL;
	public Vector3 offhandgrabHandleLscale;
	public Vector3 offhandgrabHandleLposition;
	public Quaternion offhandgrabHandleLrotation;
	public Vector3 offhandgrabHandleLcolliderCenter;
	public Vector3 offhandgrabHandleLcolliderSize;

	public Vector3 magazineDropPoint;
	public GameObject magazinePrefab;	

	public Vector3 bulletshellEjectionPosition;
	public Quaternion bulletshellEjectionRotation;

	public AudioSource dryfireAudio;
	public AudioSource livefireAudio;
	public AudioSource magInsertAudio;
	public AudioSource magReleaseAudio;
	public AudioSource hammerPullAudio;
	public AudioSource hammerReleaseAudio;

	public Mesh gunframeMesh;
	public Vector3 gunframePosition;
	public Quaternion gunframeRotation;
	public Vector3 gunframeScale;
	public Material[] gunframeMats;

	public Mesh magazineMesh;
	public Vector3 magazinePosition;
	public Quaternion magazineRotation;
	public Vector3 magazineScale;
	public Material[] magazineMats;

	public Mesh hammerMesh;
	public Vector3 hammerPosition;
	public Quaternion hammerRotation;
	public Vector3 hammerScale;
	public Material[] hammerMats;

	public Mesh ejectorslideMesh;
	public Vector3 ejectorslidedefaultPosition;
	public Vector3 ejectorslideEjectionPosition;
	public Quaternion ejectorslideRotation;
	public Vector3 ejectorslideScale;
	public Material[] ejectorslideMats;

	CustomWeaponBridge custWeapon;

	public Vector3 ammoCounterPosition;
	public Quaternion ammoCounterRotation;

	public Vector3 GunBulletSlideOpenPosition;
	public Vector3 GunBoltMaxPulledPosition;

	public string shellCaliber;

	public GameObject[] breakactionShellCasings;

	public bool hammerslidebackonFire=false;

	public void runcustomweaponbridge(){	
		custWeapon = this.gameObject.AddComponent<CustomWeaponBridge> ();

		custWeapon.weaponName = WeaponName;

		custWeapon.isShotgun = isShotgun;
		custWeapon.isBreakAction = isbreakAction;

		custWeapon.automaticFire = automaticFire;
		custWeapon.autofireRate = autofireRate;
		custWeapon.impactForce = impactForce;
		custWeapon.enemyalertRange = enemyalertRange;

		custWeapon.minSpread = minSpread;
		custWeapon.maxSpread = maxSpread;
		custWeapon.spreadIncrease = spreadIncrease;
		custWeapon.spreadDecrease = spreadDecrease;
		custWeapon.recoil = recoil;
		custWeapon.bracedRecoil = bracedRecoil;

		custWeapon.weaponDamage = bulletDamage;

		custWeapon.magSize = magSize;
		custWeapon.maxAmmo = maxAmmo;

		custWeapon.ironSightPosition = ironSightPosition;

		custWeapon.customMuzzleFlash = customMuzzleFlash;
		custWeapon.muzzlePosition = muzzlePosition;
		custWeapon.muzzleRotation = muzzleRotation;
		custWeapon.grabHandleRscale = grabHandleRscale;
		custWeapon.grabHandleRposition = grabHandleRposition;
		custWeapon.grabHandleRrotation = grabHandleRrotation;
		custWeapon.grabHandleRcolliderCenter = grabHandleRcolliderCenter;
		custWeapon.grabHandleRcolliderSize = grabHandleRcolliderSize;

		custWeapon.grabHandleLscale = grabHandleLscale;
		custWeapon.grabHandleLposition = grabHandleLposition;
		custWeapon.grabHandleLrotation = grabHandleLrotation;
		custWeapon.grabHandleLcolliderCenter = grabHandleLcolliderCenter;
		custWeapon.grabHandleLcolliderSize = grabHandleLcolliderSize;

		custWeapon.offhandgrabHandleRscale = offhandgrabHandleRscale;
		custWeapon.offhandgrabHandleRposition = offhandgrabHandleRposition;
		custWeapon.offhandgrabHandleRrotation = offhandgrabHandleRrotation;
		custWeapon.offhandgrabHandleRcolliderCenter = offhandgrabHandleRcolliderCenter;
		custWeapon.offhandgrabHandleRcolliderSize = offhandgrabHandleRcolliderSize;

		custWeapon.offhandgrabHandleLscale = offhandgrabHandleLscale;
		custWeapon.offhandgrabHandleLposition = offhandgrabHandleLposition;
		custWeapon.offhandgrabHandleLrotation = offhandgrabHandleLrotation;
		custWeapon.offhandgrabHandleLcolliderCenter = offhandgrabHandleLcolliderCenter;
		custWeapon.offhandgrabHandleLcolliderSize = offhandgrabHandleLcolliderSize;

		custWeapon.magazineDropPoint = magazineDropPoint;

		custWeapon.magazinePrefab = magazinePrefab;	

		custWeapon.bulletshellEjectionPosition = bulletshellEjectionPosition;
		custWeapon.bulletshellEjectionRotation = bulletshellEjectionRotation;

		custWeapon.hammerslidewhenFired = hammerslidebackonFire;

		if (dryfireAudio != null) {
			custWeapon.dryfireAudio = dryfireAudio;
		}

		if (livefireAudio != null) {
			custWeapon.livefireAudio = livefireAudio;
		}

		if (magInsertAudio != null) {
			custWeapon.magInsertAudio = magInsertAudio;
		}

		if (magReleaseAudio != null) {
			custWeapon.magReleaseAudio = magReleaseAudio;
		}

		if (gunframeMesh != null) {
			custWeapon.gunframeMesh = gunframeMesh;
			custWeapon.gunframePosition = gunframePosition;
			custWeapon.gunframeRotation = gunframeRotation;
			custWeapon.gunframeScale = gunframeScale;
			custWeapon.gunframeMats = gunframeMats;
		}

		if (magazineMesh != null) {
			custWeapon.magazineMesh = magazineMesh;
			custWeapon.magazinePosition = magazinePosition;
			custWeapon.magazineRotation = magazineRotation;
			custWeapon.magazineScale = magazineScale;
			custWeapon.magazineMats = magazineMats;
		}

		if (hammerMesh != null) {
			custWeapon.hammerMesh = hammerMesh;
			custWeapon.hammerPosition = hammerPosition;
			custWeapon.hammerRotation = hammerRotation;
			custWeapon.hammerScale = hammerScale;
			custWeapon.hammerMats = hammerMats;
		}

		if (ejectorslideMesh != null) {
			custWeapon.ejectorslideMesh = ejectorslideMesh;
			custWeapon.ejectorslidedefaultPosition = ejectorslidedefaultPosition;
			custWeapon.ejectorslideRotation = ejectorslideRotation;
			custWeapon.ejectorslideScale = ejectorslideScale;
			custWeapon.ejectorslideMats = ejectorslideMats;			
		}

		if (breakactionShellCasings != null) {
			if (breakactionShellCasings.Length > 0) {
				custWeapon.breakactionShells = breakactionShellCasings;
			}
		}

		custWeapon.ammoCounterPosition = ammoCounterPosition;
		custWeapon.ammoCounterRotation = ammoCounterRotation;

		custWeapon.shellCaliber = shellCaliber;

		custWeapon.hammerMaxPullPosition = GunBoltMaxPulledPosition;
		custWeapon.ejectorslideEjectionPosition = GunBulletSlideOpenPosition;


		custWeapon.runcustomweaponprefabMethod ();


		this.gameObject.SetActive (false);
	}
}
