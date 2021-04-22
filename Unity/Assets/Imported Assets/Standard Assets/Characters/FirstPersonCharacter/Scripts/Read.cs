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
    public TextAsset specialTexts;
    public TextAsset dialogFile;
    public GameObject book;
    public GameObject uiLibrarian;
    public GameObject uiGrandma;
    public GameObject dialogBox;
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text dialogText;
    public AudioClip pageSound;
    public AudioClip librarianCough;
    public AudioClip librarianStrange;
    public AudioClip librarianDuck;
    public AudioClip librarianTrain;
    public AudioClip librarianElectric;
    public AudioClip librarianBird;
    private int meaningPrecentage;
    private string[] speciallist;
    private string[] wordlist;
    private string[] charlist;
    private string[] letterlist;
    private string[] textlist;
    private string[] dialoglist;
    private string[] specialList;
    private string[] floorDialog;
    private int grandmaFloor;
    private AudioSource audioSource;
    private int librarianCounter;
    private bool firstRead;
    
    
    // Start is called before the first frame update
    void Start()
    {
       wordlist = wordFile.text.Split('\n');
       charlist = letterFile.text.Split('\n');
       speciallist = specialFile.text.Split('\n');
       textlist = textFile.text.Split('@');
       specialList = specialTexts.text.Split('@');
       dialoglist = dialogFile.text.Split('@');
       letterlist = new string[26];
       Array.Copy(charlist, 0, letterlist, 0, 26);
       meaningPrecentage = 10;
       grandmaFloor = 4;
       librarianCounter = 0;
       floorDialog = dialoglist[StaticValues.floor].Split('$');
       audioSource = GetComponent<AudioSource>();
       firstRead = true;
    }

    // Update is called once per frame
    void Update()
    {
       //rightclick
       if(Input.GetMouseButtonUp(1))
       {
         if((StaticValues.busy))
         {
           StaticValues.busy = false;
           //close UI elements
           uiGrandma.SetActive(false);
           book.SetActive(false);
           dialogBox.SetActive(false);
           uiLibrarian.SetActive(false);
           audioSource.volume = 0.25f;
         }         
       }
       //Leftclick
       if(Input.GetMouseButtonUp(0))
       {
         if(!(StaticValues.busy))
         {
           RaycastHit hit;
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if(Physics.Raycast(ray, out hit, 2, LayerMask.GetMask("shelf")))
           {
            StaticValues.busy = true;
            audioSource.volume = 1.0f;
            audioSource.clip = pageSound;
            audioSource.Play();
            //in the future if there are alot of single floors change them to switch case and have createtext be default
            if(StaticValues.floor ==0)
            {
              int textIndex = UnityEngine.Random.Range(0,textlist.Length);
              string[] preset = textlist[textIndex].Split('$');
              text1.text = preset[0];
              text2.text = preset[1];
              text1.fontSize = 24;
              text2.fontSize = 24;
              if(textIndex ==0)
              {
               text1.fontSize = 20;
               text2.fontSize = 20;
              }
            }
            else if(StaticValues.floor ==5 & firstRead)
            {
              string[] preset = specialList[0].Split('$');
              text1.text = preset[0];
              text2.text = preset[1];
              text1.fontSize = 24;
              text2.fontSize = 24;
            }
            else if(StaticValues.floor == grandmaFloor & firstRead)
            {
              string[] preset = specialList[1].Split('$');
              text1.text = preset[0];
              text2.text = preset[1];
            }
            else if(StaticValues.floor ==9)
            {
              string exeption="YWH HWY YWH HWY YWH HWY YWH HWY YWH HWY YWH HWY YWH HWY YWH HWY YWH HWY";
              exeption=exeption + exeption;
              text1.text = exeption;
              text2.text = exeption;
            }
            else
            {
            text1.text = CreateText(200, StaticValues.floor);
            text2.text = CreateText(200, StaticValues.floor);
            }
            if(firstRead)
            {
              firstRead = false;
            }
            book.SetActive(true);
           }
           else{
            RaycastHit2D hitInfo = Physics2D.Raycast(Input.mousePosition, Vector2.zero);
            if(Physics.Raycast(ray, out hit, 2, LayerMask.GetMask("nonPc")))
            {
              //set text 
              StaticValues.busy = true;
              dialogText.text = floorDialog[librarianCounter];
              librarianCounter = librarianCounter +1;
              if(librarianCounter==floorDialog.Length)
              {
                librarianCounter = 0;
              }
              dialogBox.SetActive(true);
              //set speaker
              if (StaticValues.floor == grandmaFloor)
              {
               uiGrandma.SetActive(true); 
              }
              else
              {
                uiLibrarian.SetActive(true);
              }
              //play sound
              //might consider switch here as well
              if(StaticValues.floor == 12)
              {
                audioSource.volume = 0.20f;
                audioSource.clip = librarianTrain;
              }
              else if(StaticValues.floor == 13)
              {
                audioSource.volume = 1.0f;
                audioSource.clip = pageSound;
              }
              else if(StaticValues.floor == 10)
              {
                audioSource.volume = 0.20f;
                audioSource.clip = librarianBird;
              }
              else if(StaticValues.floor == 14)
              {
                audioSource.volume = 0.20f;
                audioSource.clip = librarianDuck;
              }
              else if(StaticValues.floor == 15)
              {
                audioSource.volume = 0.20f;
                audioSource.clip = librarianElectric;
              }
              else
              {
                if(StaticValues.floor<9)
                {
                  audioSource.volume = 0.13f;
                  audioSource.clip = librarianCough;
                }
                else
                {
                  audioSource.volume = 0.17f;
                  audioSource.clip = librarianStrange;
                }
                
              }
              audioSource.Play();
            }
          }
       }
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
