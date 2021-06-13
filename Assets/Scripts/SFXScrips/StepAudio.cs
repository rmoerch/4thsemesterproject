using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StepAudio : AudioPlayer
{
    [SerializeField]
    protected AudioClip stepClip;
    
    public void PlayStepSound()
    {
        PlayClipWithVariablePitch(stepClip);
    }
}

