using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float movespeed;
	public float maxspeed;
	public bool has_gravity;
	public bool reverse;
	public bool on_bottom;

	private Vector3 start_loc;


	public GameObject cube;

	#region Exit variables
	public bool exited = false;

	public CapsuleCollider exit;

	#endregion

	Rigidbody playerRB;


	void Awake()
	{
		start_loc = new Vector3(gameObject.transform.localPosition.x, 0.3f, gameObject.transform.localPosition.y);
		playerRB = gameObject.GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Mathf.Abs(gameObject.transform.localPosition.x) > 6 || Mathf.Abs(gameObject.transform.localPosition.y) > 6) {
			gameObject.transform.position = start_loc;

		}
		//Movement
		if (cube.GetComponent<Cube>().is_rotating) {
			playerRB.velocity = Vector3.zero;
			return;
		}

		float MoveHor = Input.GetAxisRaw("Horizontal");
		if (MoveHor == 0) {
			playerRB.velocity = new Vector3(0,playerRB.velocity.y, playerRB.velocity.z);
		} else {
			if (!reverse || !has_gravity) {
				if (on_bottom && cube.GetComponent<Cube>().Get_Closest() != 3) {
					Vector3 movement = new Vector3(-1 * MoveHor * movespeed, 0, 0);
					movement = movement * Time.deltaTime;
					playerRB.AddForce(movement);
					if (playerRB.velocity.x > maxspeed) {
						playerRB.velocity = new Vector3(maxspeed, 0, playerRB.velocity.z);
					} else if (playerRB.velocity.x < -maxspeed) {
						playerRB.velocity = new Vector3(-maxspeed, 0, playerRB.velocity.z);
					}
				} else {
					Vector3 movement = new Vector3(MoveHor * movespeed, 0, 0);
					movement = movement * Time.deltaTime;

					playerRB.AddForce(movement);
					if (playerRB.velocity.x > maxspeed) {
						playerRB.velocity = new Vector3(maxspeed, 0, playerRB.velocity.z);
					} else if (playerRB.velocity.x < -maxspeed) {
						playerRB.velocity = new Vector3(-maxspeed, 0, playerRB.velocity.z);
					}
				}
			} else {
				Vector3 movement = new Vector3(-1 * MoveHor * movespeed, 0, 0);
				movement = movement * Time.deltaTime;
				playerRB.AddForce(movement);
				if (playerRB.velocity.x > maxspeed) {
					playerRB.velocity = new Vector3(maxspeed, 0, playerRB.velocity.z);
				} else if (playerRB.velocity.x < -maxspeed) {
					playerRB.velocity = new Vector3(-maxspeed, 0, playerRB.velocity.z);
				}
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
