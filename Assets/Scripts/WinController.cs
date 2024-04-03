using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinController : MonoBehaviour
{
    public GameObject exitcontroller;
    public GameObject pauseMenuUI;

    public int level;
    private void Awake() {
        pauseMenuUI.SetActive(false);
    }

    private void Update() {
        if (exitcontroller.GetComponent<ExitController>().all_exit) {
            Win();
        }
    }

    public void Win() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit() {
        SceneManager.LoadScene("Levels");
    }

    public void Restart() {
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
