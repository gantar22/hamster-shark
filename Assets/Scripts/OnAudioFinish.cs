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
public class OnAudioFinish : MonoBehaviour
{
    [SerializeField]
    UnityEvent onFinish;

    [SerializeField]
    AudioSource source;

    private bool hasStarted = false;
    private bool hasFinished = false;

    void Update()
    {
        if(!hasFinished)
        {
            if(!hasStarted && source.isPlaying)
            {
                hasStarted = true;
            }
            if(hasStarted && !source.isPlaying) {
                onFinish.Invoke();
                hasFinished = true;
            }
        }
    }


}