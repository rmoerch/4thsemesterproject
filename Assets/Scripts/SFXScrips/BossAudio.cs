using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BossAudio : AudioPlayer
{
    [SerializeField]
    protected AudioClip bossClip;

    public void PlayBossSound()
    {
        PlayClipWithVariablePitch(bossClip);
    }
}
