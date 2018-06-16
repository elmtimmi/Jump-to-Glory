using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharakterButton : MonoBehaviour {
    public GameObject mainCamera;
    private mainCamera a;
    public bool jani;
    public bool timi;
    public bool luki;
    public bool fini;
    public bool matze;
    public bool flo;
    public bool liva;
    Image myImageComponent;
    public Sprite Jani;
    public Sprite Timi;
    public Sprite Luki;
    public Sprite Fini;
    public Sprite Matze;
    public Sprite Flo;
    public Sprite Liva;
    public Sprite anonym; //Drag your second sprite here in inspector.
    public bool introTim;
    public int introStep;
    public Text instruction;
    public int x;
    public string chara = "";
    public GameObject menu;
    int einmal;
    public bool doublejump;
    public bool münzenDublikator;
    public bool schafStopp;


    void Start() //Lets start by getting a reference to our image component.
    {
        if (!doublejump && !münzenDublikator && !schafStopp)
        {
            myImageComponent = GetComponent<Image>();
        }
        else
        {
            instruction = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        }
        a = mainCamera.GetComponent<mainCamera>();
    }
    void Update()
    {
        a.Pause.SetActive(true);
        if (jani)
        {
            if (PlayerPrefs.GetInt("Jani") == 1)
            {
                myImageComponent.sprite = Jani;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Timi)
        {
            if (PlayerPrefs.GetInt("Timi") == 1)
            {
                myImageComponent.sprite = Timi;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Luki)
        {
            if (PlayerPrefs.GetInt("Luki") == 1)
            {
                myImageComponent.sprite = Luki;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Fini)
        {
            if (PlayerPrefs.GetInt("Fini") == 1)
            {
                myImageComponent.sprite = Fini;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Matze)
        {
            if (PlayerPrefs.GetInt("Matze") == 1)
            {
                myImageComponent.sprite = Matze;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Flo)
        {
            this.transform.position = new Vector3(Screen.width / 2 - this.transform.localScale.x / 2, Screen.height * 0.3f, -1);
            if (PlayerPrefs.GetInt("Flo") == 1)
            {
                myImageComponent.sprite = Flo;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Mr. Flo";
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (Liva)
        {
            this.transform.position = new Vector3(Screen.width / 2 - this.transform.localScale.x / 2, Screen.height * 0.15f, -1);
            if (PlayerPrefs.GetInt("Liva") == 1)
            {
                myImageComponent.sprite = Liva;
                this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                this.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Dr. Liva";
            }
            else
            {
                myImageComponent.sprite = anonym;
            }
        }
        if (introTim)
        {
            if (a.playIntro)
            {
                if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                {
                    if (introStep < 6)
                    {
                        introStep++;
                    }
                    if (introStep > 6)
                    {
                        introStep++;
                    }
                }
               // a.Pause.SetActive(false);
                Scene currentScene = SceneManager.GetActiveScene();
                string sceneName = currentScene.name;
                if(sceneName == "Shop")
                {
                    menu.gameObject.SetActive(false);
                }
                else
                {
                    menu.gameObject.SetActive(true);
                }
                x = 1;
                this.transform.position = new Vector3(0, Screen.height * 0.75f , 0);
                instruction = this.gameObject.transform.GetChild(1).GetComponent<Text>();
                if (introStep == x)
                {
                    instruction.text = "Willkommen zu\n Jump to Glory!";
                }
                x++;
                if (introStep == x)
                {
                    instruction.text = "Zuerst lose ich\n dir ein Anfangscharakter aus.";
                }
                x++;
                int i = 0;
                if (introStep == x)
                {
                    instruction.text = "Hmmmmmmmm";
                }
                x++;
                if (introStep == x)
                {
                    if (chara == "")
                    {
                        i = Random.Range(1, 6);
                    }
                    if (PlayerPrefs.GetInt("AnfangsSpieler") != 0)
                    {
                        i = PlayerPrefs.GetInt("AnfangsSpieler");
                    }
                    PlayerPrefs.SetInt("spieler", i);
                    PlayerPrefs.SetInt("AnfangsSpieler", i);
                    if (i == 1)
                    {
                        chara = "Jani";
                        PlayerPrefs.SetInt("Jani", 1);
                    }
                    if (i == 2)
                    {
                        chara = "Timi";
                        PlayerPrefs.SetInt("Timi", 1);
                    }
                    if (i == 3)
                    {
                        chara = "Luki";
                        PlayerPrefs.SetInt("Luki", 1);
                    }
                    if (i == 4)
                    {
                        PlayerPrefs.SetInt("Fini", 1);
                        chara = "Fini";
                    }
                    if (i == 5)
                    {
                        PlayerPrefs.SetInt("Matze", 1);
                        chara = "Matze";
                    }
                    instruction.text = "Dein Anfangscharakter ist \n " + chara + "!";
                }
                x++;
                if (introStep == x)
                {
                    instruction.text = "Tippe auf " + chara + "\n um fortzufahen.";
                }
                x++;
                x++;
                if (introStep == x)
                {
                    instruction.text = "Unten siehst du deine\n Aufgabenliste.";
                }
                x++;
                if (introStep == x)
                {
                    instruction.text = "Wenn du Aufgaben geschafft hast, klicke\nsie an und du bekommst eine Belohnung.";
                }
                x++;
                if (introStep == x)
                {
                    instruction.text = "Jetzt drücke auf Play\n um das Spiel zu beginnen";
                }
                x++;
                if(introStep > 12)
                {
                    instruction.text = "Beende das Tutorial indem du ein Score \n von 250 erreichst.";
                }
                if (sceneName == "level")
                {
                    if (einmal > 0)
                    {
                        instruction.text = "Jetzt kannst du alles. Dein Jump to\n Glory-Team wünscht dir ein schönes Sprigen!";
                        if (a.score < 200)
                        {
                            instruction.text = "Man setzt sie in der\nLuft mit einem Doppelklick ein.";
                        }
                        if (a.score < 150)
                        {
                            instruction.text = "Die grünen Kreise sind Doublejumps.\nDer Name sagt eigentlich alles über sie aus...";
                        }
                        if (a.score < 100)
                        {
                            instruction.text = "Um schneller auf den Boden zu kommen,\nsteiche nach unten.";
                        }
                        if (a.score < 50)
                        {
                            instruction.text = "Tippe, um zu springen.";
                        }
                        if (a.score > 250)
                        {
                            a.Pause.SetActive(true);                        
                            introStep = 0;
                            a.playIntro = false;
                            menu.gameObject.SetActive(true);
                            if (a.score < 251)
                            {
                              //  menu.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
                            }
                            this.transform.position = this.transform.position = new Vector3(Screen.width + 1000, Screen.height + 1000, -1);
                            instruction.text = "Tippe um\nFortzufahren";
                            einmal = 0;
                        }
                    }
                    else
                    {
                        einmal++;
                    }
                }
            }
 
        }
        if (doublejump)
        {
            instruction.text = "" + PlayerPrefs.GetInt("AnfangsDoublejumps");
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+1 anfangs-doublejump\n" + (10 + 2 * PlayerPrefs.GetInt("AnfangsDoublejumps")) + ".000";
        }
        if (münzenDublikator)
        {
            instruction.text = "" + PlayerPrefs.GetFloat("münzenDublikator") + "%";
            if (PlayerPrefs.GetFloat("münzenDublikator") % 1 == 0) {
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+ 2,5% Chance\n" + (10 + PlayerPrefs.GetFloat("münzenDublikator")) + ".000";
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+ 2,5% Chance\n" + (10 + PlayerPrefs.GetFloat("münzenDublikator")) + "00";
            }
        }
        if (schafStopp)
        {
            instruction.text = "" + PlayerPrefs.GetFloat("schafStopp") + "%";
            if (PlayerPrefs.GetFloat("schafStopp") % 1 == 0)
            {
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+ 2,5% Chance\n" + (10 + PlayerPrefs.GetFloat("schafStopp")) + ".000";
            }
            else
            {
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "+ 2,5% Chance\n" + (10 + PlayerPrefs.GetFloat("schafStopp")) + "00";
            }
        }
    }
    public void introWeiter(bool charakter)
    {
        a.errungenschaftAn = false;
        if (charakter)
        {
            if (introStep > 5)
            {
                if (a.spieler.gameObject.name == chara)
                {
                    introStep = 8;
                    x = 8;
                }
            }
        }
    }
    public void Anfagsdoublejump()
    {
        if (a.money >= 10000 + 2000 * PlayerPrefs.GetInt("AnfangsDoublejumps"))
        {
            a.money -= (10000 + 2000 * PlayerPrefs.GetInt("AnfangsDoublejumps"));
            PlayerPrefs.SetInt("AnfangsDoublejumps", PlayerPrefs.GetInt("AnfangsDoublejumps") + 1);
            PlayerPrefs.SetFloat("money", a.money);
        }
    }
    public void MünzenDublikator()
    {
        if (a.money >= 10000 + 1000 * PlayerPrefs.GetFloat("münzenDublikator"))
        {
            a.money -= (10000 + 1000 * PlayerPrefs.GetFloat("münzenDublikator"));
            PlayerPrefs.SetFloat("münzenDublikator", PlayerPrefs.GetFloat("münzenDublikator") + 2.5f);
            PlayerPrefs.SetFloat("money", a.money);
        }
    }
    public void SchafStopp()
    {
        if (a.money >= 10000 + 1000 * PlayerPrefs.GetFloat("schafStopp"))
        {
            a.money -= (10000 + 1000 * PlayerPrefs.GetFloat("schafStopp"));
            PlayerPrefs.SetFloat("schafStopp", PlayerPrefs.GetFloat("schafStopp") + 2.5f);
            PlayerPrefs.SetFloat("money", a.money);
        }
    }
}

