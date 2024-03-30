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
        SceneManager.LoadScene("TutorialScene");
    }

    public void Quit() {
        Application.Quit();
    }
    #endregion
}
