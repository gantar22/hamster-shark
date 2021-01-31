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
    Player.WallSounds wallSounds;


    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip pressAnyKey;


    [SerializeField]
    AudioClip whoAreYou;

    [SerializeField]
    AudioClip youMustBeLost;

    [SerializeField]
    AudioClip pressSpace;

    [SerializeField]
    AudioClip youPressedSpace;

    [SerializeField]
    AudioClip proceedByPressMouse;
    [SerializeField]
    AudioClip findTheWall;

    [SerializeField]
    AudioClip reachWallClip;
    [SerializeField]
    AudioClip reachWallClip2;
    [SerializeField]
    AudioClip reachWallClip3;

    [SerializeField]
    AudioClip youCanTurn;

    [SerializeField]
    AudioClip turnRight;

    [SerializeField]
    AudioClip thisIsACheckpoint;
    [SerializeField]
    private AudioClip pleaseLeave;
    [SerializeField]
    AudioClip firePing;
    [SerializeField]
    AudioClip didPing;
    [SerializeField]
    private AudioClip youGotIt;


    [SerializeField]
    BoxCollider prewall1;
    [SerializeField]
    BoxCollider prewall2;
    [SerializeField]
    BoxCollider prewall3;
    
    bool hasReachedFirstCheckPoint = false;
    bool hasReachedSecondCheckPoint = false;

    bool hasReachedThirdCheckPoint = false;

    bool hasReachedWall = false;


    void Awake()
    {
        //Disable all controls & reative sounds
        helpVoice.Paused = true;
        mouseControls.state = Player.MouseControls.State.Offline;
        echolocation.IsPaused = true;
        StartCoroutine(Tutorial());
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForSeconds(2);

        source.PlayOneShot(pressAnyKey);
        yield return new WaitUntil(() => Input.anyKey);
        yield return new WaitUntil(() => !source.isPlaying);

        source.PlayOneShot(whoAreYou);
        yield return new WaitUntil(() => !source.isPlaying);

        yield return new WaitForSeconds(1);

        source.PlayOneShot(youMustBeLost);
        yield return new WaitUntil(() => !source.isPlaying);


        yield return new WaitForSeconds(1);
        source.PlayOneShot(pressSpace);

        var time = Time.time;
        var pressedSpace = true;
        while(source.isPlaying || !Input.GetKey(KeyCode.Space))
        {
            yield return null;
            if(Time.time > time + 10)
            {
                pressedSpace = false;
                break;
            }
            if(Input.GetKey(KeyCode.Space))
            {
                break;
            }
        }
    
        yield return new WaitForSeconds(.25f);

        if(pressedSpace)
            source.PlayOneShot(youPressedSpace);
        
        yield return new WaitUntil(() => !source.isPlaying);


        yield return new WaitForSeconds(1);

        yield return Play(proceedByPressMouse);

        mouseControls.state = Player.MouseControls.State.OnlyMovement;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse0));
        source.PlayOneShot(findTheWall);
        
        
        wallSounds.Activate();
        yield return new WaitUntil(() => hasReachedWall);
        yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => !source.isPlaying); 
        
        yield return Play(reachWallClip);
        yield return Play(reachWallClip2);

        //yield return Play(reachWallClip3); move this somewhere else

        yield return new WaitForSeconds(1f);

        yield return Play(youCanTurn);
        mouseControls.state = Player.MouseControls.State.Online;
        yield return new WaitUntil(() => Vector3.Distance(mouseControls.transform.forward,Vector3.forward) > .25f);

        yield return Play(turnRight);

        prewall1.enabled = false;

        yield return Play(thisIsACheckpoint);
        yield return new WaitUntil(() => hasReachedFirstCheckPoint);
        


        prewall2.enabled = false;
        yield return new WaitUntil(() => hasReachedSecondCheckPoint);

        helpVoice.DoNothingCallout();

        yield return Play(pleaseLeave);

        echolocation.IsPaused = false;
        yield return Play(firePing);

        yield return new WaitUntil(() => Input.GetKey(KeyCode.Mouse1));

        yield return new WaitForSeconds(1);

        yield return Play(didPing);


        prewall3.enabled = false;
        yield return new WaitUntil(() => hasReachedThirdCheckPoint);

        yield return Play(youGotIt);

        //Done.
    }

    public void ReachWall()
    {
        hasReachedWall = true;
    }

    public void ReachFirstCheckPoint()
    {
        hasReachedFirstCheckPoint = true;
    }    
    public void ReachSecondCheckPoint()
    {
        hasReachedSecondCheckPoint = true;
    }    
    public void ReachThirdCheckPoint()
    {
        hasReachedThirdCheckPoint = true;
    }

    IEnumerator Play(AudioClip clip)
    {
        helpVoice.Paused = true;
        yield return new WaitUntil(() => !helpVoice.IsPlaying());
        source.PlayOneShot(clip);
        yield return new WaitUntil(() => !source.isPlaying);
        helpVoice.Paused = false; //this is so gross I can't even :(
    }
}