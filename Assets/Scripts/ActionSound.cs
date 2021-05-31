using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSound : MonoBehaviour
{
    public void PlayWalkSound()
    {
        SoundManager.Instance.PlayAudioClip(2);
    }

    public void PlayDuckSound()
    {
        SoundManager.Instance.PlayAudioClip(0);
    }

    public void PlaySwingSound()
    {
        SoundManager.Instance.PlayAudioClip(1);
    }

    public void PlayerPushSound()
    {
        SoundManager.Instance.PlayAudioClip(3);
    }
}
