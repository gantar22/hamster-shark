using System.Collections;
using System;
using UnityEngine;

/*
 * Author: nathancarterwilliams@gmail.com
 *
 * Purpose:
 * 
 *
 */
namespace Player
{
    public class Echolocation : MonoBehaviour
    {


        private void Awake()
        {
            StartCoroutine(UpdateRoutine());
        }

        private IEnumerator UpdateRoutine()
        {
            while(true)
            {
                yield return null;
                if(Input.GetKey(KeyCode.Mouse1))
                {
                    Echo();
                }
            }
        }

        public void Echo()
        {
            if(Physics.Raycast(transform.position,transform.forward,10,255,QueryTriggerInteraction.Ignore))
            {

            }
        }
    }
}