using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class häuserkette : MonoBehaviour {
    public Rigidbody rb;
    public GameObject mainCamera;
    private mainCamera a;
    public GameObject spieler;
    private personControler b;
    int einmal;
    int zweimal;
    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start () {
        rb = GetComponent<Rigidbody>();
        a = mainCamera.GetComponent<mainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.spieler != null)
        {
            if (spieler != a.spieler)
            {
                spieler = a.spieler;
                b = spieler.GetComponent<personControler>();
            }
            if (!spieler.GetComponent<personControler>().die) {
                rb.velocity = new Vector3(spieler.GetComponent<Rigidbody>().velocity.x * 0.6f, 0, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "menu 1")
            {
                if (this.transform.name == "Häuserkette(Clone)")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Jani")
        {
            if (einmal == 0)
            {
                Debug.Log(einmal);
                b.neuerHintergrund = true;
                einmal = 1;
            }
        }
           
    }
}
