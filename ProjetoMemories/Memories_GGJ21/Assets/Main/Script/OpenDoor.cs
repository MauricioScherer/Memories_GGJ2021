using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool move;
    bool closed;
    Transform target;

    [SerializeField] float speed;
    [SerializeField] Transform targetOpen;
    [SerializeField] Transform targetClose;

    void Update()
    {
        if(move)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, speed * Time.deltaTime);

            if (transform.rotation == target.rotation)
            {
                move = false;
            }
        }
    }

    public void InteractDoor()
    {
        if(closed)        
            target = targetOpen;        
        else        
            target = targetClose;        

        closed = !closed;
        move = true;
    }
}
