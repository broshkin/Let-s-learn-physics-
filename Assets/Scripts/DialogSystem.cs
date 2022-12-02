using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] lines;
    [SerializeField] float TextSpeed;

    private int index;

    public GameObject player;
    public GameObject canvas;
    public int thisNumDialogIsFinished = 0;
    void Start()
    {  
        text.text = lines[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == lines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];             
            }
        }    
    }

    public void StartDialog()
    {  
        index = 0;
        TypeLine();
    }

    public void TypeLine()
    {
        if (lines[index] != string.Empty)
        {
            text.text = lines[index];
        }
        else
        {
            IsNextLine();
        }
    }


    void IsNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            TypeLine();
        }
        else
        {
            gameObject.SetActive(false);
            player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            text.text = string.Empty;
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = string.Empty;
            }
            thisNumDialogIsFinished += 1;
            canvas.GetComponent<FirstLesson>().StartAction();       
        }
    }

    public void SetLines()
    {
        for (int i = 0; i < canvas.GetComponent<FirstLesson>().GetTimelyLines().Length; i++)
        {
            lines[i] = canvas.GetComponent<FirstLesson>().GetTimelyLines()[i];
        }       
    }    
}