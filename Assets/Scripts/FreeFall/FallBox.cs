using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBox : MonoBehaviour
{
    [SerializeField] CaidaLibre caida;


    private void OnCollisionEnter(Collision collision)
    {
            if(collision.transform.tag == "Finish")
        {
            caida.StopSimul();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Finish")
        {

        }
    }
    public void setMass(int mass)
    {
        GetComponent<Rigidbody>().mass = mass;
    }
}
