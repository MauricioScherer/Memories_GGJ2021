using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credito : MonoBehaviour
{
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
