using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JogadorOverlay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textoFrutas;
    [SerializeField] TextMeshProUGUI textoVidas;

    public void SetTextoFrutas(int n)
    {
        textoFrutas.text = $" x {n}";
    }

    public void SetTextoVidas(int n)
    {
        textoVidas.text = $" x {n}";
    }
}
