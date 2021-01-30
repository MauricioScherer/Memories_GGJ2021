using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNovaSala : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private GameObject novaSala;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            novaSala.SetActive(true);
            gameManager.StopedMusic();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
