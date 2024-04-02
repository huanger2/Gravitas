using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public int num_players;
    public GameObject[] players;
    public bool all_exit;

    void Awake () {
        all_exit = false;
    }

    public void Update() {
        if (check_exit()) {
            Debug.Log("All players exited");
            all_exit = true;
        }
    }

    private bool check_exit() {
        for (int i=0; i < num_players; i++) {
            if (players[i] != null && players[i].GetComponent<PlayerController>().is_exit() == false) {
                return false;
            }
        }
        return true;
    }
}
