using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChavePainel : MonoBehaviour
{
    [SerializeField] PuzzleBullyng painel;

    [SerializeField] MeshRenderer luzPainel;
    [SerializeField] Material matLuzOK;

    [SerializeField] AudioSource soundColocaChave;
    [SerializeField] AudioSource soundChaveErrada;

    public void ColocaChave()
    {
        soundColocaChave.Play();
        painel.Click();
        luzPainel.material = matLuzOK;
    }

    public void ChaveErrada()
    {
        soundChaveErrada.Play();
    }
}
