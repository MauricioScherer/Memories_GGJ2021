using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBullyng : MonoBehaviour
{
    int status;
    bool finishing;

    [SerializeField] AudioClip[] clipsRindo;
    [SerializeField] AudioSource boneco1Rindo;
    [SerializeField] AudioSource boneco2Rindo;

    [SerializeField] Animator animBoneco1;
    [SerializeField] Animator animBoneco2;

    private bool move;
    [SerializeField] Transform boneco1;
    [SerializeField] Transform targetBoneco1;
    [SerializeField] Transform boneco2;
    [SerializeField] Transform targetBoneco2;
    [SerializeField] float speed;
    [SerializeField] AudioSource trilho1;
    [SerializeField] AudioSource trilho2;

    [SerializeField] Door door1;
    [SerializeField] Door door2;


    private void Start()
    {
        boneco1Rindo.clip = clipsRindo[Random.Range(0, clipsRindo.Length)];
        boneco2Rindo.clip = clipsRindo[Random.Range(0, clipsRindo.Length)];
    }

    private void Update()
    {
        if(!finishing)
        {
            if (!boneco1Rindo.isPlaying)
            {
                int p_sort = Random.Range(0, clipsRindo.Length);
                boneco1Rindo.clip = clipsRindo[p_sort];
                boneco1Rindo.Play();
            }
            if (!boneco2Rindo.isPlaying)
            {
                int p_sort = Random.Range(0, clipsRindo.Length);
                boneco2Rindo.clip = clipsRindo[p_sort];
                boneco2Rindo.Play();
            }
        }

        if(move)
        {
            boneco1.position = Vector3.MoveTowards(boneco1.position, targetBoneco1.position, speed * Time.deltaTime);
            boneco2.position = Vector3.MoveTowards(boneco2.position, targetBoneco2.position, speed * Time.deltaTime);

            if (boneco1.position == targetBoneco1.position)
                trilho1.Stop();
            if (boneco2.position == targetBoneco2.position)
                trilho2.Stop();
        }
    }

    public void Click()
    {
        status++;

        if(status == 3)
        {
            finishing = true;
            boneco1Rindo.Stop();
            boneco2Rindo.Stop();

            animBoneco1.enabled = false;
            animBoneco2.enabled = false;

            move = true;

            door1.Unlocked();
            door1.InteractDoor();
            door2.Unlocked();
            door2.InteractDoor();

            trilho1.Play();
            trilho2.Play();
        }
    }
}
