using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public string lastPlanet;
    public GameObject spawnPlanet;
    public GameObject Player;
    public static SceneChangeManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


    }
    private void OnLevelWasLoaded(int level)
    {

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            bool done = false;
            while (done == false)
            {
                if (Player != null && spawnPlanet != null)
                {
                    Player.transform.position = spawnPlanet.transform.position + new Vector3(0, (spawnPlanet.transform.localScale.y / 2) + 2, 0);
                    Time.timeScale = 0f;
                    done = true;
                }
            }

        }
    }
}