using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLesson : MonoBehaviour
{
    public GameObject dialogScreen;
    private string[] timelyText;
    private int count;
    public Material spaceSkyBox;
    public Material earthSkyBox;
    public Material marsSkyBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "earthScene")
        {
            if (dialogScreen.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                dialogScreen.GetComponent<EarthDialogSystem>().passTheThirdActionTheJump = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            if (dialogScreen.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                dialogScreen.GetComponent<MoonDialogSystem>().passTheSixthActionTheJump = true;
            }
        }

    }
    
    public string[] GetTimelyLines()
    {
        return timelyText;
    }
    public void StartAction()
    {
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            if (dialogScreen.GetComponent<DialogSystem>().thisNumDialogIsFinished == 1)
            {
                StartFirstLessonFirstAction();
            }

            if (dialogScreen.GetComponent<DialogSystem>().thisNumDialogIsFinished == 2)
            {
                StartFirstLessonSecondAction();
            }
        }

        if (SceneManager.GetActiveScene().name == "earthScene")
        {
            if (dialogScreen.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 1)
            {
                StartFirstLessonThirdAction();
            }

            if (dialogScreen.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 2)
            {
                StartFirstLessonFourthAction();
            }
            
            if (dialogScreen.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 3)
            {
                StartFirstLessonFifthAction();
            }
        }

        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            if (dialogScreen.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 1)
            {
                StartFirstLessonSixthAction();
            }
            if (dialogScreen.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 2)
            {
                StartFirstLessonSeventhAction();
            }
            if (dialogScreen.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 3)
            {
                StartFirstLessonEigthAction();
            }
        }

        if (SceneManager.GetActiveScene().name == "BridgePractice")
        {
            if (dialogScreen.GetComponent<BridgePractice>().bridgePracticeThisNumDialogIsFinished == 1)
            {
                StartFirstLessonNinethAction();
            }
            if (dialogScreen.GetComponent<BridgePractice>().passThePractice)
            {
                StartFirstLessonTenthAction();
            }
            if (dialogScreen.GetComponent<BridgePractice>().dontPassThePractice)
            {
                StartFirstLessonEleventhAction();
            }
        }
    }
    private void StartFirstLessonFirstAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Полетели на Землю!";
        dialogScreen.GetComponent<DialogSystem>().SetLines();
    }
    private void StartFirstLessonSecondAction()
    {
        SceneManager.LoadScene("earthScene");
    }
    private void StartFirstLessonThirdAction()
    { 
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Опробуй силу тяжести - подпрыгни и брось яблоко!";
        dialogScreen.GetComponent<EarthDialogSystem>().SetLines();
    }
    private void StartFirstLessonFourthAction()
    {
        count = 3;
        timelyText = new string[count];
        timelyText[0] = "Отлично! Применив формулу можно высчитать силу, которая действует на яблоко. Яблоко весит 200 грамм или же 0,2 кг, соответственно, на него действует сила равная F = 0,2 * 9,81 = 1,962 ньютона (Н). Земля притягивает тебя к себе с силой F = твоя масса в кг * 9,81, что значительно больше, чем сила действующая на яблоко.";
        timelyText[1] = "Но что будет, если мы с тобой попробуем совершить эти же действия на Луне?";
        timelyText[2] = "Давай попробуем! Полетели на Луну!";
        dialogScreen.GetComponent<EarthDialogSystem>().SetLines();
    }
    private void StartFirstLessonFifthAction()
    {
        SceneManager.LoadScene("MoonScene");
    }
    private void StartFirstLessonSixthAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Опробуй силу тяжести Луны - брось яблоко, а затем просто подпрыгни!";
        dialogScreen.GetComponent<MoonDialogSystem>().SetLines();
    }
    private void StartFirstLessonSeventhAction()
    {
        count = 2;
        timelyText = new string[count];
        timelyText[0] = "Молодец! Как видишь, сила, которая притягивает все тела к Луне, слабее, чем на Земле, это связанно с тем, что масса Луны значительно меньше массы Земли, g Луны составляет 16,6% от g Земли или же g Луны = 9,81 * 0,166 = 1,63 метров на секунду в квадрате.";
        timelyText[1] = "Думаю, ты готов пройти небольшое испытание на тему силы тяжести, удачи!";
        dialogScreen.GetComponent<MoonDialogSystem>().SetLines();
    }
    private void StartFirstLessonEigthAction()
    {
        SceneManager.LoadScene("BridgePractice");
    }
    private void StartFirstLessonNinethAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Принеси и покажи мне, какой арбуз ты взял, если он подходит, я тебя пропущу";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
    private void StartFirstLessonTenthAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Да! Тот самый арбуз! Молодец! Проходи!";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
    private void StartFirstLessonEleventhAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "Hет! Tакой арбуз не подойдёт!";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
}
