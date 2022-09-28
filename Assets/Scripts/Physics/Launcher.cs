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

    [SerializeField]LineRenderer lines;

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
    private void Start()
    {
        lines = GetComponent<LineRenderer>();
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





        Rigidbody rb = cannon.GetComponent<Rigidbody>();
        rb.velocity = CalculateVelocity();

        isOnAir = true;
    
        resultsManager.SpawnPrefab(cannon.transform.position.x.ToString("F2"), cannon.transform.position.y.ToString("F2"), actualTime.ToString("F2"));

        InvokeRepeating("getData",timeBetweenSteps, timeBetweenSteps);
    
    }

    public void getData()
    {
      
         
          actualTime += timeBetweenSteps;

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


        Debug.Log(velix + " - " + veliy);
        return new Vector2(velix,veliy);
    }


  

    public void drawLineRenderer()
    {
        points = null;
        lines.positionCount = 0;
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

        lines.positionCount = 0;
        Vector3[] pointsToTheLines = new Vector3[points.Count];
        pointsToTheLines = points.ToArray();
        lines.positionCount = points.Count;

        lines.SetPositions(pointsToTheLines);

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
