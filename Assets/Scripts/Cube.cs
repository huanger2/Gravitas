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
        if (player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Update_Rotation(180.0f);
        }
        if (player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Update_Rotation(90.0f);
        }
        if (player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Update_Rotation(-90.0f);
        }
        is_rotating = false;
    }

    private void Update() {
        if (is_rotating){
            return;
        }
        Rotate();
        if (player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Flat_Direction(Camera_dir());
        }
        if (player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Flat_Direction(Camera_dir());
        }
        Vector3 cam_up = cam.transform.up;
        if (cam_up.y > 0) {
            if (player_array[0] != null) {
                player_array[0].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = false;
            }
            if (player_array[2] != null) {
                player_array[2].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = false;
            }
            if (player_array[4] != null) {
                player_array[4].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = false;
            }
            if (player_array[5] != null) {
                player_array[5].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = false;
            }
        } else {
            if (player_array[0] != null) {
                player_array[0].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = true;
            }
            if (player_array[2] != null) {
                player_array[2].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = true;
            }
            if (player_array[4] != null) {
                player_array[4].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = true;
            }
            if (player_array[5] != null) {
                player_array[5].GetComponent<RotationController>().player.GetComponent<PlayerController>().reverse = true;
            }
        }
    }
    #endregion

    #region Rotation Functions
    private void Rotate() {
        if(Input.GetKeyDown("t")){
            R_UP_DIR();
        } else if(Input.GetKeyDown("g")){
            R_DOWN_DIR();
        } else if(Input.GetKeyDown("f")){
            R_LEFT_DIR();
        } else if(Input.GetKeyDown("h")){
            R_RIGHT_DIR();
        }
    }

    private void R_UP_DIR() {
        int closest = Get_Closest();
        if (closest == 0) {
            R_UP();
        } else if (closest == 4) {
            R_UPR();
        } else if (closest == 2) {
            R_DOWN();
        } else if (closest == 5) {
            R_UPL();
        } else if (closest == 1) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UP();
            } else if (dir == 2) {
                R_DOWN();
            } else if (dir == 1) {
                R_UPL();
            } else if (dir == 3) {
                R_UPR();
            }
        } else if (closest == 3) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_DOWN();
            } else if (dir == 2) {
                R_UP();
            } else if (dir == 1) {
                R_UPR();
            } else if (dir == 3) {
                R_UPL();
            }
        }
    }

    private void R_DOWN_DIR() {
        int closest = Get_Closest();
        if (closest == 0) {
            R_DOWN();
        } else if (closest == 4) {
            R_UPL();
        } else if (closest == 2) {
            R_UP();
        } else if (closest == 5) {
            R_UPR();
        } else if (closest == 1) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_DOWN();
            } else if (dir == 2) {
                R_UP();
            } else if (dir == 1) {
                R_UPR();
            } else if (dir == 3) {
                R_UPL();
            }
        } else if (closest == 3) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UP();
            } else if (dir == 2) {
                R_DOWN();
            } else if (dir == 1) {
                R_UPL();
            } else if (dir == 3) {
                R_UPR();
            }
        }
    }

    private void R_LEFT_DIR() {
        int closest = Get_Closest();
        if (closest == 1) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UPL();
            } else if (dir == 2) {
                R_UPR();
            } else if (dir == 1) {
                R_DOWN();
            } else if (dir == 3) {
                R_UP();
            }
        } else if (closest == 3) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UPL();
            } else if (dir == 2) {
                R_UPR();
            } else if (dir == 1) {
                R_DOWN();
            } else if (dir == 3) {
                R_UP();
            }
        } else {
            Vector3 cam_up = cam.transform.up;
            if (cam_up.y > 0) {
                R_LEFT();
            } else {
                R_RIGHT();
            }
        }
    }

    private void R_RIGHT_DIR() {
        int closest = Get_Closest();
        if (closest == 1) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UPR();
            } else if (dir == 2) {
                R_UPL();
            } else if (dir == 1) {
                R_UP();
            } else if (dir == 3) {
                R_DOWN();
            }
        } else if (closest == 3) {
            int dir = Camera_dir();
            if (dir == 0) {
                R_UPR();
            } else if (dir == 2) {
                R_UPL();
            } else if (dir == 1) {
                R_UP();
            } else if (dir == 3) {
                R_DOWN();
            }
        } else {
            Vector3 cam_up = cam.transform.up;
            if (cam_up.y > 0) {
                R_RIGHT();
            } else {
                R_LEFT();
            }
        }
    }


    private void R_LEFT() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        player_array[0] = player_array[5];
        player_array[2] = player_array[4];
        player_array[4] = temp;
        player_array[5] = temp1;
        if (player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Update_Rotation(90.0f);
        }
        if (player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Update_Rotation(90.0f);
        }
        if (player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Update_Rotation(90.0f);
        }
        if (player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Update_Rotation(90.0f);
        }

        if (player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Update_State(-90.0f);
        }
        if (player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Update_State(90.0f);
        }
        StartCoroutine(RotateHorizontal(Vector3.up, 90, rotate_speed));
    }

    private void R_RIGHT() {
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        player_array[0] = player_array[4];
        player_array[2] = player_array[5];
        player_array[4] = temp1;
        player_array[5] = temp;
        if (player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Update_Rotation(-90.0f);
        }
        if (player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Update_Rotation(-90.0f);
        }
        if (player_array[4] != null) {
            player_array[4].GetComponent<RotationController>().Update_Rotation(-90.0f);
        }
        if (player_array[5] != null) {
            player_array[5].GetComponent<RotationController>().Update_Rotation(-90.0f);
        }

        if (player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Update_State(90.0f);
        }
        if (player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Update_State(-90.0f);
        }
        StartCoroutine(RotateHorizontal(Vector3.up, -90, rotate_speed));
    }


    private void R_UP() {
        Debug.Log("R_UP");
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        player_array[0] = player_array[3];
        player_array[2] = player_array[1];
        player_array[1] = temp;
        player_array[3] = temp1;
        StartCoroutine(RotateHorizontal(Vector3.right, 90, rotate_speed));
        Rotate_Up();
    }

    private void R_DOWN() {
        Debug.Log("R_DOWN");
        GameObject temp = player_array[0];
        GameObject temp1 = player_array[2];
        player_array[0] = player_array[1];
        player_array[2] = player_array[3];
        player_array[3] = temp;
        player_array[1] = temp1;
        StartCoroutine(RotateHorizontal(Vector3.right, -90, rotate_speed));
        Rotate_Down();
    }

    private void R_UPL() {
        Debug.Log("R_UPL");
        GameObject temp = player_array[1];
        GameObject temp1 = player_array[3];
        player_array[1] = player_array[5];
        player_array[3] = player_array[4];
        player_array[4] = temp;
        player_array[5] = temp1;
        StartCoroutine(RotateHorizontal(new Vector3(0,0,1), 90, rotate_speed));
        Rotate_Up_Left();
    }

    private void R_UPR() {
        Debug.Log("R_UPR");
        GameObject temp = player_array[1];
        GameObject temp1 = player_array[3];
        player_array[1] = player_array[4];
        player_array[3] = player_array[5];
        player_array[4] = temp1;
        player_array[5] = temp;
        StartCoroutine(RotateHorizontal(new Vector3(0,0,1), -90, rotate_speed));
        Rotate_Up_Right();
    }


    private void Rotate_Up() {
        if(player_array[0] != null) {
            player_array[0].GetComponent<RotationController>().Rotate_Up(0);
        } 
        if(player_array[1] != null) {
            player_array[1].GetComponent<RotationController>().Rotate_Top(0);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Up(0);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Bottom(0);
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
            player_array[1].GetComponent<RotationController>().Rotate_Top(1);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Up(1);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Bottom(1);
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
            player_array[1].GetComponent<RotationController>().Rotate_Top(2);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Gravity(-90.0f);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Bottom(2);
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
            player_array[1].GetComponent<RotationController>().Rotate_Top(3);
        } 
        if(player_array[2] != null) {
            player_array[2].GetComponent<RotationController>().Rotate_Gravity(90.0f);
        } 
        if(player_array[3] != null) {
            player_array[3].GetComponent<RotationController>().Rotate_Bottom(3);
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
    private int Get_Closest() {
        Vector3 cam_up = cam.transform.up;
        Vector3 cam_forward = cam.transform.forward;
        if(Math.Abs(cam_forward.y) <= 0.5f) {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            Vector3 cam_location = cam.transform.position;
            SortedList<double, Vector3> distanceMap = new SortedList<double, Vector3>();
            foreach (Vector3 point in vertices) {
                double distance = Euclidean_Dist(point, cam_location);
                distanceMap[distance] = point;
            }

            List<Vector3> nearestPoints = new List<Vector3>();
            for (int i = 0; i < 2; i++) {
                nearestPoints.Add(distanceMap.Values[i]);
                //Debug.Log(distanceMap.Values[i]);
            }
            Vector3 point1 = new Vector3(-0.5f, -0.5f, -0.5f);
            Vector3 point2 = new Vector3(0.5f, 0.5f, -0.5f);
            Vector3 point3 = new Vector3(0.5f, -0.5f, 0.5f);
            Vector3 point4 = new Vector3(-0.5f, 0.5f, 0.5f);
            if (nearestPoints.Contains(point1) && nearestPoints.Contains(point4)) {
                //Debug.Log("4");
                return 4;
            } else if (nearestPoints.Contains(point1) && nearestPoints.Contains(point2)) {
                //Debug.Log("0");
                return 0;
            } else if (nearestPoints.Contains(point2) && nearestPoints.Contains(point3)) {
                //Debug.Log("5");
                return 5;
            } else if (nearestPoints.Contains(point3) && nearestPoints.Contains(point4)) {
                // Debug.Log("2");
                return 2;
            }
            return 100; 
        } else {
            //Debug.Log(cam_up +", " + cam_forward);
            if (cam_forward.y > 0) {
                return 3;
            } else {
                return 1;
            }
            
        }
    }

    private double Euclidean_Dist(Vector3 a, Vector3 b) {
        return  Math.Sqrt((Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - a.y, 2) + Math.Pow(a.z - b.z, 2)));
    }

    private int Camera_dir() {
        Vector3 cam_up = cam.transform.up;
        Vector3 cam_forward = cam.transform.forward;
        //Debug.Log(cam_up +", " + cam_forward);
        if(Math.Abs(cam_forward.y) <= 0.5f) {
            if (Math.Abs(cam_forward.x) <= Math.Abs(cam_forward.z)) {
                if (cam_forward.z > 0) {
                    return 0;
                } else {
                    return 2;
                }
            } else {
                if (cam_forward.x < 0) {
                    return 1;
                } else {
                    return 3;
                }

            }
        } else {
            if (Math.Abs(cam_up.x) <= Math.Abs(cam_up.z)) {
                if (cam_up.z > 0) {
                    return 0;
                } else {
                    return 2;
                }
            } else {
                if (cam_up.x < 0) {
                    return 1;
                } else {
                    return 3;
                }

            }
        }
    }
    #endregion


    #region UI Commands
    public void Rup() {
        if (is_rotating){
            return;
        }
        R_UP_DIR();
    }
    public void Rdown() {
        if (is_rotating){
            return;
        }
        R_DOWN_DIR();
    }
    public void Rleft() {
        if (is_rotating){
            return;
        }
        R_LEFT_DIR();
    }
    public void Rright() {
        if (is_rotating){
            return;
        }
        R_RIGHT_DIR();  
    }
    #endregion
}
