using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{

    private void Update() {
        if(Input.GetKeyDown("[")){
            Rotate_Gravity(90.0f);
        } else if(Input.GetKeyDown("]")){
            Rotate_Gravity(-90.0f);
        }
    }
    public void Rotate_Gravity(float degree) {
        transform.Rotate(0.0f, degree, 0.0f);   
    }

    public void Rotate_Flat() {
        Vector3 flat = new Vector3(360.0f,0.0f,0.0f);
        transform.eulerAngles = flat; 
    }

    public void Rotate_Up(float angle) {
        Vector3 up = new Vector3(angle,-90.0f,90.0f);
        transform.eulerAngles = up; 
    }

}
