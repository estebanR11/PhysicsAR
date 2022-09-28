using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Launcher launcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "post")
        {
            launcher.stopCalculating();

        }

    }
}
