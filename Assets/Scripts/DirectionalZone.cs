﻿using System.Collections;
using System;
using UnityEngine;

/*
 * Author: cwilliams@filamentgames.com
 *
 * Purpose:
 * 
 *
 */
public class DirectionalZone : MonoBehaviour
{
    public static Vector3 IntendedDirection;

    void OnTriggerEnter(Collider collider)
    {

        if(collider.tag == "Player")
        {
            IntendedDirection = transform.forward;
        }
    }
}
