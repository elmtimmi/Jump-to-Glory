using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class aufträge : MonoBehaviour {
    public GameObject ErrungenSchaften;
    public GameObject mainCamera;
    private mainCamera a;
    public Text instruction;
    public Text text;
    public bool panel;
    public bool aufträgeText;
    public bool aufgaben;
    public bool aufgabe1;
    public bool aufgabe2;
    public bool aufgabe3;
    public bool aufgabe4;
    public bool aufgabe5;
    public string meineAufgabe;
    public bool missionGeschaft;
    public int getMoney;
    public int Ziel;
    public int einmal;
    public int zweimal;
    // Use this for initialization
    void Start () {
        a = mainCamera.GetComponent<mainCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (panel)
        {
            this.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.25f - 100, -1);
            if (a.errungenschaftAn == true && ErrungenSchaften.activeSelf == true || sceneName != "menu 1" && sceneName != "erste")
            {
                this.transform.position = new Vector3(100000, 0, -1);
            }
        }
        if (aufträgeText)
        {
            instruction = this.GetComponent<Text>();
            instruction.text = "Aufgaben geschafft: " + PlayerPrefs.GetInt("AufgabenGeschafft");
            if (a.errungenschaftAn == true && ErrungenSchaften.activeSelf == true || sceneName != "menu 1" && sceneName != "erste")
            {
                this.transform.position = new Vector3(100000, 0, -1);
            }
            else
            {
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.5f - Screen.height / 9, -1);
            }
        }
        if (aufgaben)
        {
            instruction = this.gameObject.transform.GetChild(0).GetComponent<Text>();
            text = this.gameObject.transform.GetChild(2).GetComponent<Text>();
            if (aufgabe1)
            {
                meineAufgabe = "aufgabe1";
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.4f - Screen.height / 15, -1);
            }
            if (aufgabe2)
            {
                meineAufgabe = "aufgabe2";
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.4f - 2 * Screen.height / 15, -1);
            }
            if (aufgabe3)
            {
                meineAufgabe = "aufgabe3";
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.4f - 3 * Screen.height / 15, -1);
            }
            if (aufgabe4)
            {
                meineAufgabe = "aufgabe4";
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.4f - 4 * Screen.height / 15, -1);
            }
            if (aufgabe5)
            {
                meineAufgabe = "aufgabe5";
                this.transform.position = new Vector3(Screen.width / 2 - 100, Screen.height * 0.4f - 5 * Screen.height / 15, -1);
            }
            if (PlayerPrefs.GetInt(meineAufgabe) == 0)
            {
                PlayerPrefs.SetInt(meineAufgabe + " ", Random.Range(1, 12));
                if (PlayerPrefs.GetInt("Flo") == 1)
                {
                    PlayerPrefs.SetInt(meineAufgabe + " ", Random.Range(1, 13));
                }
                if (a.besetzt[PlayerPrefs.GetInt(meineAufgabe + " ")] == 1)
                {
                    PlayerPrefs.SetInt(meineAufgabe, 0);
                }
                else
                {
                    a.besetzt[PlayerPrefs.GetInt(meineAufgabe + " ")] = 1;
                    PlayerPrefs.SetInt(meineAufgabe, 1);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt(meineAufgabe + " ") != -1)
                {
                    a.besetzt[PlayerPrefs.GetInt(meineAufgabe + " ")] = 1;
                }
                PlayerPrefs.SetInt("besetzt" + meineAufgabe + " ", 1);

                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 1)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 2) * 250;
                    if (Ziel == 0)
                    {
                        Ziel = 500;
                    }
                    instruction.text = "Erreiche einen Rekord von " + Ziel;
                        if (PlayerPrefs.GetFloat("bestScore") <= a.recort)
                        {
                            text.text = a.recort + "/" + Ziel;
                            PlayerPrefs.SetFloat("bestScore", a.recort);
                        }
                        if (a.recort >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 2)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1) * 25;
                    if (Ziel == 0)
                    {
                        Ziel = 25;
                    }
                    instruction.text = "Springe durchgehend bis " + Ziel;
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("bestSprung") + "/" + Ziel;
                        if (PlayerPrefs.GetFloat("bestSprung") <= a.springeDurchgehend)
                        {
                            PlayerPrefs.SetFloat("bestSprung", a.springeDurchgehend);
                        }
                        if (PlayerPrefs.GetFloat("bestSprung") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 3)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1) * 2 + 1;
                    if (Ziel == 0)
                    {
                        Ziel = 3;
                    }
                    instruction.text = "Setze in einer Runde " + Ziel + " Doublejumps ein";
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("bestDoupleJumpsEingesetz") + "/" + Ziel;
                        if (PlayerPrefs.GetFloat("bestDoupleJumpsEingesetz") <= a.doupleJumpsEingesetz)
                        {
                            PlayerPrefs.SetFloat("bestDoupleJumpsEingesetz", a.doupleJumpsEingesetz);
                        }
                        if (PlayerPrefs.GetFloat("bestDoupleJumpsEingesetz") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 4)
                {
                    if (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) != 0)
                    {
                        Ziel = 10 - PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) * 2;
                    }
                    if (Ziel == 0)
                    {
                        Ziel = 10;
                    }
                    instruction.text = "Sterbe bei einem Score von 100 +- " + Ziel;
                    if (Ziel < 0)
                    {
                        instruction.text = "Sterbe bei einem Score von 100";
                    }
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        if (sceneName == "menu 1")
                        {
                            if (a.score < 100 + Ziel && a.score > 100 - Ziel)
                            {
                                PlayerPrefs.SetFloat("richtigerScore", a.score);
                                Debug.Log("richtiger Score");
                            }
                        }
                        if (PlayerPrefs.GetFloat("richtigerScore") == 0)
                        {
                            text.text = a.score + "/100 +-" + Ziel;
                            if (Ziel < 0)
                            {
                                text.text = a.score + "/100";
                            }
                        }
                        if (PlayerPrefs.GetFloat("richtigerScore") <= 100 + Ziel && PlayerPrefs.GetFloat("richtigerScore") >= 100 - Ziel)
                        {
                            missionGeschaft = true;
                            text.text = PlayerPrefs.GetFloat("richtigerScore") + "/" + PlayerPrefs.GetFloat("richtigerScore");
                        }
                    }
                    else
                    {
                        text.text = 0 + "/100 +-" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 5)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 3) * 100;
                    if (Ziel == 0)
                    {
                        Ziel = 300;
                    }
                    instruction.text = "Komme bis " + Ziel + "  ohne Doublejumps einzusetzen";
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("bestDoupleJumpsNichtEingesetz") + "/" + Ziel;
                            if (a.score > PlayerPrefs.GetFloat("bestDoupleJumpsNichtEingesetz") && a.doupleJumpsEingesetz == 0 && sceneName == "level")
                            {
                                PlayerPrefs.SetFloat("bestDoupleJumpsNichtEingesetz", a.score);
                            }
                            if (PlayerPrefs.GetFloat("bestDoupleJumpsNichtEingesetz") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 6)
                {
                    instruction.text = "Breche deinen eigenen Rekord";
                        if (PlayerPrefs.GetFloat("alterRekort") == 0)
                        {
                            PlayerPrefs.SetFloat("alterRekort", a.recort);
                        }
                        if (a.recort <= PlayerPrefs.GetFloat("alterRekort"))
                        {
                            text.text = a.score + "/" + PlayerPrefs.GetFloat("alterRekort");
                        }
                        if (a.recort > PlayerPrefs.GetFloat("alterRekort"))
                        {
                            text.text = a.recort + "/" + PlayerPrefs.GetFloat("alterRekort");
                            missionGeschaft = true;
                        }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 7)
                {
                    Ziel = PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 2;
                    if (Ziel == 0)
                    {
                        Ziel = 2;
                    }
                    if (Ziel > 7)
                    {
                        Ziel = 7;
                    }
                    instruction.text = "Schalte " + Ziel + " Charakter(e) frei";
                    int zahl = 0;
                    if (PlayerPrefs.GetInt("Jani") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Timi") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Luki") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Fini") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Matze") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Flo") == 1)
                    {
                        zahl++;
                    }
                    if (PlayerPrefs.GetInt("Liva") == 1)
                    {
                        zahl++;
                    }
                    text.text = zahl + "/" + Ziel;
                    if (zahl >= Ziel)
                    {
                        missionGeschaft = true;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 8)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1) * 100;
                    if (Ziel == 0)
                    {
                        Ziel = 100;
                    }
                    instruction.text = "Score min. " + Ziel + " ohne Doublejumps einzusammeln";
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        if (PlayerPrefs.GetFloat("rekortOhneDoublejump") < a.score && a.doubleJumpEingesammelt == false && sceneName == "level")
                        {
                            PlayerPrefs.SetFloat("rekortOhneDoublejump", a.score);
                        }
                        text.text = PlayerPrefs.GetFloat("rekortOhneDoublejump") + "/" + Ziel;
                        if (PlayerPrefs.GetFloat("rekortOhneDoublejump") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 9)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1) * 5;
                    if (Ziel == 0)
                    {
                        Ziel = 5;
                    }
                    instruction.text = "Score min. " + Ziel + " ohne auf den Boden aufzukommen";
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("rekortOhneBoden") + "/" + Ziel;
                        if (a.score > PlayerPrefs.GetFloat("rekortOhneBoden") && !a.bodenBerührt)
                        {
                            PlayerPrefs.SetFloat("rekortOhneBoden", a.score);
                        }
                        if (PlayerPrefs.GetFloat("rekortOhneBoden") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 10)
                {
                    Ziel = (PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1) * 2;
                    if (Ziel == 0)
                    {
                        Ziel = 3;
                    }
                    instruction.text = "Besitze in einer Runde " + Ziel + " Doublejumps";
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("rekortDoublejumps") + "/" + Ziel;
                        if (a.duppleJump > PlayerPrefs.GetFloat("rekortDoublejumps"))
                        {
                            PlayerPrefs.SetFloat("rekortDoublejumps", a.duppleJump);
                        }
                        if (PlayerPrefs.GetFloat("rekortDoublejumps") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 11)
                {
                    Ziel = PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) * 5;
                    if (Ziel == 0)
                    {
                        Ziel = 1;
                    }
                    instruction.text = "Besitze " + Ziel + ".000 Geld";
                    text.text = a.money + "/" + Ziel + ".000";
                    if (a.money >= Ziel * 1000)
                    {
                        missionGeschaft = true;
                    }
                }
                if (PlayerPrefs.GetInt(meineAufgabe + " ") == 12)
                {
                    Ziel = PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) * 200;
                    if (Ziel == 0)
                    {
                        Ziel = 100;
                    }
                    instruction.text = "Score mit Flo min. " + Ziel;
                    if (PlayerPrefs.GetInt("ErstesMalFalsch" + meineAufgabe) == 1)
                    {
                        text.text = PlayerPrefs.GetFloat("rekortMitFlo") + "/" + Ziel;
                        if (a.spieler.gameObject.name == "Flo" && sceneName == "level")
                        {
                            if (zweimal > 5)
                            {
                                if (a.score > PlayerPrefs.GetFloat("rekortMitFlo"))
                                {
                                    PlayerPrefs.SetFloat("rekortMitFlo", a.score);
                                }
                            }
                            else
                            {
                                zweimal++;
                            }
                        }
                        else
                        {
                            zweimal = 0;
                        }
                        if (PlayerPrefs.GetFloat("rekortMitFlo") >= Ziel)
                        {
                            missionGeschaft = true;
                        }
                    }
                    else
                    {
                        text.text = 0 + "/" + Ziel;
                    }
                }
            }
        }
        if (a.errungenschaftAn == true && ErrungenSchaften.activeSelf == true || sceneName != "menu 1" && sceneName != "erste")
        {
            this.transform.position = new Vector3(100000, 0, -1);
        }
        if (sceneName == "level")
        {
            if (einmal > 5)
            {
                PlayerPrefs.SetInt("ErstesMalFalsch" + meineAufgabe, 1);
                einmal = 0;
            }
            else
            {
                einmal++;
            }
        }
        if (PlayerPrefs.GetInt("BelohnungAbgeholt" + meineAufgabe) == 1)
        {
            text.text = "";
            instruction.text = "Belohnung: " + PlayerPrefs.GetInt("Belohnung" + meineAufgabe);
        }
    }
    public void missionAbgeschlossen()
    {
        if (PlayerPrefs.GetInt("Belohnung" + meineAufgabe) != 0)
        {
            Debug.Log("Belohung: " + PlayerPrefs.GetInt("Belohnung" + meineAufgabe));
            a.money += PlayerPrefs.GetInt("Belohnung" + meineAufgabe);
            PlayerPrefs.SetFloat("money", a.money);
            PlayerPrefs.SetInt(meineAufgabe, 0);
            PlayerPrefs.SetInt("Belohnung" + meineAufgabe, 0);
            missionGeschaft = false;
            PlayerPrefs.SetInt("BelohnungAbgeholt" + meineAufgabe, 0);
        }
        if (missionGeschaft)
        {
            if (PlayerPrefs.GetInt("Belohnung" + meineAufgabe) == 0){
                PlayerPrefs.SetInt("Belohnung" + meineAufgabe, Random.Range(500, 1000));
            }
            PlayerPrefs.SetInt("BelohnungAbgeholt" + meineAufgabe, 1);
            text.text = "";
            instruction.text = "Belohung: " + PlayerPrefs.GetInt("Belohnung" + meineAufgabe);
            PlayerPrefs.SetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " "), PlayerPrefs.GetInt("Mission" + PlayerPrefs.GetInt(meineAufgabe + " ")) + 1);
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 2)
            {
                PlayerPrefs.SetFloat("bestSprung", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 3)
            {
                PlayerPrefs.SetFloat("bestDoupleJumpsEingesetz", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 4)
            {
                PlayerPrefs.SetFloat("richtigerScore", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 5)
            {
                PlayerPrefs.SetFloat("bestDoupleJumpsNichtEingesetz", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 6)
            {
                PlayerPrefs.SetFloat("alterRekort", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 8)
            {
                PlayerPrefs.SetFloat("rekortOhneDoublejump", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 9)
            {
                PlayerPrefs.SetFloat("rekortOhneBoden", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 10)
            {
                PlayerPrefs.SetFloat("rekortDoublejumps", 0);
            }
            if (PlayerPrefs.GetInt(meineAufgabe + " ") == 12)
            {
                PlayerPrefs.SetFloat("rekortMitFlo", 0);
            }
            PlayerPrefs.SetInt("ErstesMalFalsch" + meineAufgabe, 0);
            PlayerPrefs.SetInt("AufgabenGeschafft", PlayerPrefs.GetInt("AufgabenGeschafft") + 1);
            a.besetzt[PlayerPrefs.GetInt(meineAufgabe + " ")] = 0;
            PlayerPrefs.SetInt(meineAufgabe + " ", -1);
            missionGeschaft = false;
        }
    }
}
