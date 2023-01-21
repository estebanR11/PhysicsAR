using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEntry : MonoBehaviour
{
    [SerializeField] GameObject animatedBall;
    [SerializeField] GameObject physicsBall;
    private void OnTriggerEnter(Collider other)
    {
        animatedBall.SetActive(true);
        physicsBall.SetActive(false);
        
    }

}
