using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNovaSala2 : MonoBehaviour
{
    [SerializeField] private GameObject novaSala;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            novaSala.SetActive(true);
        }
    }
}
