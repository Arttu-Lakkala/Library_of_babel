using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class Read : MonoBehaviour
{
    //!REMINDER!
    //public variables are set in Inpector
    public TextAsset wordFile;
    public TextAsset letterFile;
    public TextAsset textFile;
    public GameObject book;
    public TMP_Text text1;
    public TMP_Text text2;
    private string[] wordlist;
    private string[] charlist;
    private string[] letterlist;
    private string[] textlist;
    
    // Start is called before the first frame update
    void Start()
    {
       wordlist = wordFile.text.Split('\n');
       charlist = letterFile.text.Split('\n');
       textlist = textFile.text.Split('@');
       letterlist = new string[26];
       Array.Copy(charlist, 0, letterlist, 0, 26);
    }

    // Update is called once per frame
    void Update()
    {
       //rightclick
       if(Input.GetMouseButtonUp(1))
       {
         book.SetActive(false);
         RaycastHit hit;
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         
         if(Physics.Raycast(ray, out hit, 1000))
         {
           text1.text = textlist[UnityEngine.Random.Range(0,textlist.Length)];
         }
       }
       //Leftclick
       if(Input.GetMouseButtonUp(0))
       {
         book.SetActive(true);
       }       
    }
    
    string PickWord()
    {
      return wordlist[UnityEngine.Random.Range(0,wordlist.Length)];
    }
    
    string CreateWord()
    {
       int precentage = UnityEngine.Random.Range(1,100);
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
         word = word + letterlist[UnityEngine.Random.Range(0,letterlist.Length)];
       }
       return word;
    }
    string CreateSentence(int randomnes = 0)
    {
     int precentage = UnityEngine.Random.Range(1,100);
     int sentenceLength;
     string sentence = "";
     
     if(precentage<5)
     {
       sentenceLength=1;
     }
     else if(precentage<15)
     {
       sentenceLength=2;
     }
     else if(precentage<40)
     {
       sentenceLength=3;
     }
     else if(precentage<65)
     {
       sentenceLength=4;
     }
     else if(precentage<85)
     {
       sentenceLength=5;
     }
     else if(precentage<95)
     {
       sentenceLength=6;
     }
     else
     {
       sentenceLength=7;
     }
     for(int i=1; i<=sentenceLength; i++)
     {
       int createChance = UnityEngine.Random.Range(0,10);
       //add or create word depending on randomnes variable
       if(createChance < randomnes)
       {
         sentence = sentence + CreateWord();
       }
       else
       {
         sentence = sentence + PickWord();
       }
       //add space or puncuation.
       if(i<sentenceLength)
       {
         sentence = sentence +" ";
       }
       else
       {
         sentence = sentence + charlist[UnityEngine.Random.Range(27,30)];
       }
     }
     return sentence;
    }
}
