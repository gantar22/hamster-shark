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
    public class MouseControls : MonoBehaviour
    {
        [SerializeField]
        float speed = 1;


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
                transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X"),0);

                if(Input.GetKey(KeyCode.Mouse0))
                {
                    transform.position += transform.forward * speed * Time.deltaTime;
                }
                //if(Input.GetKey(KeyCode.Mouse1))
                //{
                //    transform.position -= transform.forward * speed * Time.deltaTime;
                //}
            }
        }
    }
}