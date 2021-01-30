using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeclaPiano : MonoBehaviour
{
    private AudioSource nota;
    private Animator click;

    [SerializeField] private int value;
    [SerializeField] private Piano piano;

    // Start is called before the first frame update
    void Start()
    {
        nota = GetComponent<AudioSource>();
        click = GetComponent<Animator>();
    }

    public void Click()
    {
        nota.Play();
        click.SetTrigger("Click");
        piano.CheckOrder(value);
    }
}
