using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public void setText(string text)
    {
        textMeshProUGUI.text = text;
    }
}
