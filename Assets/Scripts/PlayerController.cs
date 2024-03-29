using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float movespeed;
	public float maxspeed;
	public bool has_gravity;

	#region Exit variables
	public bool exited = false;

	public CapsuleCollider exit;

	#endregion

	Rigidbody playerRB;


	void Awake()
	{
		playerRB = gameObject.GetComponent<Rigidbody>();

	}

	void Update()
	{
		//Movement

		float MoveHor = Input.GetAxisRaw("Horizontal");
		if (MoveHor == 0) {
			playerRB.velocity = new Vector3(0,playerRB.velocity.y, playerRB.velocity.z);
		} else {
			Vector3 movement = new Vector3(MoveHor * movespeed, 0, 0);
			movement = movement * Time.deltaTime;

			playerRB.AddForce(movement);
			if (playerRB.velocity.x > maxspeed)
			{
				playerRB.velocity = new Vector3(maxspeed, 0, playerRB.velocity.z);
			}
			if (playerRB.velocity.x < -maxspeed)
			{
				playerRB.velocity = new Vector3(-maxspeed, 0, playerRB.velocity.z);
			}
		}
		if (!has_gravity) {
			float MoveVert = Input.GetAxisRaw("Vertical");
			if (MoveVert == 0) {
				playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, 0);
			} else {
				Vector3 movementy = new Vector3(0, 0, MoveVert * movespeed);
				movementy = movementy * Time.deltaTime;

				playerRB.AddForce(movementy);
				if (playerRB.velocity.z > maxspeed)
				{
					playerRB.velocity = new Vector3(playerRB.velocity.x, 0, maxspeed);
				}
				if (playerRB.velocity.z < -maxspeed)
				{
					playerRB.velocity = new Vector3(playerRB.velocity.x, 0, -maxspeed);
				}
			}	
		}
	}

	#region GravityFunctions
    public void change_gravity(bool gravity) {
        has_gravity = gravity;
    }
    #endregion

	#region ExitFunction
	public void OnTriggerEnter(Collider other) {
		if (other == exit) {
			exited = true;
			Debug.Log("Exited");
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other == exit) {
			exited = false;
			Debug.Log("No Longer Exited");
		}
	}

	public bool is_exit() {
		return exited;
	}

	#endregion

}
