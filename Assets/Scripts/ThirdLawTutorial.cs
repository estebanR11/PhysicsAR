using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLawTutorial : MonoBehaviour
{
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("ThirdLaw"))
        {
            PlayerPrefs.SetInt("ThirdLaw", 1);

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ResetTutorial()
    {
        PlayerPrefs.DeleteKey("ThirdLaw");
    }
}
