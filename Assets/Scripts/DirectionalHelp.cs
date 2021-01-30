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
public class DirectionalHelp : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip[] keepGoing;

    [SerializeField]
    AudioClip[] turnAround;

    [SerializeField]
    AudioClip[] turnRight;

    [SerializeField]
    AudioClip[] turnLeft;

    [SerializeField]
    AudioClip[] overHere;

    void Awake()
    {
        StartCoroutine(UpdateRoutine());
    }

    IEnumerator UpdateRoutine()
    {
        while(true)
        {
            yield return null;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                var angle = Vector3.Angle(player.transform.forward,DirectionalZone.IntendedDirection);
                print($"player {player.transform.forward}, intended {DirectionalZone.IntendedDirection}, angle {angle}");

                if( angle < 45)
                {
                    var clip = keepGoing[(int)(UnityEngine.Random.value * keepGoing.Length)];
                    source.PlayOneShot(clip);
                }
                else if(angle > 135)
                {
                    var clip = turnAround[(int)(UnityEngine.Random.value * turnAround.Length)];
                    source.PlayOneShot(clip);
                } else 
                {
                    var rightness = Vector3.Angle(-player.transform.right,DirectionalZone.IntendedDirection);
                    var leftness  = Vector3.Angle( player.transform.right,DirectionalZone.IntendedDirection);
                    if(leftness <= rightness)
                    {
                        var clip = turnRight[(int)(UnityEngine.Random.value * turnRight.Length)];
                        source.PlayOneShot(clip);
                    } else 
                    {
                        var clip = turnLeft[(int)(UnityEngine.Random.value * turnLeft.Length)];
                        source.PlayOneShot(clip);
                    }
                }
                yield return new WaitForSeconds(3);
            }
        }
    }
}
