using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomAIWeaponRdefinition : ModBehaviour {


    //Main Weapon Info    
    //public Mesh mainWeapon;
	//public ParticleSystem mainWeaponMuzzleFlash;
	//public AudioSource mainWeaponsound;

    public float mainWeaponFirerate=2f;

    public float enemyAccuracy = 0.015f; //the lower the number. the better the accuracy;

    public float attackRange = 35f;//default pistol range is 35f. smg 60f. ar 70f

	public int minshotsperInterval = 5; //min number of shots before npc takes a break from shooting
	public int maxshotsperInterval = 10; //max number of shots before npc takes a break from shooting

    public int maxBullets = 15; //double this number if character dual wields

	public float shotDelay = 0.15f; //amount of milliseconds before enemy starts shooting after aiming

	public float reloadTimer = 0.8f;
}
