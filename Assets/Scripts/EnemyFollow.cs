using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyFollow : MonoBehaviour
{
    #region Private Variables
    [SerializeField]
    private int speed;
    [SerializeField]
    private GameObject player;
    #endregion
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
