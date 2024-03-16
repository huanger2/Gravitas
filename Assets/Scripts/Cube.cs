using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    /* 
    _____________________________________________________________________________
    |                                                                           |
    |   Default                                                                 |   
    |   2 is top, 4 is bottom.                                                  |
    |   1 is front POV                                                          |
    |                                                                           |
    |     5                                                                     |
    |   1 2 3 4                                                                 |
    |     6                                                                     |
    |                                                                           |
    |   Rotate Left                                                             |
    |     1               1 -> 6, 5 -> 1, 3 -> 5, 6 -> 3                        |
    |   6 2 5 4                                                                 |
    |     3                                                                     |
    |                                                                           |
    |   Rotate Right                                                            |
    |     3               1 -> 5, 5 -> 3, 3 -> 6, 6 -> 1                        |
    |   5 2 6 4                                                                 |
    |     1                                                                     |
    |                                                                           |
    |   Rotate Up                                                               |
    |     5               1 -> 4, 2 -> 1, 3 -> 2, 4 -> 3                        |
    |   4 1 2 3                                                                 |
    |     6                                                                     |
    |                                                                           |
    |   Rotate Down                                                             |
    |     5               1 -> 2, 2 -> 3, 3 -> 4, 4 -> 1                        |
    |   2 3 4 1                                                                 |
    |     6                                                                     |
    |                                                                           |
    _____________________________________________________________________________
    */

    public gameObject face1;
    public gameObject face2;
    public gameObject face3;
    public gameObject face4;
    public gameObject face5;
    public gameObject face6;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
