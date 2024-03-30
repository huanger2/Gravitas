using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("MainMenu");

        }
    }
}
