using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

/*
 * Author: cwilliams@filamentgames.com
 *
 * Purpose:
 * 
 *
 */

public class OnPlayerEnter : MonoBehaviour
{
    [SerializeField]
    UnityEvent onPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            onPlayerEnter.Invoke();
        }
    }
}