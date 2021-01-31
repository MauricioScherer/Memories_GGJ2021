using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
    [SerializeField] GameObject chao;
    [SerializeField] GameObject lanterna;

    public void Click()
    {
        chao.SetActive(false);
        lanterna.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
