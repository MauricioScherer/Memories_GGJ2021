using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VO : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] AudioClip clip;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.PlayVO(clip);
        }
    }
}
