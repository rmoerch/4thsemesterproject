using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PortalAudio : AudioPlayer
{
    [SerializeField]
    protected AudioClip portalEntryClip;
    public void PlayPortalEntrySound()
    {
        PlayClip(portalEntryClip);
    }
}
