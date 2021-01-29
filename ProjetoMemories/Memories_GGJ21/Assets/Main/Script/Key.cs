using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Door doorKey;

    public void GetKey()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<BoxCollider>().enabled = false;
        doorKey.SetGetKey();
    }
}
