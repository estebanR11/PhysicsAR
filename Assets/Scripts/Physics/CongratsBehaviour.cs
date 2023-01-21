using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratsBehaviour : MonoBehaviour
{

    [SerializeField] ParticleSystem particles;

    private void Start()
    {
        particles.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(Congrats());

    }

    IEnumerator Congrats()
    {
        particles.Play();
        yield return new WaitForSeconds(2.0f);
        particles.gameObject.SetActive(false);
    }
}
