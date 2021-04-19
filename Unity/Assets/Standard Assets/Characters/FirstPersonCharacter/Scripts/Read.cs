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
    public TextAsset specialFile;
    public TextAsset letterFile;
    public TextAsset textFile;
    public GameObject book;
    public TMP_Text text1;
    public TMP_Text text2;
    private int meaningPrecentage;
    private string[] speciallist;
    private string[] wordlist;
    private string[] charlist;
    private string[] letterlist;
    private string[] textlist;
    
    
    // Start is called before the first frame update
    void Start()
    {
       wordlist = wordFile.text.Split('\n');
       charlist = letterFile.text.Split('\n');
       speciallist = specialFile.text.Split('\n');
       textlist = textFile.text.Split('@');
       letterlist = new string[26];
       Array.Copy(charlist, 0, letterlist, 0, 26);
       meaningPrecentage = 10;
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
           text2.text = CreateText(100, StaticValues.floor);
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
      if(meaningPrecentage >= UnityEngine.Random.Range(1,100))
      {
        return "<u>"+ speciallist[UnityEngine.Random.Range(0,speciallist.Length)] +"</u>";
      }  
      else
      {
        return wordlist[UnityEngine.Random.Range(0,wordlist.Length)];
      }
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
         word = letterlist[UnityEngine.Random.Range(0,letterlist.Length)] + word;
       }
       if(meaningPrecentage >= UnityEngine.Random.Range(1,100))
       {
         word = "<u>"+word+"</u>";
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
    string CreateText(int length,int randomnes = 0)
    {
      string text = "";
      while(text.Length< length)
      {
        if (randomnes<6)
        {
          //random to normal word ratio varies from 0 -> 50 %
          text = text + CreateSentence(randomnes) + "  ";
        }
        else if (randomnes <10)
        {
          //vary the random to normal word 50 -> 400%
          if(0 == UnityEngine.Random.Range(0,(randomnes-5)))
          {
            text = text + PickWord() + charlist[UnityEngine.Random.Range(27,32)];
          }
          else
          {
            text = text + CreateWord() + charlist[UnityEngine.Random.Range(27,32)];
          }
            
        }
        else
        {
          //the amount of random charachters between words on avrage starts at 50 and increases by 5 per floor
          if(0 == UnityEngine.Random.Range(0,(randomnes*5)))
          {
            text = text + PickWord();
          }
          else
          {
            text = text + charlist[UnityEngine.Random.Range(0,32)];
          }
        }
      
      }
      return text;
    }
}
