using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueScribbleAudio : AudioPlayer
{
    [SerializeField]
    protected AudioClip scribbleClip;

    public void PlayScribbleSound()
    {
        PlayClipWithVariablePitch(scribbleClip);
    }
}
