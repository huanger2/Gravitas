using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    /* 
    _____________________________________________________________________________
    |                                                                           |
    |   Default                                                                 |   
    |   1 is top, 3 is bottom.                                                  |
    |   0 is front POV                                                          |
    |                                                                           |
    |     4                                                                     |
    |   0 1 2 3                                                                 |
    |     5                                                                     |
    |                                                                           |
    |   Rotate Left                                                             |
    |     0               0 -> 5, 4 -> 0, 2 -> 4, 5 -> 2                        |
    |   5 1 4 3                                                                 |
    |     2                                                                     |
    |                                                                           |
    |   Rotate Right                                                            |
    |     2               0 -> 4, 4 -> 2, 2 -> 5, 5 -> 0                        |
    |   4 1 5 3                                                                 |
    |     0                                                                     |
    |                                                                           |
    |   Rotate Up                                                               |
    |     4               0 -> 3, 1 -> 0, 2 -> 1, 3 -> 2                        |
    |   3 0 1 2                                                                 |
    |     5                                                                     |
    |                                                                           |
    |   Rotate Down                                                             |
    |     4               0 -> 1, 1 -> 2, 2 -> 3, 3 -> 0                        |
    |   1 2 3 0                                                                 |
    |     5                                                                     |
    |                                                                           |
    |   Rotate Up Left                                                          |
    |     1               1 -> 5, 4 -> 1, 5 -> 3, 3 -> 4                        |
    |   0 5 2 4                                                                 |
    |     3                                                                     |
    |                                                                           |
    |   Rotate Up Right                                                         |
    |     3               1 -> 4, 4 -> 3, 5 -> 1, 3 -> 5                        |
    |   0 4 2 5                                                                 |
    |     1                                                                     |
    |                                                                           |
    _____________________________________________________________________________
    */

    #region Face Objects
    public GameObject player_0;
    public GameObject player_1;
    public GameObject player_2;
    public GameObject player_3;
    public GameObject player_4;
    public GameObject player_5;

    private GameObject[] player_array;
    #endregion

    #region Rotation Variables
    private bool is_rotating;
    public float rotate_speed;

    public Camera cam;
    #endregion


   #region Unity Functions
    private void Awake()
    {
        player_array = new GameObject[6];
        player_array[0] = player_0;
        player_array[1] = player_1;
        player_array[2] = player_2;
        player_array[3] = player_3;
        player_array[4] = player_4;
        player_array[5] = player_5;
        is_rotating = false;
    }

    private void Update() {
        if (Input.GetKeyDown("e")) {
            Get_Closest();
        }
        if (is_rotating){
            return;
        }
        Rotate();
    }
    #endregion

    #region Rotation Functions
    private void Rotate() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        if(Input.GetKeyDown("t")){
            //Debug.Log("Rotate Up");
            player_array[0] = player_array[3];
            player_array[2] = player_array[1];
            player_array[1] = temp;
            player_array[3] = temp1;
            StartCoroutine(RotateHorizontal(Vector3.right, 90, rotate_speed));
            Rotate_Up();
        } else if(Input.GetKeyDown("g")){
            //Debug.Log("Rotate Down");
            player_array[0] = player_array[1];
            player_array[2] = player_array[3];
            player_array[3] = temp;
            player_array[1] = temp1;
            StartCoroutine(RotateHorizontal(Vector3.right, -90, rotate_speed));
            Rotate_Down();
        } else if(Input.GetKeyDown("f")){
            //Debug.Log("Rotate Left");
            player_array[0] = player_array[5];
            player_array[2] = player_array[4];
            player_array[4] = temp;
            player_array[5] = temp1;
            if (player_array[1] != null) {
                player_array[1].GetComponent<RotationController>().Update_State(-90.0f);
                //player_array[1].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
            }
            if (player_array[3] != null) {
                player_array[3].GetComponent<RotationController>().Update_State(90.0f);
            }
            StartCoroutine(RotateHorizontal(Vector3.up, 90, rotate_speed));
        } else if(Input.GetKeyDown("h")){
            //Debug.Log("Rotate Right");
            player_array[0] = player_array[4];
            player_array[2] = player_array[5];
            player_array[4] = temp1;
            player_array[5] = temp;
            if (player_array[1] != null) {
                player_array[1].GetComponent<RotationController>().Update_State(90.0f);
            }
            if (player_array[3] != null) {
                player_array[3].GetComponent<RotationController>().Update_State(-90.0f);
            }
            StartCoroutine(RotateHorizontal(Vector3.up, -90, rotate_speed));
        } else if(Input.GetKeyDown("[")){
            //Debug.Log("Rotate Up Left");
            temp = player_array[1];
            temp1 = player_array[3];
            player_array[1] = player_array[5];
            player_array[3] = player_array[4];
            player_array[4] = temp;
            player_array[5] = temp1;
            StartCoroutine(RotateHorizontal(new Vector3(0,0,1), 90, rotate_speed));
            Rotate_Up_Left();


        } else if(Input.GetKeyDown("]")){
            //Debug.Log("Rotate Up Right");
            temp = player_array[1];
            temp1 = player_array[3];
            player_array[1] = player_array[4];
            player_array[3] = player_array[5];
            player_array[4] = temp1;
            player_array[5] = temp;
            StartCoroutine(RotateHorizontal(new Vector3(0,0,1), -90, rotate_speed));
            Rotate_Up_Right();

            
        }
    }

    private void Rotate_Up() {
        if(player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Rotate_Up(0);
        } 
        if(player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Rotate_Flat(0);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Up(0);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Flat(0);
        } 
        if(player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Rotate_Gravity(90.0f);
        } 
        if(player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
        } 
    }


    private void Rotate_Down() {
        if(player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Rotate_Up(1);
        } 
        if(player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Rotate_Flat(1);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Up(1);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Flat(1);
        } 
        if(player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
        } 
        if(player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Rotate_Gravity(90.0f);
        } 
    }

    private void Rotate_Up_Left() {
        if(player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Rotate_Gravity(90.0f);
        } 
        if(player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Rotate_Flat(2);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Flat(2);
        } 
        if(player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Rotate_Up(2);
        } 
        if(player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Rotate_Up(2);
        } 
    }

    private void Rotate_Up_Right() {
        if(player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
        } 
        if(player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Rotate_Flat(3);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Gravity(90.0f);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Flat(3);
        } 
        if(player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Rotate_Up(3);
        } 
        if(player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Rotate_Up(3);
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

    #region Camera Functions
    private void Get_Closest() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3 cam_location = cam.transform.position;
        // for(int i = 0; i<4; i ++) {
        //     Debug.Log(vertices[i]);
        // }
        SortedList<double, Vector3> distanceMap = new SortedList<double, Vector3>();
        foreach (Vector3 point in vertices) {
            double distance = Euclidean_Dist(point, cam_location);
            distanceMap[distance] = point;
        }

        List<Vector3> nearestPoints = new List<Vector3>();
        for (int i = 0; i < 4; i++) {
            nearestPoints.Add(distanceMap.Values[i]);
            // Debug.Log(distanceMap.Values[i]);
        }
        


    }

    private double Euclidean_Dist(Vector3 a, Vector3 b) {
        return  Math.Sqrt((Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - a.y, 2) + Math.Pow(a.z - b.z, 2)));
    }
    #endregion




    #region UI Commands
    public void Rup() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        //Debug.Log("Rotate Up");
        player_array[0] = player_array[3];
        player_array[2] = player_array[1];
        player_array[1] = temp;
        player_array[3] = temp1;
        StartCoroutine(RotateHorizontal(Vector3.right, 90, rotate_speed));
        Rotate_Up();
    }
    public void Rdown() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        //Debug.Log("Rotate Down");
        player_array[0] = player_array[1];
        player_array[2] = player_array[3];
        player_array[3] = temp;
        player_array[1] = temp1;
        StartCoroutine(RotateHorizontal(Vector3.right, -90, rotate_speed));
        Rotate_Down();
    }
    public void Rleft() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        //Debug.Log("Rotate Left");
        player_array[0] = player_array[5];
        player_array[2] = player_array[4];
        player_array[4] = temp;
        player_array[5] = temp1;
        if (player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Update_State(90.0f);
        }
        if (player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Update_State(90.0f);
        }
        StartCoroutine(RotateHorizontal(Vector3.up, 90, rotate_speed));
    }
    public void Rright() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        //Debug.Log("Rotate Right");
        player_array[0] = player_array[4];
        player_array[2] = player_array[5];
        player_array[4] = temp1;
        player_array[5] = temp;
        if (player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Update_State(-90.0f);
        }
        if (player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Update_State(-90.0f);
        }
        StartCoroutine(RotateHorizontal(Vector3.up, -90, rotate_speed));
    }
    #endregion
}
