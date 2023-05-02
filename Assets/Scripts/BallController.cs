using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Launcher launcher;
    [SerializeField] Animator[] redPlayers;
    [SerializeField] Animator[] bluePlayers;

    [SerializeField] GameObject[] blueFireworks;
    [SerializeField] GameObject[] redFireworks;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "post")
        {
            launcher.stopCalculating();
            HappyBlue();

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            HappyBlue();
            launcher.stopCalculating();
        }
    }

    public void HappyRed()
    {
        for (int i = 0; i < redPlayers.Length; i++)
        {
            redPlayers[i].SetTrigger("Happy");
        }
        for (int i = 0; i < bluePlayers.Length; i++)
        {
            bluePlayers[i].SetTrigger("Sad");
        }

        for(int i =0;i <redFireworks.Length;i++)
        {
            redFireworks[i].SetActive(true);
        }
    }

    public void HappyBlue()
    {
        for (int i = 0; i < redPlayers.Length; i++)
        {
            redPlayers[i].SetTrigger("Sad");
        }
        for (int i = 0; i < bluePlayers.Length; i++)
        {
            bluePlayers[i].SetTrigger("Happy");
        }
         for (int i = 0; i < blueFireworks.Length; i++)
        {
            blueFireworks[i].SetActive(true);
        }
    }
}
