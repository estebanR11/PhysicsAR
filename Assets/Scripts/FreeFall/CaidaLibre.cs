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




    [Header("Values")]
    [SerializeField] TextMeshProUGUI mass;

    Rigidbody rb;

    bool isSimulating; 
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
        
           

            isSimulating = true;
        StartCoroutine(getDataFalling());

     }

    public void GetData()
    {
        actualTime += timeBetweenSteps;

        resultsManager.SpawnPrefabFall(objectInfo.transform.position.y.ToString("F2"), actualTime.ToString("F2"), rb.velocity.y.ToString("F2"));

    }

    IEnumerator getDataFalling()
    {
        while(isSimulating)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            actualTime += timeBetweenSteps;
            rb.useGravity = true;
            resultsManager.SpawnPrefabFall(objectInfo.transform.position.y.ToString("F2"), actualTime.ToString("F2"), rb.velocity.y.ToString("F2"));
    
        }



    }
    public void StopSimul()
    {
     //   CancelInvoke();
        isSimulating = false;
        StopCoroutine(getDataFalling());

    }

    public void onMassValueChanged()
    {
        objectInfo.GetComponent<FallBox>().setMass((int)massSlider.value);
        mass.text = massSlider.value.ToString();
    }
}
