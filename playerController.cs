using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public partial class playerController : MonoBehaviour
{
	
	//Partials - ItemPickup and PlayerAimAttack

	//Movement Variables
	private static float baseSpeed = 15.0f; //The control of the players speed
	public float MoveSpeed = baseSpeed; //movespeed is adjusted based on the base speed and other factors in the game
	public float RotateSpeed = 150.0f; //how fast the player character can rotate
	
	//Physical Variables 
	public int playerHealth = 10;
	public GameObject aimArea;
	public Text ammoCount;
	public Text clipCount;
	
	//Inventory Tracking
	public int Bullets = 25;
	public int clipSize = 15;
	public int maxClipSize = 15;
	
	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update ()
	{
		ammoCount.text = Bullets.ToString();
		clipCount.text = clipSize.ToString();
		
	    PlayerMovement();

		PlayerAimAttack();
		
	}

	private void PlayerMovement()
	{
		//Basic Movement
		transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * RotateSpeed, 0);
		transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed);
		//Slow down when backing up (back button is negative numbers)
		MoveSpeed = Input.GetAxis("Vertical") <= 0 ? baseSpeed / 5 : baseSpeed;
	}

}
