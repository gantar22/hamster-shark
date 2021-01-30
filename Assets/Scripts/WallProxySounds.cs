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
public class WallProxySounds : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void Awake()
    {
        StartCoroutine(UpdateRoutine());
    }

    IEnumerator UpdateRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(.1f);
            
        }
    }
}