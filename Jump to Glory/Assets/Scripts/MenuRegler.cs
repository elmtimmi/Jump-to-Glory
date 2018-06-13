using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuRegler : MonoBehaviour
{
    public bool start;
    public bool optionen;
    public bool errungenschaften;
    public bool charaktere;
    public bool musikAn;
    public bool musikAus;
    public GameObject mainCamera;
    private mainCamera b;
    public GameObject errungenschaft;
    public GameObject charakter;
    public GameObject muAn;
    public GameObject muAus;
    public bool optionenTrue;
    public bool musik;
    public GameObject musikk;
    public bool musikRegler;
    private MenuRegler a;
    public bool hintergrund;
    public bool rekort;
    public Text instruction;
    AudioSource audioSource;
    public GameObject backToMenu;
    public bool rekordPanel;
    public GameObject rekord;

    // Use this for initialization
    void Awake()
    {
        if (hintergrund)
        DontDestroyOnLoad(transform.gameObject);
        if (errungenschaften)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        if (rekort || optionen || errungenschaften || charaktere)
        {
            b = mainCamera.GetComponent<mainCamera>();
        }
        if (rekort)
        {
            instruction = GetComponent<Text>();
        }
        if (musikRegler)
        {
            musik = true;
        }
        if (musikk != null)
        {
            a = musikk.GetComponent<MenuRegler>();
        }
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (optionen)
        {
            if (sceneName != "menu 1" && sceneName != "erste")
            {
                errungenschaft.SetActive(false);
                charakter.SetActive(false);
                muAn.SetActive(false);
                muAus.SetActive(false);
                optionenTrue = false;
                errungenschaft.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                b.hintergrund.transform.position = new Vector3(9.8f, 29.8f, 0);
            }
            if(sceneName == "Shop")
            {
                b.hintergrund.transform.position = new Vector3(100f, 29.8f, 0);
            }
        }
        if (sceneName != "menu 1" && sceneName != "erste" )
        {

        }
        else
        {
            if (gameObject.transform.name == "dubbleJump(Clone)")
            {
                Destroy(gameObject);
            }
        }
        if (rekort)
        {
            this.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.25f - 134.5f, -1);
            if (b.errungenschaftAn == true || sceneName != "menu 1" && sceneName != "erste")
            {
                this.transform.position = new Vector3(100000, 0, -1);
            }
            else
            {
                this.transform.position = new Vector3(Screen.width / 2 + 30, Screen.height / 2 - 95, -1);
            }
            instruction.text = "Rekord: " + b.recort;
        }
        if (rekordPanel)
        {
            if(rekord.transform.position.x < 1000)
            {
                this.GetComponent<Image>().enabled = true;
                this.transform.position = new Vector3(this.transform.position.x, rekord.transform.position.y, -2f);
            }
            else
            {
                this.GetComponent<Image>().enabled = false;
            }
        }
    }
    void OnMouseDown()
    {
        if (start)
        {
            SceneManager.LoadScene(2);
            Time.timeScale = 1.0f;
        }
        if (optionen)
        {
            if (!optionenTrue)
            {
                errungenschaft.SetActive(true);
                charakter.SetActive(true);
                errungenschaft.transform.GetChild(0).gameObject.SetActive(false);
                if (a.musik)
                {
                    muAn.SetActive(true);
                }
                else
                {
                    muAus.SetActive(true);
                }
                optionenTrue = true;
            }
            else
            {
                errungenschaft.transform.GetChild(0).gameObject.SetActive(false);
                errungenschaft.SetActive(false);
                charakter.SetActive(false);
                muAn.SetActive(false);
                muAus.SetActive(false);
                optionenTrue = false;
                b.errungenschaftAn = false;
            }
        }
        if (musikAn)
        {
            audioSource = mainCamera.transform.GetChild(1).GetComponent<AudioSource>();
            AudioListener.volume = 0;
            muAn.SetActive(false);
            muAus.SetActive(true);
            a.musik = false;
        }
        if (musikAus)
        {
            audioSource = mainCamera.transform.GetChild(1).GetComponent<AudioSource>();
            muAn.SetActive(true);
            muAus.SetActive(false);
            a.musik = true;
           AudioListener.volume = 1;
        }
        if (errungenschaften)
        {
            if (b.errungenschaftAn) {
                b.errungenschaftAn = false;
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                b.errungenschaftAn = true;
            }
        }
        if (charaktere)
        {
            b.errungenschaftAn = false;
           SceneManager.LoadScene(3);
           backToMenu.transform.position = new Vector3(Screen.width / 2 - 50, Screen.height / 2, 0);
        }
    }
}
