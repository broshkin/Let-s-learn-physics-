using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject inGameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "VirtuaLab")
        {
            canvas.SetActive(false);
        }
        inGameCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "VirtuaLab")
        {
            if (inGameCanvas.activeSelf == false)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    canvas.SetActive(true);
                    gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
                }
                else
                {
                    canvas.SetActive(false);
                    gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = true;
                }
            }
        }
        if (inGameCanvas.activeSelf == false && Input.GetKeyDown(KeyCode.F))
        {
            inGameCanvas.SetActive(true);
            gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
            Time.timeScale = 0;
        }
        else if (inGameCanvas.activeSelf == true && Input.GetKeyDown(KeyCode.F))
        {
            inGameCanvas.SetActive(false);
            gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = true;
            Time.timeScale = 1;
        }
    }
}
