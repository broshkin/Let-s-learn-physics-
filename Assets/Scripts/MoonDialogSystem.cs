using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoonDialogSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moonText;
    [SerializeField] string[] moonLines;

    private int index = 0;

    public GameObject player;
    public GameObject canvas;
    public int thisMoonNumDialogIsFinished;
    public bool passTheSixthActionTheJump = false;
    public bool passTheSixthActionTheApple = false;
    void Start()
    {
        moonText.text = moonLines[index];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (moonText.text == moonLines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                moonText.text = moonLines[index];
            }
        }
        if (thisMoonNumDialogIsFinished == 1 && passTheSixthActionTheJump && passTheSixthActionTheApple)
        {
            thisMoonNumDialogIsFinished = 2;
            moonText.text = string.Empty;
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
        if (moonLines[index] != string.Empty)
        {
            moonText.text = moonLines[index];
        }
        else
        {
            IsNextLine();
        }
    }


    void IsNextLine()
    {
        if (index < moonLines.Length - 1)
        {
            index++;
            moonText.text = string.Empty;
            TypeLine();
        }
        else
        {
            gameObject.SetActive(false);
            player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            moonText.text = string.Empty;
            for (int i = 0; i < moonLines.Length; i++)
            {
                moonLines[i] = string.Empty;
            }
            if (thisMoonNumDialogIsFinished != 1)
            {
                thisMoonNumDialogIsFinished += 1;
            }
            canvas.GetComponent<FirstLesson>().StartAction();
        }
    }

    public void SetLines()
    {
        moonLines = new string[canvas.GetComponent<FirstLesson>().GetTimelyLines().Length];
        for (int i = 0; i < canvas.GetComponent<FirstLesson>().GetTimelyLines().Length; i++)
        {
            moonLines[i] = canvas.GetComponent<FirstLesson>().GetTimelyLines()[i];
        }
        moonText.text = moonLines[0];
    }
}
