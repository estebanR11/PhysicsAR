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
        manager.setText(text, new Vector2(0.8f, 0.8f));
        manager.gameObject.transform.localScale = new Vector2(0.8f, 0.8f);
    }

    public void SpawnPrefabFall(string y, string t, string vel)
    {
        string text = "T: " + t + "s -" + "Y: " + y + "m -" +  "V: " + vel + " m/s";

        TextManager manager = Instantiate(prefab).GetComponent<TextManager>();
        manager.gameObject.transform.SetParent(this.transform);
        manager.setText(text, new Vector2(0.8f, 0.8f));
        manager.gameObject.transform.localScale = new Vector2(0.8f, 0.8f);
    }

    public void SpawnPrefabThirdLaw(string x, string t, string y, string value)
    {
        string text = "T: " + t + "s -" + "X: " + x + "m -" + "Y: " + y + " m -" + "D: " + value;
         
        TextManager manager = Instantiate(prefab).GetComponent<TextManager>();
        manager.gameObject.transform.SetParent(this.transform);
        manager.setText(text, new Vector2(0.8f, 0.8f));
        manager.gameObject.transform.localScale = new Vector2(0.8f,0.8f);
    }
}
