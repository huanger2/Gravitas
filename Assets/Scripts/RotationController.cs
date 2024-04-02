using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public GameObject player;
    public Vector3 state;
    public int is_up;
    public int is_top;

    public float rotation;

    public float x_value;
    private void Update() {
    }
    public void Rotate_Gravity(float degree) {
        x_value = x_value + degree;
        rotation -= degree;
        transform.eulerAngles = new Vector3(x_value, -90, 90);
    }

    public void Update_Rotation(float degree) {
        rotation += degree;
    }

    public void Rotate_Top(int up) {
        is_up = up;
        is_top = 1;
        state = new Vector3(x_value, -90.0f, 90.0f);
        Vector3 flat = new Vector3(360.0f, 0.0f,0.0f);
        transform.eulerAngles = flat;
        player.GetComponent<PlayerController>().change_gravity(false);
    }

    public void Rotate_Bottom(int up) {
        is_up = up;
        is_top = -1;
        state = new Vector3(x_value, -90.0f, 90.0f);
        Vector3 flat = new Vector3(360.0f,0.0f,0.0f);
        transform.eulerAngles = flat;
        player.GetComponent<PlayerController>().change_gravity(false);
    }

    public void Flat_Direction(int dir) {
        Vector3 flat;
        if (is_top == 1) {
            if (dir == 0) {
                flat = new Vector3(360.0f, 0.0f + rotation, 0.0f);
            } else if (dir == 1) {
                flat = new Vector3(360.0f, 90.0f + rotation, 0.0f);
            } else if (dir == 2) {
                flat = new Vector3(360.0f, 180.0f + rotation, 0.0f);
            } else if (dir == 3) {
                flat = new Vector3(360.0f, 270.0f + rotation, 0.0f);
            } else {
                Debug.Log("Flat error");
                return;
            }
        } else {
            if (is_up == 2 || is_up == 3) {
                if (dir == 0) {
                    flat = new Vector3(360.0f, 0.0f + rotation, 0.0f);
                } else if (dir == 1) {
                    flat = new Vector3(360.0f, 270.0f + rotation, 0.0f);
                } else if (dir == 2) {
                    flat = new Vector3(360.0f, 180.0f + rotation, 0.0f);
                } else if (dir == 3) {
                    flat = new Vector3(360.0f, 90.0f + rotation, 0.0f);
                } else {
                    Debug.Log("Flat error");
                    return;
                }
            } else {
                if (dir == 0) {
                    flat = new Vector3(360.0f, 180.0f + rotation, 0.0f);
                } else if (dir == 1) {
                    flat = new Vector3(360.0f, 90.0f + rotation, 0.0f);
                } else if (dir == 2) {
                    flat = new Vector3(360.0f, 0.0f + rotation, 0.0f);
                } else if (dir == 3) {
                    flat = new Vector3(360.0f, 270.0f + rotation, 0.0f);
                } else {
                    Debug.Log("Flat error");
                    return;
                }
            }
            
        }
        
        transform.eulerAngles = flat;
    }

    public void Rotate_Up(int last) {
        int multiplier = 0;
        if (is_up == 0) {
            if (last == 0) {
                multiplier = 2;
            } else if (last == 1) {
                multiplier = 0;
            } else if (last == 2) {
                multiplier = 1 * is_top;
            } else {
                multiplier = -1 * is_top;
            }
        } else if (is_up == 1) {
            if (last == 0) {
                multiplier = 0;
            } else if (last == 1) {
                multiplier = 2;
            } else if (last == 2) {
                multiplier = -1 * is_top;
            } else {
                multiplier = 1 * is_top;
            }
        } else if (is_up == 2) {
            if (last == 0) {
                multiplier = -1 * is_top;
            } else if (last == 1) {
                multiplier = 1 * is_top;
            } else if (last == 2) {
                multiplier = 2;
            } else {
                multiplier = 0;
            }
        } else if (is_up == 3) {
            if (last == 0) {
                multiplier = 1 * is_top;
            } else if (last == 1) {
                multiplier = -1 * is_top;
            } else if (last == 2) {
                multiplier = 0;
            } else {
                multiplier = 2;
            }
        }


        Vector3 up = new Vector3(state.x + 90.0f * multiplier, -90.0f, 90.0f);
        x_value = up.x;
        transform.eulerAngles = up;
        player.GetComponent<PlayerController>().change_gravity(true);
        

    }
    public void Update_State(float degree) {
        rotation -= degree;
        state = new Vector3(state.x + degree, -90.0f, 90.0f);
    }
}
