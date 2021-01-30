using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiggerMusic : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.SetClipMusic(clip);
            gameManager.PlayerMusic();
            Destroy(gameObject);
        }
    }
}
