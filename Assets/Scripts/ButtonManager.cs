using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class ButtonManager : MonoBehaviour
{
    public GameObject[] props;
    public GameObject player;
    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Generating()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
            string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
            Instantiate(props[Convert.ToInt32(ClickedButtonName[ClickedButtonName.Length - 1]) - 49], hit.point, transform.rotation);
        }
        else
        {
            string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
            Instantiate(props[Convert.ToInt32(ClickedButtonName[ClickedButtonName.Length - 1]) - 49], player.transform.position + player.transform.forward * 5, transform.rotation);
        }
        
    }

    public void ClearMap()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Prop").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Prop")[i]);
        }
    }
    public void GetMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void SandBoxActive()
    {
        SceneManager.LoadScene("VirtuaLab");
    }
}
