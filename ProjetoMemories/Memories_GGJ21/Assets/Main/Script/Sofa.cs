using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public void startCredito()
    {
        gameManager.Final();
    }
}
