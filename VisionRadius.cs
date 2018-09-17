using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRadius : MonoBehaviour
{

	public GameObject ParentObject;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Debug.Log("is Player");
			ParentObject.GetComponent<monsterScript>().OnTriggerEnterChild();
		}
	}
}
