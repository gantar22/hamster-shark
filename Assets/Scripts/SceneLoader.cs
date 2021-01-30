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
public class SceneLoader : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}