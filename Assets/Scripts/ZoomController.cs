using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public float initial_fov;
    public Vector3 initial_pos;
    public float Minsize, Maxsize;
    public float zoomSpeed;
    private Camera cam;
    public void Start() {
        cam = GetComponent<Camera>();
        cam.transform.position = initial_pos;
        cam.fieldOfView = initial_fov;
    }

    private void Update() {
        if (Input.mouseScrollDelta.y > 0) {
            if (cam.fieldOfView >= Minsize) {
                cam.fieldOfView = cam.fieldOfView - zoomSpeed;
            } 
            
        } else if (Input.mouseScrollDelta.y < 0) {
            if (cam.fieldOfView <= Maxsize) {
                cam.fieldOfView = cam.fieldOfView + zoomSpeed;
            } 
        }

        if (Input.GetMouseButtonDown(1)) {
            cam.fieldOfView = initial_fov;
        }
    }
}
