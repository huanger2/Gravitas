using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Initialization
    private void Awake() {
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Button Methods
    public void Levels() {
        SceneManager.LoadScene("Levels");
    }

    public void Tutorial() {
        SceneManager.LoadScene("Level0");
    }

    public void Quit() {
        Application.Quit();
    }
    #endregion
}
