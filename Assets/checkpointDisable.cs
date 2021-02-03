using System.Collections;
using System;
using UnityEngine;
/*
 * Author: cwilliams@filamentgames.com
 *
 * Purpose:
 * 
 *
 */
public class checkpointDisable : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            
        }
    }
}
