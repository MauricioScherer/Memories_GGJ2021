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
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource sound;

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

            sound.clip = clips[0];
            sound.Play();
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

                sound.clip = clips[0];
                sound.Play();
            }
            else
            {
                anim.SetTrigger("Locked");

                sound.clip = clips[1];
                sound.Play();
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

    public void Unlocked()
    {
        lockedDoor = false;
    }
}
