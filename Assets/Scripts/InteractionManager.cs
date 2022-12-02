using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public GameObject sprite1;
    public GameObject robot;
    public GameObject player;
    public GameObject dialogSystem;
    public OnEye CurrentSelectable;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = true;
        if (SceneManager.GetActiveScene().name != "VirtuaLab")
        {
            sprite1.SetActive(false);
            dialogSystem.SetActive(false);
        } 
        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            Physics.gravity *= 0.166f;
        }
        if (SceneManager.GetActiveScene().name != "MoonScene")
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && SceneManager.GetActiveScene().name == "VirtuaLab")
        {
            if (GameObject.FindGameObjectsWithTag("Prop").Length > 0)
            {
                Destroy(GameObject.FindGameObjectsWithTag("Prop")[GameObject.FindGameObjectsWithTag("Prop").Length - 1]);
            }
        }
        if (SceneManager.GetActiveScene().name == "BridgePractice")
        {
            if (CurrentSelectable)
            {
                if (CurrentSelectable.name.Split(' ')[1] == "Correct" && dialogSystem.activeSelf)
                {
                    dialogSystem.GetComponent<BridgePractice>().passThePractice = true;
                }
                else if (CurrentSelectable.name.Split(' ')[1] != "Correct" && dialogSystem.activeSelf)
                {
                    dialogSystem.GetComponent<BridgePractice>().dontPassThePractice = true;
                }
                else
                {
                    dialogSystem.GetComponent<BridgePractice>().dontPassThePractice = false;
                    dialogSystem.GetComponent<BridgePractice>().passThePractice = false;
                }
            }
            else
            {
                dialogSystem.GetComponent<BridgePractice>().dontPassThePractice = false;
                dialogSystem.GetComponent<BridgePractice>().passThePractice = false;
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        { 
            if (SceneManager.GetActiveScene().name != "BridgePractice")
            {
                if (hit.distance <= 5 && hit.collider.gameObject.name == "Robot" && player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled)
                {
                    robot.transform.rotation = new Quaternion(-player.transform.rotation.x, -player.transform.rotation.y, -player.transform.rotation.z, -player.transform.rotation.w);
                    sprite1.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        sprite1.SetActive(false);
                        player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                        dialogSystem.SetActive(true);
                        if (SceneManager.GetActiveScene().name == "Hub")
                        {
                            dialogSystem.GetComponent<DialogSystem>().StartDialog();
                        }
                        if (SceneManager.GetActiveScene().name == "earthScene")
                        {
                            dialogSystem.GetComponent<EarthDialogSystem>().StartDialog();
                        }

                    }
                }
                else
                {
                    if (SceneManager.GetActiveScene().name != "VirtuaLab")
                    {
                        sprite1.SetActive(false);
                    }
                }
            }
            else
            {
                if (hit.distance <= 5 && hit.collider.gameObject.tag == "Bot" && player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled)
                {
                    sprite1.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        sprite1.SetActive(false);
                        player.GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                        dialogSystem.SetActive(true);
                        if (SceneManager.GetActiveScene().name == "Hub")
                        {
                            dialogSystem.GetComponent<DialogSystem>().StartDialog();
                        }
                        if (SceneManager.GetActiveScene().name == "earthScene")
                        {
                            dialogSystem.GetComponent<EarthDialogSystem>().StartDialog();
                        }

                    }
                }
                else
                {
                    if (SceneManager.GetActiveScene().name != "VirtuaLab")
                    {
                        sprite1.SetActive(false);
                    }
                }
            }
            
        }
        else
        {
            if (SceneManager.GetActiveScene().name != "VirtuaLab")
            {
                sprite1.SetActive(false);
            }              
        }

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Prop")
        {
            OnEye selectable = hit.collider.gameObject.GetComponent<OnEye>();
            if (hit.distance <= 5 && selectable)
            {
                if (CurrentSelectable && CurrentSelectable != selectable && Input.GetKeyDown(KeyCode.R))
                {
                    CurrentSelectable.Deselect();
                }
                if (CurrentSelectable && CurrentSelectable != selectable && Input.GetMouseButton(0))
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    CurrentSelectable.GetComponent<Rigidbody>().AddForce(ray.direction * 2, ForceMode.Impulse);
                    CurrentSelectable = null;
                    if (SceneManager.GetActiveScene().name == "earthScene")
                    {
                        if (dialogSystem.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 1)
                        {
                            dialogSystem.GetComponent<EarthDialogSystem>().passTheThirdActionTheApple = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "MoonScene")
                    {
                        if (dialogSystem.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 1)
                        {
                            dialogSystem.GetComponent<MoonDialogSystem>().passTheSixthActionTheApple = true;
                        }
                    }
                }
            
                if (Input.GetKeyDown(KeyCode.R))
                {
                    CurrentSelectable = selectable;
                    selectable.Select();
                    CurrentSelectable.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
                } 
            }
            else
            {
                if (CurrentSelectable && Input.GetKeyDown(KeyCode.R))
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
                if (CurrentSelectable && Input.GetMouseButton(0))
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    CurrentSelectable.GetComponent<Rigidbody>().AddForce(ray.direction * 2, ForceMode.Impulse);
                    CurrentSelectable = null;
                    if (SceneManager.GetActiveScene().name == "earthScene")
                    {
                        if (dialogSystem.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 1)
                        {
                            dialogSystem.GetComponent<EarthDialogSystem>().passTheThirdActionTheApple = true;
                        }
                    }
                    if (SceneManager.GetActiveScene().name == "MoonScene")
                    {
                        if (dialogSystem.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 1)
                        {
                            dialogSystem.GetComponent<MoonDialogSystem>().passTheSixthActionTheApple = true;
                        }
                    }
                }
            }
        }
        else
        {
            if (CurrentSelectable && Input.GetKeyDown(KeyCode.R))
            {
                CurrentSelectable.Deselect();
                CurrentSelectable = null;
            }
            if (CurrentSelectable && Input.GetMouseButton(0))
            {
                CurrentSelectable.Deselect();
                CurrentSelectable.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                CurrentSelectable.GetComponent<Rigidbody>().AddForce(ray.direction * 2, ForceMode.Impulse);
                CurrentSelectable = null;
                if (SceneManager.GetActiveScene().name == "earthScene")
                {
                    if (dialogSystem.GetComponent<EarthDialogSystem>().earthThisNumDialogIsFinished == 1)
                    {
                        dialogSystem.GetComponent<EarthDialogSystem>().passTheThirdActionTheApple = true;
                    }
                }
                if (SceneManager.GetActiveScene().name == "MoonScene")
                {
                    if (dialogSystem.GetComponent<MoonDialogSystem>().thisMoonNumDialogIsFinished == 1)
                    {
                        dialogSystem.GetComponent<MoonDialogSystem>().passTheSixthActionTheApple = true;
                    }
                }
            }
        }

    }
}
