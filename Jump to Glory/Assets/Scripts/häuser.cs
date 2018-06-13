using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class häuser : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "menu 1" || sceneName == "erste")
        {
            if (this.transform.name == "Häuser_1(Clone)" || this.transform.name == "Häuser_2(Clone)" || this.transform.name == "Häuser_3(Clone)")
            {
                  Destroy(gameObject);
            }
        }
    }
}
