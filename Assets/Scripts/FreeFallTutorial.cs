using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFallTutorial : MonoBehaviour
{
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("FreeFall"))
        {
            PlayerPrefs.SetInt("FreeFall", 1);

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTutorial()
    {
        PlayerPrefs.DeleteKey("FreeFall");
    }
}
