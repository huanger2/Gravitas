using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    #region  Private Variables
    // Speed at which the enemy moves
    [SerializeField]
    private float speed;
    [SerializeField]
    // Local positions that the enemy will move between within the parent's coordinate space
    private Vector3[] localPositions;
    // Index to keep track of the current target position
    private int index;
    // Direction of movement through the localPositions array (1 for forward, -1 for backward)
    private int direction = 1;
    #endregion

    private void Update()
    {
        #region Movement Function
        // Check if there are at least two points to move between
        if (localPositions.Length > 1)
        {
            // Get the current target local position
            Vector3 targetLocalPosition = localPositions[index];

            // Convert the local position to a world position for movement calculations
            Vector3 targetWorldPosition = transform.parent.TransformPoint(targetLocalPosition);

            // Move the enemy towards the target world position
            transform.position = Vector3.MoveTowards(transform.position, targetWorldPosition, Time.deltaTime * speed);

            // Check if the enemy is close enough to the target position to consider it reached
            if (Vector3.Distance(transform.position, targetWorldPosition) < 0.01f)
            {
                // Check if we've reached the end or start of the localPositions array
                if ((index == localPositions.Length - 1 && direction == 1) || (index == 0 && direction == -1))
                {
                    // Reverse the direction of movement through the array
                    direction *= -1;
                }
                // Move to the next position in the array based on the direction of movement
                index += direction;
            }
        }
        #endregion
    }
}

