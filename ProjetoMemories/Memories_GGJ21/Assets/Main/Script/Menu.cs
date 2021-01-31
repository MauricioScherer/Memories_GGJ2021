using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }
}
