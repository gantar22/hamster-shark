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
 public class PauseHelpVoice : MonoBehaviour
{
    [SerializeField]
    DirectionalHelp help;

    [SerializeField]
    AudioSource triggerSource;

    [SerializeField]
    AudioSource waitSource;


    void Awake()
    {
        if(waitSource.clip != null)
            StartCoroutine(routine());
    }


    IEnumerator routine()
    {
        yield return new WaitUntil(() => triggerSource.isPlaying);
        yield return new WaitUntil(() => !triggerSource.isPlaying);
        help.StopNow();
        help.Paused = true;
        yield return new WaitUntil(() => waitSource.isPlaying);
        yield return new WaitUntil(() => !waitSource.isPlaying);
        help.Paused = false;
    }
}