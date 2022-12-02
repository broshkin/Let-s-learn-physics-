using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EarthDialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI earthText;
    [SerializeField] string[] earthLines;

    private int index;
    
    public GameObject player;
    public GameObject canvas;
    public int earthThisNumDialogIsFinished = 0;
    public bool passTheThirdActionTheJump = false;
    public bool passTheThirdActionTheApple = false;
    void Start()
    {  
        earthText.text = earthLines[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (earthText.text == earthLines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                earthText.text = earthLines[index];             
            }
        }

        if (earthThisNumDialogIsFinished == 1 && passTheThirdActionTheJump && passTheThirdActionTheApple)
        {
            earthThisNumDialogIsFinished = 2;
            earthText.text = string.Empty;
            canvas.GetComponent<FirstLesson>().StartAction();
        }
    }

    public void StartDialog()
    {  
        index = 0;
        TypeLine();
    }

    public void TypeLine()
    {
        if (earthLines[index] != string.Empty)
        {
            earthText.text = earthLines[index];
        }
        else
        {
            IsNextLine();
        }
    }


    void IsNextLine()
    {
        if (index < earthLines.Length - 1)
        {
            index++;
            earthText.text = string.Empty;
            TypeLine();
        }
        else
        {
            gameObject.SetActive(false);
            player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            earthText.text = string.Empty;
            for (int i = 0; i < earthLines.Length; i++)
            {
                earthLines[i] = string.Empty;
            }
  
            if (earthThisNumDialogIsFinished != 1)
            {
                earthThisNumDialogIsFinished += 1;
            }
            canvas.GetComponent<FirstLesson>().StartAction();
        }
    }

    public void SetLines()
    {
        for (int i = 0; i < canvas.GetComponent<FirstLesson>().GetTimelyLines().Length; i++)
        {
            earthLines[i] = canvas.GetComponent<FirstLesson>().GetTimelyLines()[i];
        }
        earthText.text = earthLines[0];
    }    
}
