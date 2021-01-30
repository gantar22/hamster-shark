using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: cwilliams@filamentgames.com
 *
 * Purpose:
 * 
 *
 */
public class AdhocReload : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}