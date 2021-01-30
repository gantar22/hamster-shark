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
public class BumpSoundEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource sound;

    void OnCollisionEnter(Collision other)
    {
        if(!other.collider.isTrigger)
        {
            if(!sound.isPlaying)
                sound.Play();
        }
    }
}