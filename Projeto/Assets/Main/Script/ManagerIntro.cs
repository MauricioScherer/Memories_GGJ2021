using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class ManagerIntro : MonoBehaviour
{
    [SerializeField] private float timeStartLight;
    [SerializeField] private Light lightIntro;

    [SerializeField] private FirstPersonController player;
    [SerializeField] private CameraController cameraControler;

    // Start is called before the first frame update

    void Start()
    {
        player.enabled = false;
        cameraControler.enabled = false;
        Invoke("StartLight", timeStartLight);
    }

    private void StartLight()
    {
        player.enabled = true;
        cameraControler.enabled = true;
        lightIntro.enabled = true;
    }
}
