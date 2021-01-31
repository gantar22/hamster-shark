using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Audio;

/*
 * Author: nathancarterwilliams@gmail.com
 *
 * Purpose:
 * 
 *
 */
namespace Player
{
    public class MouseControls : MonoBehaviour
    {
        public enum State {Offline, OnlyMovement, Online }

        [SerializeField]
        float speed = 1;

        [SerializeField]
        AudioMixerGroup mixerGroup;


        public State state = State.Online;

        private void Awake()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            StartCoroutine(UpdateRoutine());
        }

        private IEnumerator UpdateRoutine()
        {
            while(true)
            {
                yield return null;
                if(state == State.Online)
                    transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X"),0);

                if(state == State.Online || state == State.OnlyMovement)
                {
                    if(Input.GetKey(KeyCode.Mouse0))
                    {
                        transform.position += transform.forward * speed * Time.deltaTime;
                    }
                }
            }
        }

        public void Pause(AudioSource audio)
        {
            state = State.Offline;
        }

        private IEnumerator pause(AudioSource audio)
        {
            yield return new WaitUntil(() => !audio.isPlaying);
            state = State.Online;
        }

        public void TeleportTo(Transform dest)
        {
            transform.position = dest.position;
            transform.forward = dest.forward;
        }

    }
}