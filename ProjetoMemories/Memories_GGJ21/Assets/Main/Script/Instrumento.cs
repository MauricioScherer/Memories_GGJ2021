using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrumento : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioSource somInstrumento;

    public void PlayInstrument()
    {
        somInstrumento.clip = clips[Random.Range(0, clips.Length)];
        somInstrumento.Play();
    }
}
