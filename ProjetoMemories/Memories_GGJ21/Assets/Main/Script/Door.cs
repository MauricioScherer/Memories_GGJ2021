using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim;
    private bool getKey;
    private bool openDoorLocked;

    [SerializeField] private bool lockedDoor;
    [SerializeField] private GameObject key;

    private void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("Close", true);
        anim.SetBool("Open", false);
    }

    public void InteractDoor()
    {
        if (!lockedDoor)
        {
            if(anim.GetBool("Close"))
            {
                anim.SetBool("Open", true);
                anim.SetBool("Close", false);
            }
            else
            {
                anim.SetBool("Close", true);
                anim.SetBool("Open", false);
            }
        }
        else
        {
            if(getKey)
            {
                key.SetActive(true);
                lockedDoor = false;

                anim.SetBool("Open", true);
                anim.SetBool("Close", false);
                openDoorLocked = true;
            }
            else
            {
                anim.SetTrigger("Locked");
            }
        }
    }

    public bool GetOpenDoorLocked()
    {
        return openDoorLocked;
    }

    public void SetLockedDoor()
    {
        lockedDoor = true;
    }

    public void SetGetKey()
    {
        getKey = true;
    }
}
