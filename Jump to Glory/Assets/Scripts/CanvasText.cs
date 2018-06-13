using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasText : MonoBehaviour {
    public GameObject spieler;
    private personControler b;
    public GameObject mainCamera;
    private mainCamera a;
    public bool score;
    public Text instruction;
    public bool money;
    public bool pause;
    public bool menu;
    public bool pausee;
    public bool scrollView1;
    public bool scrollView2;
    public bool lastScore;
    public bool doupleJump;
    public bool münze;
    public bool tagesBelohungButton;
    public bool tagesBelohung;
    public bool intro;
    public bool sonderCharakter;
    public bool sonderCharakterPanel;
    public bool hintergrundPanel;
    public GameObject PauseHintergrund;
    // Use this for initialization
    void Start () {
        a = mainCamera.GetComponent<mainCamera>();
        if (score || money || lastScore || doupleJump || sonderCharakter ||münze)
        {
            instruction = GetComponent<Text>();
            this.GetComponent<Text>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sonderCharakter)
        {
            instruction.enabled = true;
            this.transform.position = new Vector3(Screen.width / 2 - this.transform.localScale.x/2, Screen.height * 0.4f, -1);
            if (PlayerPrefs.GetInt("AufgabenGeschafft") < 30)
            {
                instruction.text = "Schalte mit Aufgaben Sonder-Charakter\n frei:  " + PlayerPrefs.GetInt("AufgabenGeschafft") + "/30"+ " Missionen";
            }
            if (PlayerPrefs.GetInt("AufgabenGeschafft") < 40 && PlayerPrefs.GetInt("AufgabenGeschafft") >= 30)
            {
                 instruction.text = "Flo freigeschaltet. Nächster Charakter: " + PlayerPrefs.GetInt("AufgabenGeschafft") + "/40" + " Missionen";
                if (PlayerPrefs.GetInt("Flo") == 0)
                {
                    SceneManager.LoadScene(1);
                    a.errungenschaftAn = true;
                    PlayerPrefs.SetInt("Flo", 1);
                }
            }
            if (PlayerPrefs.GetInt("AufgabenGeschafft") >= 40)
            {
                instruction.text = "Sehr gut du Suchti! Beide Charaktere\nFreigeschaltet!";
                if (PlayerPrefs.GetInt("Liva") == 0)
                {
                    SceneManager.LoadScene(1);
                    a.errungenschaftAn = true;
                    PlayerPrefs.SetInt("Liva", 1);
                }
            }
        }
        if (sonderCharakterPanel)
        {
            this.transform.position = new Vector3(Screen.width / 2 - this.transform.localScale.x / 2, Screen.height * 0.225f, -1);
        }
        if (a.spieler != null)
        {
            if (spieler != a.spieler)
            {
                spieler = a.spieler;
                b = spieler.GetComponent<personControler>();
            }
        }
        if (intro)
        {
            if (sceneName == "Shop")
            {
                this.transform.position = new Vector3(Screen.width / 2, 100, -1);
            }
            else
            {
                this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
            }
        }
        if (menu)
        {
            if (sceneName == "menu 1")
            {
                //  this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
                 pausee = false;
            }
            if (sceneName == "Shop")
            {
                this.transform.position = new Vector3(Screen.width / 2, Screen.height - 400, -1);
            }
            else if (pausee)
            {
                this.transform.position = PauseHintergrund.transform.position;
            }
            else
            {
                this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
            }
        }
            if (scrollView1 || scrollView2)
            {
                if (sceneName == "Shop")
                {
                if (scrollView1)
                {
                    this.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.60f, 0);
                }
                if (scrollView2)
                {
                    this.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.25f, 0);
                }
            }
                else
                {
                    this.transform.position = new Vector3(10000, 0, 0);
                }
            }
        if (score || money || lastScore || doupleJump || tagesBelohungButton ||münze)
        {
            if (!tagesBelohungButton)
            {
                if (sceneName == "level")
                {
                    if (score || doupleJump || münze)
                    {
                        this.GetComponent<Text>().enabled = true;
                        if (doupleJump || münze)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        }
                    }
                    else
                    {
                        this.GetComponent<Text>().enabled = false;
                    }
                }
                else
                {
                    this.GetComponent<Text>().enabled = false;
                    if (money)
                    {
                        this.GetComponent<Text>().enabled = true;
                    }
                    if (doupleJump || münze)
                    {
                        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    }
                }
            }
            if (tagesBelohungButton)
            {
                this.transform.position = new Vector3(100000, Screen.height / 2, 0);
                if (a.tagesBelohnung && sceneName == "menu 1" && !a.errungenschaftAn || a.tagesBelohnung && sceneName == "erste" && !a.errungenschaftAn)
                {
                    this.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.6f, 0);
                }
            }
        }
            if (lastScore)
            {
                if (sceneName == "menu 1")
                {
                    this.GetComponent<Text>().enabled = true;
                        instruction.text = "Last Result: " + a.score;
                    this.transform.position = new Vector3(Screen.width / 2 + 30, Screen.height / 2 + 20, -2);
                }
                else
                {
                    this.GetComponent<Text>().enabled = false;
                }
            }

                if (score)
                {
                    this.transform.position = new Vector3(Screen.width / 2, Screen.height - 100, -1);
                    instruction.text = "" + a.score;
                }
                if (money)
                {
                    this.transform.position = new Vector3(Screen.width / 2, Screen.height - 100, 0);
                    instruction.text = "Money: " + a.money;
                }
            if (doupleJump)
            {
                this.transform.position = new Vector3(Screen.width * 0.5f , Screen.height - 300, 0);
                instruction.text = "" + a.duppleJump;
            }
        if (münze)
        {
            this.transform.position = new Vector3(Screen.width * 0.5f , Screen.height - 450, 0);
            instruction.text = "" + a.münzen;
        }
        if (pause)
        {
            if (sceneName == "level")
            {
                this.transform.position = new Vector3(Screen.width - 100, Screen.height - 100, 0);
            }
            else
            {
                this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
            }
        }
        if (hintergrundPanel)
        {
            if(sceneName == "menu 1" || sceneName == "erste")
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void menü(bool shop)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (shop)
        {
            this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
            pausee = false;
        }
        else
        {
            if (!pausee)
            {
                pausee = true;
            }
            else
            {
                pausee = false;
            }
        }
    }
    public void tagesBelohneung()
    {
        tagesBelohung = false;
        PlayerPrefs.SetInt("date", System.DateTime.Now.Day);
    }
}
