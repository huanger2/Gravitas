using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public GameObject player;
    public Vector3 state;
    public int is_up;

    public float x_value;
    private void Update() {
        if(Input.GetKeyDown("[")){
            Rotate_Gravity(90.0f);
        } else if(Input.GetKeyDown("]")){
            Rotate_Gravity(-90.0f);
        }
    }
    public void Rotate_Gravity(float degree) {
        x_value = x_value + degree;
        transform.eulerAngles = new Vector3(x_value, -90, 90);
    }

    public void Rotate_Flat(int up) {
        is_up = up;
        state = new Vector3(x_value, -90.0f, 90.0f);
        Vector3 flat = new Vector3(360.0f,0.0f,0.0f);
        transform.eulerAngles = flat;
        player.GetComponent<PlayerController>().change_gravity(false);
    }

    public void Rotate_Up(int last) {
        int multiplier = 0;
        if (is_up == last) {
            multiplier = 1;
        }
        Vector3 up = new Vector3(state.x + 180.0f * multiplier, -90.0f, 90.0f);
        x_value = up.x;
        transform.eulerAngles = up;
        player.GetComponent<PlayerController>().change_gravity(true);
        

    }

    public void Rotate_Down(int last) {
        int multiplier = 0;
        if (is_up == last) {
            multiplier = 1;
        }
        Vector3 up = new Vector3(state.x + 180.0f * multiplier, -90.0f, 90.0f);
        x_value = up.x;
        transform.eulerAngles = up;
        player.GetComponent<PlayerController>().change_gravity(true);

    }

    public void Update_State(float degree) {
        state = new Vector3(state.x + degree, -90.0f, 90.0f);
    }

}
