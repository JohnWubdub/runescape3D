using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	public Rigidbody rb;

	public bool won = false;

	public bool item1 = false;
	
	public bool item2 = false;
	
	public bool item3 = false;
	
	public bool item4 = false;

	public GameObject treasure;

	public GameObject notTreasure1;
	
	public GameObject notTreasure2;
	
	public GameObject notTreasure3;
	
	public GameObject notTreasure4;

	public float moveSpeed = 15;

	private String regular = "Welcome to Classic Runescape! Your quest is to collect all the items, and then go to the coins to collect your quest reward!";
	
	public Text hintText;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		hintText.text = regular;
		
		if (Input.GetKeyDown("w")) //going up
		{
			rb.AddForce(new Vector3(0, 0, -1) * moveSpeed);
		}

		if (Input.GetKeyDown("s")) //going down
		{
			rb.AddForce(new Vector3(0, 0, 1) * moveSpeed);
		}

		if (Input.GetKeyDown("d"))//moving to the right
		{
			rb.AddForce(new Vector3(-1, 0, 0) * moveSpeed);
		}

		if (Input.GetKeyDown("a")) //moving to the left
		{
			rb.AddForce(new Vector3(1, 0, 0) * moveSpeed);
		}
		
		if ( Vector3.Distance(transform.position, notTreasure1.transform.position) < 3f) 
		{ 
			hintText.text = "You picked up an iron sword!";
			item1 = true;
			
		} 
		if ( Vector3.Distance(transform.position, notTreasure2.transform.position) < 3f) 
		{ 
			hintText.text = "You picked up a black sheild!";
			item2 = true;
			
		}
		if ( Vector3.Distance(transform.position, notTreasure3.transform.position) < 3f) 
		{ 
			hintText.text = "You picked up a rune!";
			item3 = true;
			
		}
		if ( Vector3.Distance(transform.position, notTreasure4.transform.position) < 3f) 
		{ 
			hintText.text = "You picked up a cooked fish!";
			item4 = true;
			
		}
		
		if ( Vector3.Distance(transform.position, treasure.transform.position) < 3f) 
		{
			if (item1 == true && item2 == true && item3 == true && item4 == true)
			{
				hintText.text = "Press [SPACE] to turn in your quest!";
				if (Input.GetKey("space"))
				{
					won = true;
				}
			}
			else
			{
				hintText.text = "You are missing items!";
			}
		}

		if (won == true)
		{
			hintText.text = "You completed the quest! You picked up 100 coins!";
			regular = "You completed the quest! You picked up 100 coins!";
		}
		
	}
}
