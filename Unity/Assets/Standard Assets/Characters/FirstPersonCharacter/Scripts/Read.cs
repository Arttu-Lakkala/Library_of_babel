using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : MonoBehaviour
{
    public TextAsset wordFile;
    public TextAsset letterFile;
    private string[] wordlist;
    private string[] letterlist;
    // Start is called before the first frame update
    void Start()
    {
       wordlist = wordFile.text.Split('\n');
       letterlist = letterFile.text.Split('\n');
    }

    // Update is called once per frame
    void Update()
    {
       //rightclick
       if(Input.GetMouseButtonUp(1))
       {
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         if(Physics.Raycast(ray, out hit, 1000))
         {
           Debug.Log(wordlist[Random.Range(0,wordlist.Length)]);
         }
       }
       //Leftclick
       if(Input.GetMouseButtonUp(0))
       {
         int precentage = Random.Range(1,100);
         int wordLength;
         string word = "";
         //get a random precentage and convert to word length
         if(precentage<5)
         {
          wordLength = 1;
         }
         else if(precentage<15)
         {
          wordLength = 2;
         }
         else if(precentage<25)
         {
          wordLength = 3;
         }
         else if(precentage<45)
         {
          wordLength = 4;
         }
         else if(precentage<65)
         {
          wordLength = 5;
         }
         else if(precentage<75)
         {
          wordLength = 6;
         }
         else if(precentage<85)
         {
          wordLength = 7;
         }
         else if(precentage<90)
         {
          wordLength = 8;
         }
         else if(precentage<95)
         {
          wordLength = 9;
         }
         else
         {
          wordLength = 10;
         }
         //generate word based on length
         for(int i=0; i<wordLength; i++)
         {
           word = word + letterlist[Random.Range(0,25)];
         }
         Debug.Log(word);
       }       
    }
}
