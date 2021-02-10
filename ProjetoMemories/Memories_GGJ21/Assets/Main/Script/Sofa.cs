using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] MeshRenderer tela;
    [SerializeField] Material matTela;
    [SerializeField] AudioSource somLigar;

    public void startCredito()
    {
        tela.material = matTela;
        somLigar.Play();
        gameManager.Final();
    }
}
