using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CaidaLibre : MonoBehaviour
{
    [SerializeField] ResultsManager resultsManager;

    [SerializeField] GameObject objectInfo;

    [SerializeField] float gravity = -9.8f;

    [Range(1f, 200)]
    [SerializeField] float steps = 0.5f;


    [SerializeField] float timeBetweenSteps;
    [SerializeField] float timer;
    [SerializeField] float actualTime;

    [SerializeField] Slider massSlider;


    [SerializeField] GameObject explosion;

    [Header("Values")]
    [SerializeField] TextMeshProUGUI mass;

    Rigidbody rb;

    bool isSimulating;
    [SerializeField]float calculateValue;
    [SerializeField] float resultado;

    private void Start()
    {
        rb = objectInfo.GetComponent<Rigidbody>();
        rb.useGravity = false;
        onMassValueChanged();
    }

    private void Update()
    {
  


    }

    private void FixedUpdate()
    {

    }
    public void StartSimul() 
    { 

    
        resultsManager.SpawnPrefabFall(objectInfo.transform.position.y.ToString("F2"), actualTime.ToString("F2"), rb.velocity.y.ToString("F2"));
        rb.useGravity = true;
        isSimulating = true;
        InvokeRepeating("GetData",0.5f,0.5f);

     }

    public void GetData()
    {
        actualTime += 0.5f;
        
        resultsManager.SpawnPrefabFall(calculateData().ToString("F4"), actualTime.ToString("F2"), rb.velocity.y.ToString("F1"));

    }

    float calculateData()
    {
        //H + (1/2 -gt^2)
        resultado = (90 + (0.5f * gravity * Mathf.Pow(actualTime, 2)));

        return resultado;
    }
 
    public void StopSimul()
    {
     CancelInvoke();
        isSimulating = false;

        explosion.SetActive(true);


    }

    
    public void onMassValueChanged()
    {
        objectInfo.GetComponent<FallBox>().setMass((int)massSlider.value);
        mass.text = massSlider.value.ToString();
    }
}
