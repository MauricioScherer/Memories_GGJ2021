using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSala : MonoBehaviour
{
    [SerializeField] private GameObject objOld;
    [SerializeField] private GameObject paredeFechamento;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(objOld);
            paredeFechamento.SetActive(true);
            Destroy(gameObject, 1.0f);
        }
    }
}
