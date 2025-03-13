using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tutorialPopUp;
    private int tutorialIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < tutorialPopUp.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialPopUp[i].SetActive(true);
            }
            else
            {
                tutorialPopUp[i].SetActive(false);
            }
        }
        
        switch (tutorialIndex) 
        {
            //move pop up 
            case 0:
                if (Input.GetAxis("Horizontal") != 0)
                {
                    tutorialIndex++;
                }
                break;

            //jump pop up
            case 1:
                if (Input.GetButton("Jump"))
                {
                tutorialIndex++;
                } 
                break;

            //attack pop up
            case 2:
                if (Input.GetButton("Fire1"))
                {
                    tutorialIndex++;
                }
                break;

             //swap mode    
            case 3:
                if (Input.GetButton("Fire2"))
                {
                    tutorialIndex++;
                }
                break;
        }
    }
   }
    

