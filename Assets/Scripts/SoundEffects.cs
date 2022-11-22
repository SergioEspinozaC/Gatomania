using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public void playSonido(AudioClip clip)
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.PlayOneShot(clip);
    }
}