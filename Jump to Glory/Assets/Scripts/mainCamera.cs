using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainCamera : MonoBehaviour
{
    public GameObject spieler;
    public personControler a;
    public float score;
    public float recort;
    public bool menü;
    public GameObject hintergrund;
    // Use this for initialization
    public GameObject Jani;
    public GameObject Timi;
    public GameObject Luki;
    public GameObject Fini;
    public GameObject Matze;
    public GameObject Flo;
    public GameObject Liva;
    public float money;
    public int duppleJump;
    public int münzen;
    public bool tagesBelohnung;
    public string letztBelohung;
    public bool errungenschaftAn;
    public bool spieleIntro;
    public bool playIntro;
    public bool setztCharaktereNull;
    int einmal;
    int einmalBesetzt;
    public int[] besetzt = new int[13];
    public float springeDurchgehend;
    public int doupleJumpsEingesetz;
    public bool doubleJumpEingesammelt;
    public bool bodenBerührt;
    public GameObject errungenSchaften;
    public bool geheZumMenu;
    public GameObject Pause;
    public GameObject Münze;
    public GameObject Info;
    public int infoSpielerAusgewählt;
    public int beschleunigung;
    public int maxSpeed;
    public int anfangsSpeed;
    public GameObject PauseHintergrund;
    void Awake()
    {
        AudioListener.volume = 1;
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        int i = PlayerPrefs.GetInt("spieler");
        if (i == 1)
        {
            spieler = Jani;
        }
        if (i == 2)
        {
            spieler = Timi;
        }
        if (i == 3)
        {
            spieler = Luki;
        }
        if (i == 4)
        {
            spieler = Fini;
        }
        if (i == 5)
        {
            spieler = Matze;
        }
        if (i == 6)
        {
            spieler = Flo;
        }

        if (i == 7)
        {
            spieler = Liva;
        }
        if (spieler != null)
        {
            a = spieler.GetComponent<personControler>();
        }
        this.transform.position = new Vector3(9.25f, 29.77f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.autorotateToLandscapeLeft || Screen.autorotateToLandscapeRight)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (einmalBesetzt == 0)
        {
            einmalBesetzt = 1;
            for (int t = 0; t < besetzt.Length; t++)
            {
                besetzt[PlayerPrefs.GetInt("aufgabe" + t + " ")] = 1;
                // Debug.Log(PlayerPrefs.GetInt("besetzt" + t));
            }
        }
        if (setztCharaktereNull)
        {
            setztCharaktereNull = false;
            PlayerPrefs.SetInt("Jani", 0);
            PlayerPrefs.SetInt("Timi", 0);
            PlayerPrefs.SetInt("Luki", 0);
            PlayerPrefs.SetInt("Fini", 0);
            PlayerPrefs.SetInt("spieler", 0);
            spieler = null;
        }
        if (spieleIntro || PlayerPrefs.GetInt("spieler") == 0)
        {
            intro();
            spieleIntro = false;
        }

        if (PlayerPrefs.GetInt("date") == 0 && (PlayerPrefs.GetInt("hour") == 0) || PlayerPrefs.GetInt("CharaktereInfos") == 0)
        {
            PlayerPrefs.SetInt("CharaktereInfos", 1);

            PlayerPrefs.SetFloat("münzenDublikator", 5);
            PlayerPrefs.SetFloat("schafStopp", 5);

            PlayerPrefs.SetInt("date", System.DateTime.Now.Day);
            PlayerPrefs.SetInt("beschleunigung_Jani", 1);
            PlayerPrefs.SetInt("beschleunigung_Timi", 4);
            PlayerPrefs.SetInt("beschleunigung_Luki", 2);
            PlayerPrefs.SetInt("beschleunigung_Fini", 3);
            PlayerPrefs.SetInt("beschleunigung_Matze", 3);
            PlayerPrefs.SetInt("beschleunigung_Flo", 1);
            PlayerPrefs.SetInt("beschleunigung_Liva", 2);

            PlayerPrefs.SetInt("maxGeschwindigkeit_Jani", 9);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Timi", 8);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Luki", 10);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Fini", 11);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Matze", 10);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Flo", 7);
            PlayerPrefs.SetInt("maxGeschwindigkeit_Liva", 11);

            PlayerPrefs.SetInt("startGeschwindigkeit_Jani", 5);
            PlayerPrefs.SetInt("startGeschwindigkeit_Timi", 5);
            PlayerPrefs.SetInt("startGeschwindigkeit_Luki", 6);
            PlayerPrefs.SetInt("startGeschwindigkeit_Fini", 7);
            PlayerPrefs.SetInt("startGeschwindigkeit_Matze", 6);
            PlayerPrefs.SetInt("startGeschwindigkeit_Flo", 3);
            PlayerPrefs.SetInt("startGeschwindigkeit_Liva", 7);
        }
        if (!tagesBelohnung)
        {
            if (PlayerPrefs.GetInt("date") != System.DateTime.Now.Day)
            {
                tagesBelohnung = true;
            }
        }
        if (sceneName == "menu 1")
        {
            this.transform.position = new Vector3(9.25f, 29.77f, -10);
            //score = 0;
        }
        if (sceneName == "level")
        {
            if (this.transform.position.x > 0)
            {
                score = Mathf.Round(this.transform.position.x);
            }
            if (!spieler.GetComponent<personControler>().die) {
                this.transform.position = new Vector3(spieler.transform.position.x + 3.5f, this.transform.position.y, -10);
            }
        }
        if (PlayerPrefs.GetInt("AufgabenGeschafft") >= 40)
        {
            if (PlayerPrefs.GetInt("Flo") == 0)
            {
                errungenSchaften.SetActive(true);
                SceneManager.LoadScene(1);
                errungenschaftAn = true;
                PlayerPrefs.SetInt("Flo", 1);
                errungenSchaften.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                //   PlayerPrefs.SetInt("Flo", 0);
            }
        }
        if (PlayerPrefs.GetInt("AufgabenGeschafft") >= 60)
        {
            if (PlayerPrefs.GetInt("Liva") == 0)
            {
                errungenSchaften.SetActive(true);
                SceneManager.LoadScene(1);
                errungenschaftAn = true;
                PlayerPrefs.SetInt("Liva", 1);
                errungenSchaften.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void stopTime()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            menü = true;
            PauseHintergrund.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            menü = false;
            PauseHintergrund.SetActive(false);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "menu 1")
        {
            Time.timeScale = 1.0f;
        }
        if (a.jumping == 1)
        {
            a.rb.velocity = new Vector3(a.rb.velocity.x, 0, 0);
        }
    }
    public void menu()
    {
        PauseHintergrund.SetActive(false);
        if (spieler != null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "level")
            {
                geheZumMenu = true;
                Time.timeScale = 1.0f;
            }
            else
            {
                SceneManager.LoadScene(1);
            }
            if (sceneName == "menu 1")
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    public void wähleCharakter()
    {
        if (infoSpielerAusgewählt == 1)
        {
            if (PlayerPrefs.GetInt("Jani") == 1)
            {
                PlayerPrefs.SetInt("spieler", 1);
                spieler = Jani;
            }
            else
            {
                if (money > 19999)
                {
                    money -= 20000;
                    PlayerPrefs.SetFloat("money", money);
                    PlayerPrefs.SetInt("Jani", 1);
                    spieler = Jani;
                }
            }
        }
        if (infoSpielerAusgewählt == 2)
        {
            if (PlayerPrefs.GetInt("Timi") == 1)
            {
                PlayerPrefs.SetInt("spieler", 2);
                spieler = Timi;
            }
            else
            {
                if (money > 19999)
                {
                    money -= 20000;
                    PlayerPrefs.SetFloat("money", money);
                    PlayerPrefs.SetInt("Timi", 1);
                    spieler = Timi;
                }
            }
        }
        if (infoSpielerAusgewählt == 3)
        {
            if (PlayerPrefs.GetInt("Luki") == 1)
            {
                PlayerPrefs.SetInt("spieler", 3);
                spieler = Luki;
            }
            else
            {
                if (money > 19999)
                {
                    money -= 20000;
                    PlayerPrefs.SetFloat("money", money);
                    PlayerPrefs.SetInt("Luki", 1);
                    spieler = Luki;
                }
            }
        }
        if (infoSpielerAusgewählt == 4)
        {
            if (PlayerPrefs.GetInt("Fini") == 1)
            {
                PlayerPrefs.SetInt("spieler", 4);
                spieler = Fini;
            }
            else
            {
                if (money > 19999)
                {
                    money -= 20000;
                    PlayerPrefs.SetFloat("money", money);
                    PlayerPrefs.SetInt("Fini", 1);
                    spieler = Fini;
                }
            }
        }
        if (infoSpielerAusgewählt == 5)
        {
            if (PlayerPrefs.GetInt("Matze") == 1)
            {
                PlayerPrefs.SetInt("spieler", 5);
                spieler = Matze;
            }
            else
            {
                if (money > 19999)
                {
                    money -= 20000;
                    PlayerPrefs.SetFloat("money", money);
                    PlayerPrefs.SetInt("Matze", 1);
                    spieler = Matze;
                }
            }
        }
        if (infoSpielerAusgewählt == 6)
        {
            if (PlayerPrefs.GetInt("Flo") == 1)
            {
                PlayerPrefs.SetInt("spieler", 6);
                spieler = Flo;
            }
            errungenschaftAn = false;
            errungenSchaften.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (infoSpielerAusgewählt == 7)
        {
            if (PlayerPrefs.GetInt("Liva") == 1)
            {
                PlayerPrefs.SetInt("spieler", 7);
                spieler = Liva;
            }
            errungenschaftAn = false;
            errungenSchaften.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void tagesBelohung()
    {
        money += 1000;
        PlayerPrefs.SetFloat("money", money);
        PlayerPrefs.SetInt("date", System.DateTime.Now.Day);
        tagesBelohnung = false;
    }
    public void intro()
    {
        SceneManager.LoadScene(3);
        if (PlayerPrefs.GetInt("date") == 0)
        {
            PlayerPrefs.SetInt("date", System.DateTime.Now.Day);
        }
        playIntro = true;
    }
    public void info(int Spieler)
    {
        infoSpielerAusgewählt = Spieler;
        if (Spieler == 1)
        {
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Jani";
            if (PlayerPrefs.GetInt("Jani") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Kaufen für 20.000T";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Jani");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Jani");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Jani");
        }
        if (Spieler == 2)
        {
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Timi";
            if (PlayerPrefs.GetInt("Timi") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Kaufen für 20.000T";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Timi");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Timi");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Timi");
        }
        if (Spieler == 3)
        {
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Luki";
            if (PlayerPrefs.GetInt("Luki") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Kaufen für 20.000T";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Luki");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Luki");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Luki");
        }
        if (Spieler == 4)
        {
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Fini";
            if (PlayerPrefs.GetInt("Fini") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Kaufen für 20.000T";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Fini");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Fini");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Fini");
        }
        if (Spieler == 5)
        {
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Matze";
            if (PlayerPrefs.GetInt("Matze") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Kaufen für 20.000T";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Matze");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Matze");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Matze");
        }
        if (Spieler == 6)
        {
            SceneManager.LoadScene(3);
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Flo";
            if (PlayerPrefs.GetInt("Flo") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Unbezahlbar";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Flo");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Flo");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Flo");
        }
        if (Spieler == 7)
        {
            SceneManager.LoadScene(3);
            Info.gameObject.transform.GetChild(2).GetComponent<Text>().text = "Dr. Liva";
            if (PlayerPrefs.GetInt("Liva") == 0)
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Unbezahlbar";
            }
            else
            {
                Info.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = "Anwenden";
            }
            maxSpeed = PlayerPrefs.GetInt("maxGeschwindigkeit_Liva");
            beschleunigung = PlayerPrefs.GetInt("beschleunigung_Liva");
            anfangsSpeed = PlayerPrefs.GetInt("startGeschwindigkeit_Liva");
        }
        if (maxSpeed != 0 && beschleunigung != 0 && anfangsSpeed != 0) {
            PlayerPrefs.SetInt("maxSpeed", maxSpeed);
            PlayerPrefs.SetInt("beschleunigung", beschleunigung);
            PlayerPrefs.SetInt("anfangsSpeed", anfangsSpeed);
        }
        if (Info.gameObject.activeSelf == true)
        {
            Info.SetActive(false);
        }
        else
        {
            Info.SetActive(true);
            string special = "";
            if (Spieler == 6)
            {
                Info.transform.GetChild(4).GetComponent<Text>().text = "Beschleunigung: " + "?";
                Info.transform.GetChild(5).GetComponent<Text>().text = "Max. Geschwindigkeit: " + "?";
                Info.transform.GetChild(6).GetComponent<Text>().text = "Anfangs Geschwindigkeit: " + "?";
                special = "Mr. Flo ist ein sehr stimmungsschwankender Charakter. So ist seine Geschwindigkeit immer zufällig.";
            }
            Info.transform.GetChild(4).GetComponent<Text>().text = "Beschleunigung: " + beschleunigung;
            Info.transform.GetChild(5).GetComponent<Text>().text = "Max. Geschwindigkeit: " + maxSpeed;
            Info.transform.GetChild(6).GetComponent<Text>().text = "Anfangs Geschwindigkeit: " + anfangsSpeed;
            if (Spieler == 1)
            {
                special = "";
            }
            if (Spieler == 7)
            {
                special = "Dr. Liva ist ein der Golden Retriever. Wie der Name schon sagt wird ihr nach dem Tod 1.5 mal mehr Gold abgerechnet :P";
            }
            Info.transform.GetChild(7).GetComponent<Text>().text = special;
        }
    }
}
