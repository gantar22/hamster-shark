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
public class FootStepsSounds : MonoBehaviour
{
    [SerializeField]
    float minDistance = .1f;

    [SerializeField]
    AudioSource audioSource;

    private void Awake()
    {
        StartCoroutine(UpdateRoutine());
    }

    private IEnumerator UpdateRoutine()
    {
        var prevPos = transform.position;
        while(true)
        {
            yield return new WaitForSeconds(.1f);
            if(Vector3.Distance(prevPos,transform.position) < minDistance)
                if(audioSource.isPlaying)
                    audioSource.Stop();
            else 
                if(!audioSource.isPlaying)
                    audioSource.Play();

                    
            prevPos = transform.position;
        }
    }
}
