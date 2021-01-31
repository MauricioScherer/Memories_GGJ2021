using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCat : MonoBehaviour
{
    private bool canMove;
    private int rot;

    [SerializeField] private float distance;
    [SerializeField] private float distanceMove;

    [Header("Final Puzzle")]
    [SerializeField] private GameObject racao;
    [SerializeField] private GameObject fechamento;
    private bool finalPuzzle = false;

    [SerializeField] private AudioClip[] clips;
    [SerializeField] private GameObject[] confetis;


    private void Start()
    {
        canMove = true;
        rot = (int)transform.eulerAngles.y;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if(hit.collider.CompareTag("ParedeGato"))
            {
                canMove = false;
            }
            else
            {
                canMove = true;
            }

            if (hit.collider.CompareTag("FinalPuzzleCat"))
            {
                finalPuzzle = true;
                racao.SetActive(false);
                fechamento.SetActive(false);

                foreach(GameObject obj in confetis)
                {
                    obj.SetActive(true);
                }               
            }
        }
        else
        {
            canMove = true;
        }
    }

    public bool GetFinalPuzzle()
    {
        return finalPuzzle;
    }

    public void Movecat()
    {
        if (canMove)
        {
            if (rot == 180)
            {
                transform.localPosition = new Vector3(transform.transform.localPosition.x + distanceMove, transform.transform.localPosition.y, transform.transform.localPosition.z);
            }
            else if (rot == 0)
            {
                transform.localPosition = new Vector3(transform.transform.localPosition.x - distanceMove, transform.transform.localPosition.y, transform.transform.localPosition.z);
            }
            else if (rot == 270)
            {
                transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z - distanceMove);
            }
            else if (rot == 90)
            {
                transform.localPosition = new Vector3(transform.transform.localPosition.x, transform.transform.localPosition.y, transform.transform.localPosition.z + distanceMove);
            }

            int sort = Random.Range(0, clips.Length);
            GetComponent<AudioSource>().clip = clips[sort];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            print("não pode andar");
        }
    }

    public void Rotatecat()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90.0f, transform.eulerAngles.z);

        rot = (int)transform.eulerAngles.y;

    }
}
