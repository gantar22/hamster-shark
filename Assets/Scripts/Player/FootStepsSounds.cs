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

    private float maxVolume;

    private float targetVolume = 0;

    private void Awake()
    {
        maxVolume = audioSource.volume;
        audioSource.volume = 0;
        StartCoroutine(UpdateRoutine());
        StartCoroutine(SetVolume());
    }

    private IEnumerator UpdateRoutine()
    {
        var prevPos = transform.position;
        while(true)
        {
            yield return new WaitForSeconds(.2f);
            if(Vector3.Distance(prevPos,transform.position) < minDistance)
            {
                targetVolume = 0;
            }
            else 
            {
                targetVolume = maxVolume;
            }
            prevPos = transform.position;
        }
    }

    private IEnumerator SetVolume()
    {
        audioSource.Play();
        while(true)
        {
            yield return null;
            audioSource.volume = Mathf.Lerp(audioSource.volume,targetVolume,Time.deltaTime * 10);
        }
    }
}
