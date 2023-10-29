using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlanetSelect : MonoBehaviour
{
    public GameObject Manager;

    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }
    private void OnMouseDown()
    {
        Manager.GetComponent<SceneChangeManager>().lastPlanet = this.gameObject.name;

       // if(!SceneManager.GetSceneByName(this.gameObject.name).IsValid())
       // {
       //     SceneManager.LoadScene(1);
       //     return;
       // }
        Debug.Log("load level " + this.gameObject.name);
        SceneManager.LoadScene(this.gameObject.name);
    }
}
