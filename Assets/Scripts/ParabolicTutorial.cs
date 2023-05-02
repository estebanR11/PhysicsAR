using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicTutorial : MonoBehaviour
{

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("Parabolic"))
        {
            PlayerPrefs.SetInt("Parabolic", 1);
        
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTutorial()
    {
        PlayerPrefs.DeleteKey("Parabolic");
    }
}
