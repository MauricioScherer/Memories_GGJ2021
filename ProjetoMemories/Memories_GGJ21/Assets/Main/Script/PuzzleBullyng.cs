using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBullyng : MonoBehaviour
{
    int status;

    public void Click()
    {
        status++;

        if(status == 3)
        {
            print("Fim");
        }
    }
}
