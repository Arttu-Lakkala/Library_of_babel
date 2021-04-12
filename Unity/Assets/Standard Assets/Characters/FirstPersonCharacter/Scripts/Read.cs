using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
