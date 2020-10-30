using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VirusCounter : MonoBehaviour
{
    [SerializeField]
    Type type = Type.Green;

    VirusController virusController;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        virusController = FindObjectOfType<VirusController>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        textMeshPro.text = virusController.GetNumberOfVirions((int)type).ToString();
    }
}
