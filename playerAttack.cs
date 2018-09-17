using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class playerAttack : MonoBehaviour
{

	public GameObject PlayerCharacter;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//when firing your weapon check to confirm bullets are above 0
		if (Input.GetButtonDown("Action") && PlayerCharacter.GetComponent<playerController>().Bullets >= 1)
		{
			--PlayerCharacter.GetComponent<playerController>().Bullets;
		}
	}

	//Fire weapon and detect radius cycle through and find closest enemy in radius, reduce nearest monster hp
	private void OnTriggerStay(Collider other)
	{
		

		if (other.CompareTag("enemy"))
		{
			other.tag = "enemyActive";
		}
		
		GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("enemyActive");

		float enemyTracker = Mathf.Infinity;
		int updatedTracker = 0;
		//when firing weapon check if enemy is in radius and you have amo if so, damage enemy - take out nearest 
		if (Input.GetButtonDown("Action") && PlayerCharacter.GetComponent<playerController>().Bullets >= 1)
		{
			for (int i = 0; i < enemyArray.Length; i++) 
			{
				float distanceChecker =
					Vector3.Distance(PlayerCharacter.transform.position, enemyArray[i].transform.position);

				if (distanceChecker < enemyTracker)
				{
					enemyTracker = distanceChecker;
					updatedTracker = i;
				}

			}

			if (enemyArray.Length > 0)
			{
				Debug.Log(enemyArray[updatedTracker] + " " +
				          enemyArray[updatedTracker].GetComponent<monsterScript>().MonsterHealth);
				--enemyArray[updatedTracker].GetComponent<monsterScript>().MonsterHealth;
			}

		}
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("enemyActive"))
		{
			other.tag = "enemy";
		}
	}
}
