using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBullyng : MonoBehaviour
{
    int status;

    [SerializeField] AudioClip[] clipsRindo;
    [SerializeField] AudioSource boneco1Rindo;
    [SerializeField] AudioSource boneco2Rindo;

    private void Start()
    {
        boneco1Rindo.clip = clipsRindo[Random.Range(0, clipsRindo.Length)];
        boneco2Rindo.clip = clipsRindo[Random.Range(0, clipsRindo.Length)];
    }

    private void Update()
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

    public void Click()
    {
        status++;

        if(status == 3)
        {
            print("Fim");
        }
    }
}
