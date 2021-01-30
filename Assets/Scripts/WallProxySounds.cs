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
    [SerializeField]
    BoxCollider collider;
    [SerializeField]
    AudioSource audio;

    private void Awake()
    {
        StartCoroutine(UpdateRoutine());
    }

    IEnumerator UpdateRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(.1f);
            audio.transform.position = collider.ClosestPoint(player.transform.position);
        }
    }
}