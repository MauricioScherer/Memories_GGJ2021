using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMenina : MonoBehaviour
{
    private bool moveHaste;
    private Transform currentTarget;
    private int status;

    private bool moveParede;
    private bool moveMenina;
    private bool fimPuzzle;
    private GameManager gameManager;

    [SerializeField] AudioClip clipMusic; 
    [SerializeField] Animator menina;
    [SerializeField] Transform hasteBalao;
    [SerializeField] Transform[] target;
    [SerializeField] AudioSource soundHaste;
    [SerializeField] float speed;
    [SerializeField] GameObject[] confette;

    [Header("Parede Secreta")]
    [SerializeField] Transform paredeSecreta;
    [SerializeField] Transform targetParede;
    [SerializeField] AudioSource soundParede;
    [SerializeField] float speedParede;

    [Header("menina")]
    [SerializeField] Transform meninaMove;
    [SerializeField] Transform meninaTarget;
    [SerializeField] float speedMenina;
    [SerializeField] AudioSource trilhoMeninaMove;
    [SerializeField] AudioSource choro;
    [SerializeField] AudioClip[] clipsChoro;
    [SerializeField] Material matMeninaFeliz;
    [SerializeField] MeshRenderer meshMenina;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(!choro.isPlaying && !moveMenina && !fimPuzzle)
        {
            int p_sort = Random.Range(0, clipsChoro.Length);
            choro.clip = clipsChoro[p_sort];
            choro.Play();
        }

        if(moveHaste)
        {
            hasteBalao.position = Vector3.MoveTowards(hasteBalao.position, currentTarget.position, speed * Time.deltaTime);

            if(hasteBalao.position == currentTarget.position)
            {
                soundHaste.Stop();
                moveHaste = false;

                if(status == 2)
                {
                    foreach (GameObject obj in confette)
                        obj.SetActive(true);

                    menina.SetTrigger("PegarBalao");
                    moveParede = true;
                    choro.Stop();

                    meshMenina.material = matMeninaFeliz;

                    soundParede.Play();
                    gameManager.SetClipMusic(clipMusic);
                    gameManager.PlayerMusic();
                }
            }
        }

        if(moveParede)
        {
            paredeSecreta.position = Vector3.MoveTowards(paredeSecreta.position, targetParede.position, speedParede * Time.deltaTime);

            if (paredeSecreta.position == targetParede.position)
            {
                soundParede.Stop();
                moveMenina = true;
                fimPuzzle = true;
                choro.Stop();
                trilhoMeninaMove.Play();
                moveParede = false;
            }
        }

        if(moveMenina)
        {
            meninaMove.position = Vector3.MoveTowards(meninaMove.position, meninaTarget.position, speedMenina * Time.deltaTime);

            if (meninaMove.position == meninaTarget.position)
            {
                trilhoMeninaMove.Stop();
                moveMenina = false;
            }
        }
    }

    public void FinalPuzzle()
    {
        moveHaste = true;
        soundHaste.Play();
        currentTarget = target[status];
        status++;
    }
}
