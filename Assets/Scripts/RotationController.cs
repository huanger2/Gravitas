using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private Vector3 state;
    private int is_up;
    private void Update() {
        if(Input.GetKeyDown("[")){
            Rotate_Gravity(90.0f);
        } else if(Input.GetKeyDown("]")){
            Rotate_Gravity(-90.0f);
        }
    }
    public void Rotate_Gravity(float degree) {
        transform.Rotate(0.0f, degree, 0.0f);
        Debug.Log("New angle " + transform.eulerAngles.y);
    }

    public void Rotate_Flat(int up) {
        is_up = up;
        state = transform.eulerAngles;
        Vector3 flat = new Vector3(360.0f,0.0f,0.0f);
        transform.eulerAngles = flat; 
    }

    public void Rotate_Up(int last) {
        int multiplier = 0;
        if (is_up == last) {
            multiplier = 1;
        }
        Vector3 up = new Vector3(state.x + 180 * multiplier, state.y, state.z);
        transform.eulerAngles = up; 
    }

    public void Rotate_Down(int last) {
        int multiplier = 0;
        if (is_up == last) {
            multiplier = 1;
        }
        Vector3 up = new Vector3(state.x + 180 * multiplier, state.y, state.z);
        transform.eulerAngles = up; 
    }

}
