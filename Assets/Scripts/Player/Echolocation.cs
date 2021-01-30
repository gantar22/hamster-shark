using System.Collections;
using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

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
        [SerializeField]
        AudioSource echoPrefab;


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
            if(Physics.Raycast(transform.position,transform.forward,out var hit,10,255,QueryTriggerInteraction.Ignore))
            {
                GameObject.Instantiate(echoPrefab,hit.point,Quaternion.Euler(hit.normal)); //Pool me!
            }
        }
    }
}