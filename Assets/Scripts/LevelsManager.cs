using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelsManager : MonoBehaviour
{
    #region Initialization
    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Button Methods
    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(int level) {
        SceneManager.LoadScene("Level" + level);

    }
    #endregion
}
