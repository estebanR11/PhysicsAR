using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour
{

    [SerializeField]GameObject prefab;

    public void SpawnPrefab(string x,string y, string t)
    {
        string text = "X: " + x + "m - " + "Y: " + y + "m - " + "T: " + t + " s";
       
        TextManager manager= Instantiate(prefab).GetComponent<TextManager>();
        manager.gameObject.transform.SetParent(this.transform);
        manager.setText(text);
    }
}
