using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public void setText(string text,Vector2 size)
    {
        textMeshProUGUI.text = text;
        transform.localScale = size;
    }
}
