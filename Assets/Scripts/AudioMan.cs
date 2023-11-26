using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    // [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public AudioClip ammoPick;
    public AudioClip gameOver;
    public AudioClip shoot;
    public AudioClip zombieWalk;
    public AudioClip emptyGun;
    public AudioClip playerDamage;

    public void PlaySFX(AudioClip audioClip) 
    {
        if (audioClip == playerDamage || audioClip == zombieWalk) 
        {
            sfx.loop = true;
        }
        sfx.PlayOneShot(audioClip);
    }
}
