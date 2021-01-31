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
public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    DirectionalHelp helpVoice;
    [SerializeField]
    Player.MouseControls mouseControls;

    [SerializeField]
    Player.Echolocation echolocation;


    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip pressSpace;

    [SerializeField]
    AudioClip youPressedSpace;

    [SerializeField]
    AudioClip proceedByPressMouse;

    [SerializeField]
    AudioClip reachWallClip;

    [SerializeField]
    GameObject wall;

    [SerializeField]
    AudioClip youCanTurn;

    [SerializeField]
    AudioClip turnRight;

    [SerializeField]
    AudioClip thisIsACheckpoint;
    [SerializeField]
    AudioClip firePing;

    
    bool hasReachedFirstCheckPoint = false;
    bool hasReachedSecondCheckPoint = false;

    bool hasReachedWall = false;

    void Awake()
    {
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        //Disable all controls & reative sounds
        helpVoice.Paused = true;
        mouseControls.state = Player.MouseControls.State.Offline;
        echolocation.IsPaused = true;


        source.PlayOneShot(pressSpace);
        yield return new WaitUntil(() => !source.isPlaying);

        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
    
        yield return new WaitForSeconds(.25f);

        source.PlayOneShot(youPressedSpace);
        yield return new WaitUntil(() => !source.isPlaying);

        //Enable space && have space pause this tutorial?

        yield return new WaitForSeconds(1);

        yield return Play(proceedByPressMouse);
        mouseControls.state = Player.MouseControls.State.OnlyMovement;

        yield return new WaitUntil(() => hasReachedWall);
        
        yield return Play(reachWallClip);

        wall.SetActive(false);

        yield return new WaitForSeconds(1.5f);

        yield return Play(youCanTurn);
        mouseControls.state = Player.MouseControls.State.Online;
        yield return new WaitForSeconds(2);

        yield return Play(turnRight);

        yield return new WaitUntil(() => hasReachedFirstCheckPoint);
        
        yield return Play(thisIsACheckpoint);

        yield return new WaitUntil(() => hasReachedSecondCheckPoint);

        yield return Play(firePing);
        echolocation.IsPaused = false;

        //Done?
    }

    public void ReachWall()
    {
        hasReachedWall = true;
    }

    public void ReachFirstCheckPoint()
    {
        hasReachedFirstCheckPoint = true;
    }    public void ReachSecondCheckPoint()
    {
        hasReachedSecondCheckPoint = true;
    }

    IEnumerator Play(AudioClip clip)
    {
        helpVoice.Paused = true;
        yield return new WaitUntil(() => helpVoice.IsPlaying());
        source.PlayOneShot(clip);
        yield return new WaitUntil(() => source.isPlaying);
        helpVoice.Paused = false; //this is so gross I can't even :(
    }
}