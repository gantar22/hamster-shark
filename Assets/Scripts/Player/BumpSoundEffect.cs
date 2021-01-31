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

    float maxVolume;


    void Awake()
    {
        StartCoroutine(UpdateRoutine());
        maxVolume = sound.volume;
    }

    void OnCollisionEnter(Collision other)
    {
        if(!other.collider.isTrigger)
        {
            if(!sound.isPlaying)
            {
                var dot = Vector3.Dot(other.contacts[0].normal,transform.forward);
                sound.volume = Mathf.Lerp(0,maxVolume,Mathf.Abs(dot));
            }
        }
    }

    IEnumerator UpdateRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            if(Input.GetKey(KeyCode.Mouse0))   
            {        
                if(Physics.Raycast(transform.position,transform.forward,.5f,255,QueryTriggerInteraction.Ignore))
                {
                    sound.Play();
                }
            }             
        }
    }
}