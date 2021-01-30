using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    bool radioComFita;
    Animator anim;

    [SerializeField] AudioSource soundRadio;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource error;
    [SerializeField] AudioSource colocaFita;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayRadio()
    {
        anim.SetTrigger("PlayComFita");
        soundRadio.Play();
        click.Play();
    }

    public void ColocaFita()
    {
        anim.SetTrigger("ColocaFita");
        radioComFita = true;
        colocaFita.Play();
    }

    public void PlayRadioSemFita()
    {
        anim.SetTrigger("PlaySemFita");
        error.Play();
    }

    public bool GetRadioComFita()
    {
        return radioComFita;
    }
}
