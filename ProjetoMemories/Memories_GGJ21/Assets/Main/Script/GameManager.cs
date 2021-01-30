using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VHS;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Slider volume;
    [SerializeField] private float volumeStandard;
    [SerializeField] private Slider sensitivity;
    [SerializeField] private float sensitivityStandard;

    [Header("Sound")]
    public AudioMixer masterMixer;
    [SerializeField] private AudioSource music;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!pauseMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    public void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void PointEnter(GameObject p_obj)
    {
        p_obj.GetComponent<TextMeshProUGUI>().fontSize = 40;
        p_obj.GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }

    public void PointExit(GameObject p_obj)
    {
        p_obj.GetComponent<TextMeshProUGUI>().fontSize = 36;
        p_obj.GetComponent<TextMeshProUGUI>().color = Color.white;
    }

    public void ReturnPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;

        cameraController.SetSensitivity(sensitivity.value);
    }

    public void Sensibility(Slider p_slider)
    {
        sensitivity.value = p_slider.value;
    }

    public void Volume(Slider p_slider)
    {
        volume.value = p_slider.value;
        masterMixer.SetFloat("Volume", volume.value);
    }

    public void Restaurar()
    {
        sensitivity.value = sensitivityStandard;
        cameraController.SetSensitivity(sensitivity.value);

        volume.value = volumeStandard;
        masterMixer.SetFloat("Volume", volume.value);

        //adicionar reset do volume
    }

    public void SetClipMusic(AudioClip p_clip)
    {
        music.clip = p_clip;
    }

    public void PlayerMusic()
    {
        if(!music.isPlaying)
            music.Play();
    }
}
