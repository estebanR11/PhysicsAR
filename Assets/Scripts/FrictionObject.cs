using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FrictionObject : MonoBehaviour
{
    [SerializeField] ResultsManager resultsManager;
    [SerializeField] TextMeshProUGUI massText;
    [SerializeField] TextMeshProUGUI frictionText;
    [SerializeField] TMP_InputField frictionInput;
    [SerializeField] TMP_InputField massInput;
    [SerializeField] Button launch;

    float x0; 
    float y0; 
    float v0x; 
    float v0y; 
    public float masa = 1.0f; 
    float angulo = 30.0f; 
    float anguloRad;
    public float coeficienteFriccion = 0.2f; 
    float time = 0.0f; 
    float intervalo = 0.5f; 
    float Fg;
    
    float N ;
    float Ffriccion; 
    Vector2 posicionAnterior;
    float distance = 0.0f;
    float R0;

    bool isSimul = false;
    private Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);

    bool hasBeenChangedFriction = false;
    bool hasBeenChangedMass = false;

    private void Start()
    {
        launch.interactable = false;
    }
    public void StartSimul()
    {
        launch.interactable = false;
        massInput.interactable = false;
        frictionInput.interactable = false;
        
        Fg = masa * Physics2D.gravity.magnitude;
        N = masa * Mathf.Cos(angulo * Mathf.Deg2Rad) * Physics2D.gravity.magnitude;
        x0 = 0.0f;
        y0 = 0.0f;
        v0x = 0.0f;
        v0y = 0.0f;
        R0 = 0.0f;
        Ffriccion = coeficienteFriccion * N;
        posicionAnterior = new Vector2(0.0f,0.0f);

        resultsManager.SpawnPrefabThirdLaw(0.0f.ToString("F2"), 0.0f.ToString("F2"), 0.0f.ToString("F2"), 0.0f.ToString());
        isSimul = true;
        StartCoroutine(CalculatePosition());

        GetComponent<Rigidbody>().useGravity = true;

    }
    void Update()
    {
       
    }


    IEnumerator CalculatePosition()
    {
        time += intervalo;
        yield return new WaitForSeconds(intervalo);
        while (isSimul)
        {

            float ax = 9.8f * (Mathf.Sin(Mathf.PI / 6) - coeficienteFriccion * Mathf.Cos(Mathf.PI / 6)) * Mathf.Cos(Mathf.PI / 6);   // Aceleración en X


            float ay = -9.8f * (Mathf.Sin(Mathf.PI / 6) - coeficienteFriccion * Mathf.Cos(Mathf.PI / 6)) * Mathf.Sin(Mathf.PI / 6); // Aceleración en Y


            float x = x0 + v0x * time + 0.5f * ax * time * time; // Posición en X
            float y = y0 + v0y * time + 0.5f * ay * time * time; // Posición en Y

            Vector2 posicionActual = new Vector2(x, y);
            float dx = posicionActual.x - posicionAnterior.x;
            float dy = posicionActual.y - posicionAnterior.y;
            float distanceBetweenPositions = Mathf.Sqrt(dx * dx + dy * dy);

            distance += distanceBetweenPositions;

            resultsManager.SpawnPrefabThirdLaw(x.ToString("F2"), time.ToString("F2"), y.ToString("F2"), distance.ToString());

            Vector3 movement = new Vector3(x - transform.position.x, y - transform.position.y, 0f);
            transform.Translate(new Vector3(ax, 0, ay) * Time.deltaTime);

            posicionAnterior = posicionActual;
            yield return new WaitForSeconds(intervalo);
            time += intervalo;
        }


         

    
   }

        
    public void stopSimul()
    {
        StopAllCoroutines();
        isSimul = false;

    }



    public void changeMass(string massTxt)
    {
        hasBeenChangedMass = true;

        float mass = float.Parse(massTxt);
        if(mass > 1000f)
        {
            masa = 1000f;
            massInput.text = "1000" ;
        }
        else if(mass < 0)
        {
            masa = 1f;
            massInput.text= "1";
        }
   
        else
        {
            masa = mass;

        }

        if (hasBeenChangedFriction && hasBeenChangedMass)
        {
            launch.interactable = true;
        }
    }

    public void changeFriction(string frictionTxt)
    {
        hasBeenChangedFriction = true;
        float friction = float.Parse(frictionTxt);

        if (friction > 1)
        {
            coeficienteFriccion = 1;
            frictionInput.text = "1";
        }
        else if (friction < 0)
        {
            coeficienteFriccion = 0.1f;
            frictionInput.text = "0.1";
        }

        else
        {
            coeficienteFriccion = friction;

        }

        if (hasBeenChangedFriction && hasBeenChangedMass)
        {
            launch.interactable = true;
        }

    }

}