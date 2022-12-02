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
        timelyText[0] = "�������� �� �����!";
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
        timelyText[0] = "������� ���� ������� - ��������� � ����� ������!";
        dialogScreen.GetComponent<EarthDialogSystem>().SetLines();
    }
    private void StartFirstLessonFourthAction()
    {
        count = 3;
        timelyText = new string[count];
        timelyText[0] = "�������! �������� ������� ����� ��������� ����, ������� ��������� �� ������. ������ ����� 200 ����� ��� �� 0,2 ��, ��������������, �� ���� ��������� ���� ������ F = 0,2 * 9,81 = 1,962 ������� (�). ����� ����������� ���� � ���� � ����� F = ���� ����� � �� * 9,81, ��� ����������� ������, ��� ���� ����������� �� ������.";
        timelyText[1] = "�� ��� �����, ���� �� � ����� ��������� ��������� ��� �� �������� �� ����?";
        timelyText[2] = "����� ���������! �������� �� ����!";
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
        timelyText[0] = "������� ���� ������� ���� - ����� ������, � ����� ������ ���������!";
        dialogScreen.GetComponent<MoonDialogSystem>().SetLines();
    }
    private void StartFirstLessonSeventhAction()
    {
        count = 2;
        timelyText = new string[count];
        timelyText[0] = "�������! ��� ������, ����, ������� ����������� ��� ���� � ����, ������, ��� �� �����, ��� �������� � ���, ��� ����� ���� ����������� ������ ����� �����, g ���� ���������� 16,6% �� g ����� ��� �� g ���� = 9,81 * 0,166 = 1,63 ������ �� ������� � ��������.";
        timelyText[1] = "�����, �� ����� ������ ��������� ��������� �� ���� ���� �������, �����!";
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
        timelyText[0] = "������� � ������ ���, ����� ����� �� ����, ���� �� ��������, � ���� �������";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
    private void StartFirstLessonTenthAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "��! ��� ����� �����! �������! �������!";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
    private void StartFirstLessonEleventhAction()
    {
        count = 1;
        timelyText = new string[count];
        timelyText[0] = "H��! T���� ����� �� �������!";
        dialogScreen.GetComponent<BridgePractice>().SetLines();
    }
}
