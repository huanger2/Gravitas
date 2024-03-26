using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    public float ZoomChange;
    public float SmoothChange;
    public float Minsize, Maxsize;

    private Camera cam;
    public void Start() {
        cam = GetComponent<Camera>();
    }

    private void Update() {
        if (Input.mouseScrollDelta.y > 0) {
            cam.fieldOfView--;
            //Debug.Log("zoom in");
        }

        if (Input.mouseScrollDelta.y < 0) {
            cam.fieldOfView++;
            //Debug.Log("zoom out");
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, Minsize, Maxsize);
    }
}
