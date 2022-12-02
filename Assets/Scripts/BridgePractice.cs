using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BridgePractice : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bridgePracticeText;
    [SerializeField] List<string> bridgePracticeLines;

    private int index = 0;

    public GameObject player;
    public GameObject canvas;
    public int bridgePracticeThisNumDialogIsFinished = 0;
    public bool passThePractice = false;
    public bool dontPassThePractice = false;
    public Animator keeperAnimator;
    public GameObject blocker;
    void Start()
    {
        bridgePracticeText.text = bridgePracticeLines[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (passThePractice)
        {
            keeperAnimator.SetBool("FinishLevel", true);
            Destroy(blocker);
            canvas.GetComponent<FirstLesson>().StartAction();
            passThePractice = false;
        }
        else
        {
            keeperAnimator.SetBool("FinishLevel", false);
        }
        if (dontPassThePractice)
        {
            keeperAnimator.SetBool("FailLevel", true);
            canvas.GetComponent<FirstLesson>().StartAction();
            dontPassThePractice = false;
        }
        else
        {
            keeperAnimator.SetBool("FailLevel", false);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            if (bridgePracticeText.text == bridgePracticeLines[index])
            {
                IsNextLine();
            }
            else
            {
                StopAllCoroutines();
                bridgePracticeText.text = bridgePracticeLines[index];
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
        if (bridgePracticeLines[index] != string.Empty)
        {
            bridgePracticeText.text = bridgePracticeLines[index];
        }
        else
        {
            IsNextLine();
        }
    }


    void IsNextLine()
    {
        if (index < bridgePracticeLines.Count - 1)
        {
            index++;
            bridgePracticeText.text = string.Empty;
            TypeLine();
        }
        else
        {
            gameObject.SetActive(false);
            player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            bridgePracticeText.text = string.Empty;
            bridgePracticeLines.Clear();
            if (bridgePracticeThisNumDialogIsFinished != 1)
            {
                bridgePracticeThisNumDialogIsFinished += 1;
            }
            canvas.GetComponent<FirstLesson>().StartAction();
            index = 0;
        }
    }

    public void SetLines()
    {
        bridgePracticeLines = new List<string>(canvas.GetComponent<FirstLesson>().GetTimelyLines().Length);
        for (int i = 0; i < canvas.GetComponent<FirstLesson>().GetTimelyLines().Length; i++)
        {
            bridgePracticeLines.Add(canvas.GetComponent<FirstLesson>().GetTimelyLines()[i]);
        }
        bridgePracticeText.text = bridgePracticeLines[0];
    }
    
}
