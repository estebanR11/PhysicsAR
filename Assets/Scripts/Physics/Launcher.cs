using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Launcher : MonoBehaviour
{

    [SerializeField] GameObject cannon;
    [SerializeField] Transform objectiveTransform;

    [SerializeField] float h;
    [SerializeField] float gravity = -9.8f;

    [Range (1f,200)]
    [SerializeField] float steps = 0.5f;

  

    [SerializeField] List<Vector3> points;

    bool isOnAir;

    [SerializeField] ResultsManager resultsManager;

    [SerializeField]float timeBetweenSteps;
    [SerializeField] float timer;
    [SerializeField] float actualTime;

    [SerializeField] Slider anguloSlider;
    [SerializeField] Slider velSlider;


    [SerializeField] float angulo;
    [SerializeField] float velInicial;

    [Header("Values")]
    [SerializeField] TextMeshProUGUI ang;
    [SerializeField] TextMeshProUGUI vel;

    [SerializeField] Animator launcher;
    private void Start()
    {
       
        drawLineRenderer();

        onAnguloChange();
        onVelChange();
        Rigidbody rb = cannon.GetComponent<Rigidbody>();
        rb.useGravity = false;

    }
    private void Update()
    {
        if(cannon.transform.position.y  < 0)
        {
            StopMovement();
        }
     
    }


    public void Launch()
    {
        if(!isOnAir)
        {
            Rigidbody rb = cannon.GetComponent<Rigidbody>();
            rb.velocity = CalculateVelocity();

            isOnAir = true;
            launcher.SetTrigger("Launch");

            resultsManager.SpawnPrefab(cannon.transform.position.x.ToString("F2"), cannon.transform.position.y.ToString("F2"), actualTime.ToString("F2"));

            InvokeRepeating("getData", timeBetweenSteps, timeBetweenSteps);

        }

    }

    public void getData()
    {
      
         
          actualTime += timeBetweenSteps;
        // v0 * sin(?) * t - (1/2) * g * t^2
        //x = v0 * cos(?) * t

   
        resultsManager.SpawnPrefab(cannon.transform.position.x.ToString("F2"), cannon.transform.position.y.ToString("F2"), actualTime.ToString("F2"));
            

       
    }
    Vector2 CalculateVelocity()
    {
        Rigidbody rb = cannon.GetComponent<Rigidbody>();


        Physics.gravity = Vector3.up * gravity;
        rb.useGravity = true;

        float velix, veliy;

        veliy = velInicial * Mathf.Sin(angulo*(Mathf.PI/180));
        velix = velInicial * Mathf.Cos(angulo* (Mathf.PI / 180));


        return new Vector2(velix,veliy);
    }


  

    public void drawLineRenderer()
    {
        points = null;
 
        points = new List<Vector3>();
        Vector3 startingPoint, FinishPoint;
        Vector3 startingVelocity = CalculateVelocity();
        float totalTime = CalculateTotalTime(startingVelocity.y);
        float actualTime = 0;
        float step = totalTime / steps;

        FinishPoint = cannon.transform.position;
        points.Add(FinishPoint);
 

      
        while (actualTime < totalTime)
        {
            startingPoint = FinishPoint;

            FinishPoint = CalculateMovement(startingVelocity, actualTime);

            points.Add(startingPoint);        


            actualTime += step;


        }

  
        Vector3[] pointsToTheLines = new Vector3[points.Count];
        pointsToTheLines = points.ToArray();


    }

    private float CalculateTotalTime(float y) => -y / gravity + Mathf.Sqrt(2 * (objectiveTransform.position.y - h) / gravity);


    Vector3 CalculateMovement(Vector3 startingVelocity, float actualTime)
    {
        float displacementX;
        float displacementY;
        float displacementZ;

        displacementY = startingVelocity.y * actualTime + gravity * actualTime *actualTime/2;

        displacementX = startingVelocity.x * actualTime;

        displacementZ = startingVelocity.z * actualTime;

        return new Vector3(displacementX, displacementY, displacementZ);
    }

    public void StopMovement()
    {
        CancelInvoke();
        Rigidbody rb = cannon.GetComponent<Rigidbody>();


        if (cannon.transform.position.y < -2f)
        {
            rb.useGravity = false;



            rb.velocity = new Vector3(0, 0, 0);

        }

     
    }

    public void stopCalculating()
    {
        CancelInvoke();

    }



    public void onAnguloChange()
    {
        angulo = anguloSlider.value;
        ang.text = angulo.ToString();
      
    }

    public void onVelChange()
    {
        velInicial = velSlider.value;
        vel.text = velSlider.value.ToString();
    }
}
