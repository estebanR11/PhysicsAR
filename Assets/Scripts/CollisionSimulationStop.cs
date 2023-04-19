using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSimulationStop : MonoBehaviour
{
    [SerializeField] FrictionObject friction;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            friction.stopSimul();
        }
    }
}
