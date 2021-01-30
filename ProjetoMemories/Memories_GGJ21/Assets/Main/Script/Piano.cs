using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    private int currentPosition = 0;
    private bool finalize;

    [SerializeField] private int[] order;
    [SerializeField] private PuzzleMenina puzzleMenina;

    public void CheckOrder(int p_value)
    {
        if(!finalize)
        {
            if (p_value == order[currentPosition])
            {
                currentPosition++;
            }
            else
            {
                currentPosition = 0;
            }

            if (currentPosition == order.Length)
            {
                Final();
            }
        }
    }

    private void Final()
    {
        finalize = true;
        puzzleMenina.FinalPuzzle();
    }
}
