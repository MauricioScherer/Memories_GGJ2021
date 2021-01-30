using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlavancaCat : MonoBehaviour
{
    private bool podeInteragir = true;
    private Animator anim;

    [SerializeField] private RayCat rayCat;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InteractAlavancaCat()
    {
        if(podeInteragir)
        {
            if(!rayCat.GetFinalPuzzle())
            {
                anim.SetTrigger("Push");
                podeInteragir = false;
            }
        }
    }

    public void MoveCat()
    {
        rayCat.Movecat();
    }

    public void RotateCat()
    {
        rayCat.Rotatecat();
    }

    public void ResetAlavanca()
    {
        podeInteragir = true;
    }
}
