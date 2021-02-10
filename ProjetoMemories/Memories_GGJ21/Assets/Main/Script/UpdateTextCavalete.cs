using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTextCavalete : MonoBehaviour
{
    [SerializeField] string[] _texts;

    void Start()
    {
        GetComponent<TextMeshPro>().text = _texts[PlayerPrefs.GetInt("Language")];
    }
}
