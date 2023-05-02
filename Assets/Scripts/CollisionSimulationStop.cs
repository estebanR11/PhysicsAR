using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSimulationStop : MonoBehaviour
{
    [SerializeField] FrictionObject friction;

    [SerializeField] Animator[] fences;

    [SerializeField] AudioSource source;
    [SerializeField] GameObject fx;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            friction.stopSimul();

            for(int i =0;i<fences.Length;i++)
            {
                fences[i].SetTrigger("Fall");

            }
            source.Play();    
        fx.SetActive(true);
        
        }
    }
}
