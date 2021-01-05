using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ModTool.Interface;

public class CustomAIHealthandGibs : ModBehaviour {

	//enemyHP stuff
	public int mainHp = 20; //Main Enemy Health
	public int headHp = 25; //Head HP before Gib
	public int leftlegHp = 25; //LeftlegHP before Gib
	public int rightlegHp = 25; //RightlegHP before Gib
	public int leftarmHp = 25; //LeftarmHP before Gib
	public int rightarmHp = 25; //RightarmHP before Gib

	public GameObject headGib;
	public GameObject leftarmGib;
	public GameObject rightarmGib;
	public GameObject leftlegGib;
	public GameObject rightlegGib;
}
