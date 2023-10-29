using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private string PlanetName;
    public GameObject Manager;
    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("Manager");
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Planet")

        {
            
            PlanetName = coll.gameObject.name;
            if(Manager.GetComponent<SceneChangeManager>().lastPlanet == PlanetName)
            {
                return;
            }
            else 
            {
                //Manager.GetComponent<SceneChangeManager>().lastPlanet = PlanetName;
                //if (!SceneManager.GetSceneByName(PlanetName).IsValid())
                //{
                //    SceneManager.LoadScene(1);
                //    return;
                //}
                Debug.Log("load level " + PlanetName);
                SceneManager.LoadScene(PlanetName);
            }
            

        }

    }
}
