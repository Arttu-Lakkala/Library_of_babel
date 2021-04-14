using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : MonoBehaviour
{
    public TextAsset textFile;
    private string[] wordlist;
    // Start is called before the first frame update
    void Start()
    {
       wordlist = textFile.text.Split('\n');
       Debug.Log(wordlist.Length);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonUp(1))
       {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         if(Physics.Raycast(ray, out hit, 1000))
         {
           Debug.Log(hit.collider.gameObject.name);
         }
       }         
    }
}
