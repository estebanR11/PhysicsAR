using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FrictionObject : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = 9.81f;
    public float friction = 0.1f;
    bool isSimulating =false ;
    private Vector3 velocity;
    [SerializeField] ResultsManager resultsManager;
    float actualTime;
    public void StartSimul()
    {


        resultsManager.SpawnPrefabThirdLaw(transform.position.x.ToString("F2"), actualTime.ToString("F2"), transform.position.y.ToString("F2"));
    
        isSimulating = true;
        InvokeRepeating("GetData", 0.5f, 0.5f);

    }
    void Update()
    {
        if(isSimulating)
        {
            float angle = 30f;
            float radians = -angle * Mathf.Deg2Rad;
            float opposite = Mathf.Sin(radians) * -gravity;
            float adjacent = Mathf.Cos(radians) * -gravity;

            velocity += new Vector3(adjacent, opposite, 0) * Time.deltaTime;

            velocity -= velocity * friction * Time.deltaTime;

            transform.position += velocity * Time.deltaTime;

        }
     
    }

    public void GetData()
    {
        actualTime += 0.5f;

        resultsManager.SpawnPrefabThirdLaw(transform.position.x.ToString("F2"), actualTime.ToString("F2"), transform.position.y.ToString("F2"));

    }




}