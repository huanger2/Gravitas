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

    public void Level1() {
        SceneManager.LoadScene("Level1");
    }

    public void Level2() {
        SceneManager.LoadScene("Level2");
    }

    public void Level3() {
        SceneManager.LoadScene("Level3");
    }
    
    public void Level4() {
        SceneManager.LoadScene("Level4");
    }
    #endregion
}
