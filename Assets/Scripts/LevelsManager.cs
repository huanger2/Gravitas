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
    public void Level5() {
        SceneManager.LoadScene("Level5");
    }
    public void Level6() {
        SceneManager.LoadScene("Level6");
    }
    public void Level7() {
        SceneManager.LoadScene("Level7");
    }
    public void Level8() {
        SceneManager.LoadScene("Level8");
    }
    #endregion
}
