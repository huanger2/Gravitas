using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float movespeed;
	public float maxspeed;

	Rigidbody playerRB;


	void Awake()
	{
		playerRB = gameObject.GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Movement
		float MoveHor = Input.GetAxisRaw("Horizontal");
		Vector2 movement = new Vector2(MoveHor * movespeed, 0);
		movement = movement * Time.deltaTime;

		playerRB.AddForce(movement);
		if (playerRB.velocity.x > maxspeed)
		{
			playerRB.velocity = new Vector2(maxspeed, playerRB.velocity.y);
		}
		if (playerRB.velocity.x < -maxspeed)
		{
			playerRB.velocity = new Vector2(-maxspeed, playerRB.velocity.y);
		}

	}

}
