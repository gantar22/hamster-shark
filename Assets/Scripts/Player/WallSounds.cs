using System.Collections;
using System.Linq;
using UnityEngine;

/*
 * Author: cwilliams@filamentgames.com
 *
 * Purpose:
 * 
 *
 */
namespace Player
{
    public class WallSounds : MonoBehaviour
    {
        private struct Data
        {
            public Vector3 direction;
            public AudioSource source;
        }

        [SerializeField]
        AudioSource audioPrefab;


        public void Activate()
        {
            StartCoroutine(UpdateRoutine());
        }

        private IEnumerator UpdateRoutine()
        {
            var sources = Enumerable.Repeat(0,4).Select(_=>GameObject.Instantiate(audioPrefab)).ToArray();
            var data = new Data []
            {
                new Data {direction = Vector3.left,source  = sources[0]},
                new Data {direction = Vector3.right, source = sources[1]},
                new Data {direction = Vector3.forward, source = sources[2]},
                new Data {direction = Vector3.back, source = sources[3]},
            };


            while(true)
            {
                yield return new WaitForSeconds(.1f);
                var pos = transform.position;
                foreach(var datum in data)
                {
                    if(Physics.Raycast(pos,datum.direction,out var hit,10,255,QueryTriggerInteraction.Ignore))
                    {
                        datum.source.transform.position = hit.point + datum.direction * .2f;
                        datum.source.transform.forward  = hit.normal;

                        if(!datum.source.isPlaying)
                            datum.source.Play();

                    } else 
                    {

                        if(datum.source.isPlaying)
                            datum.source.Stop();

                    }
                }
            }
        }
    }
}