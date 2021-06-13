using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponAudio : AudioPlayer
{
    [SerializeField]
    private AudioClip shootBulletClip = null, outOfBulletsClip = null;

    public void PlayShootSound()
    {
        PlayClip(shootBulletClip);
    }

    public void PlayNoBulletsSound()
    {
        PlayClip(outOfBulletsClip);
    }
}
