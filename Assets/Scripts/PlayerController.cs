using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float movespeed;
	public float maxspeed;
	public float initial_gravity;

	Rigidbody playerRB;


	void Awake()
	{
		playerRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, initial_gravity, 0);

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

	#region GravityFunctions
    public void change_gravity(float gravity_x, float gravity_y) {
        Physics.gravity = new Vector3(gravity_x, gravity_y, 0);
    }
    #endregion

}
