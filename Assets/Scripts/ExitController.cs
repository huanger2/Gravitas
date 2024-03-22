using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    public int num_players;
    public GameObject[] players;

    void Awake () {
    }

    public void Update() {
        if (check_exit()) {
            Debug.Log("All players exited");
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
