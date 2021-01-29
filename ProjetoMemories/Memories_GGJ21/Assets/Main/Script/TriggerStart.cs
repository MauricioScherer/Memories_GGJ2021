using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStart : MonoBehaviour
{
    [SerializeField]private Animator animIntro;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animIntro.SetTrigger("StartIntro");
        }
    }
}
