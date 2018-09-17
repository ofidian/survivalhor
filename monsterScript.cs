using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class monsterScript : MonoBehaviour
{

	public int MonsterHealth = 10; //the total damage the object can take before it dies
	static float MonsterSpeed = 4; //the speed at which the monster moves
	public Transform chaseTarget; //determine target for object to chase
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//destroy monster if health reduced below 0
		if (MonsterHealth <= 0)
		{
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnterChild()
	{
		Debug.Log("method triggered");
		//move monster towards player in a direct path
		transform.position = Vector3.MoveTowards(transform.position, chaseTarget.position, MonsterSpeed * Time.deltaTime);
		
	}
}
