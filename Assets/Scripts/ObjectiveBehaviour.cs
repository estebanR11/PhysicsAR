using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveBehaviour : MonoBehaviour
{
    [SerializeField] Vector3 actualTransform;
    [SerializeField] Vector3 otherTransform;

    [SerializeField] UnityEvent onMoveEvent;
    [SerializeField] UnityEvent arrivedEvent;

    private void Start()
    {
        actualTransform = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        otherTransform = transform.position;
        if(actualTransform != otherTransform)
        {
            onMoveEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        arrivedEvent.Invoke();
    }
}
