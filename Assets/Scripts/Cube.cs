using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    /* 
    _____________________________________________________________________________
    |                                                                           |
    |   Default                                                                 |   
    |   2 is top, 4 is bottom.                                                  |
    |   1 is front POV                                                          |
    |                                                                           |
    |     5                                                                     |
    |   1 2 3 4                                                                 |
    |     6                                                                     |
    |                                                                           |
    |   Rotate Left                                                             |
    |     1               1 -> 6, 5 -> 1, 3 -> 5, 6 -> 3                        |
    |   6 2 5 4                                                                 |
    |     3                                                                     |
    |                                                                           |
    |   Rotate Right                                                            |
    |     3               1 -> 5, 5 -> 3, 3 -> 6, 6 -> 1                        |
    |   5 2 6 4                                                                 |
    |     1                                                                     |
    |                                                                           |
    |   Rotate Up                                                               |
    |     5               1 -> 4, 2 -> 1, 3 -> 2, 4 -> 3                        |
    |   4 1 2 3                                                                 |
    |     6                                                                     |
    |                                                                           |
    |   Rotate Down                                                             |
    |     5               1 -> 2, 2 -> 3, 3 -> 4, 4 -> 1                        |
    |   2 3 4 1                                                                 |
    |     6                                                                     |
    |                                                                           |
    _____________________________________________________________________________
    */

    #region Face Objects
    public GameObject face1;
    public GameObject face2;
    public GameObject face3;
    public GameObject face4;
    public GameObject face5;
    public GameObject face6;

    #endregion

    #region Rotation Variables
    private bool is_rotating;
    public float rotate_speed;
    #endregion


   #region Unity Functions

    private void Awake()
    {
        is_rotating = false;
    }

    private void Update() {
        if (is_rotating){
            return;
        }
        Rotate();
    }

    private void Rotate() {
        if(Input.GetKeyDown("t")){
            Debug.Log("Rotate Up");
            StartCoroutine(RotateHorizontal(Vector3.right, 90, rotate_speed));
        } else if(Input.GetKeyDown("g")){
            Debug.Log("Rotate Down");
            StartCoroutine(RotateHorizontal(Vector3.right, -90, rotate_speed));
        } else if(Input.GetKeyDown("f")){
            Debug.Log("Rotate Left");
            StartCoroutine(RotateHorizontal(Vector3.up, 90, rotate_speed));
        } else if(Input.GetKeyDown("h")){
            Debug.Log("Rotate Right");
            StartCoroutine(RotateHorizontal(Vector3.up, -90, rotate_speed));
        } 
    }

    IEnumerator RotateHorizontal(Vector3 axis, float angle, float inTime)
	{	
        is_rotating = true;
        float currentAngle = 0;
        int sign = (int) Mathf.Sign(angle);

        while (true)
        {
            float timestep = inTime * Time.deltaTime;
            currentAngle += timestep;
            transform.RotateAround(transform.position, axis, timestep * sign);
            if (currentAngle >= 90) break;
            yield return null;
        }

        var vec = transform.eulerAngles;
        vec.x = Mathf.Round(vec.x / 90) * 90;
        vec.y = Mathf.Round(vec.y / 90) * 90;
        vec.z = Mathf.Round(vec.z / 90) * 90;
        transform.eulerAngles = vec;        
        is_rotating = false;
	}


    #endregion


    #region Rotation Functions





    #endregion
}
