using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class personControler : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody rb;

    public bool isGrounded;
    public int started;
    public GameObject mainCamera;
    private mainCamera a;
    public GameObject hintergrund;
    public bool neuerHintergrund;
    int einmal;
    public GameObject häuser_1;
    public GameObject häuser_2;
    public GameObject häuser_3;
    public GameObject Wiese1;
    public GameObject Wiese2;
    public GameObject Wiese3;
    public GameObject Wiese;
    public GameObject Straße;
    public GameObject Straßenbahn;
    public GameObject Auto1;
    public GameObject Auto2;
    public GameObject Auto3;
    public GameObject Auto4;
    public GameObject Portal;
    public GameObject Trampolin1;
    public GameObject Trampolin2;
    public bool loadMap;
    public GameObject Schaf1;
    public GameObject Schaf2;
    public GameObject Häuserkette;
    public GameObject WieseHintergrund;
    public GameObject Münze;
    public GameObject Haus;
    public float length;
    public float y;
    public float speed;
    public GameObject dupppleJump;
    public int grounted;
    public Vector3 velocity;
    public int biom;
    public Animator anim;
    public bool laufen;
    public int jumping;
    public float spawnSchaf;
    float c = 2;
    public Collision colliders;
    bool durchgehendSprungAbgebrochen;
    public bool sprungBegonnen;
    public bool tiggerWork;
    public float yWegMaus;
    public int sprungVomBoden;
    public bool einmalNachUnten;
    bool einmalGrounted;
    public int doppelKlick;
    private AudioSource audioSource;
    public AudioClip otherClip;
    public int rotation;
    public GameObject SchafWarnung;
    public GameObject SchafWarnung2;
    public GameObject StraßenbahnWarnung;
    public GameObject TrampolinHinweiß;
    int spwanschaf;
    float spawnAuto;
    public bool die;
    public int drehung;
    GameObject Portal2;
    GameObject Tram;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        AudioSource audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        SchafWarnung.gameObject.SetActive(false);
        SchafWarnung2.gameObject.SetActive(false);
        StraßenbahnWarnung.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        a = mainCamera.GetComponent<mainCamera>();
        rb = GetComponent<Rigidbody>();
        a.money = PlayerPrefs.GetFloat("money");
        a.recort = PlayerPrefs.GetFloat("rekort");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "dubbleJump(Clone)")
        {
            a.duppleJump++;
            a.doubleJumpEingesammelt = true;
            Destroy(other.gameObject);
            rb.velocity = velocity;
            tiggerWork = true;
        }
        if (other.transform.name == "Münze(Clone)")
        {
            Destroy(other.gameObject);
            a.münzen += 5;
        }
        if (other.transform.name == "Portal(Clone)")
        {
            loadMap = true;
            rb.velocity = new Vector3(speed, 0, 0);
        }
        if (other.transform.name == "Schaf1(Clone)")
        {
            die = true;
            speed = -5;
            drehung = 10;
            rb.AddForce(new Vector3(-10, 0, 0) * 200);
        }
    }
    void OnCollisionStay(Collision col)
    {
        if (!einmalGrounted)
        {
            yWegMaus = Input.mousePosition.y;
            einmalGrounted = true;
        }
        isGrounded = true;
        a.bodenBerührt = true;
        anim.SetBool("Running", true);
        anim.SetBool("Jumping", false);
        jumping = 30;
        if (started < 2)
        {
            started = 1;
        }
        if (col.transform.name == "dubbleJump(Clone)")
        {
            if (tiggerWork == false)
            {
                a.duppleJump++;
                a.doubleJumpEingesammelt = true;
                Destroy(col.gameObject);
                rb.velocity = velocity;
            }
        }
        if (col.transform.name == "Trampolin1(Clone)")
        {
            rb.velocity = new Vector3(speed * 1.5f, 15, 0);
            anim.SetBool("Running", false);
            anim.SetBool("Jumping", true);
        }
        if (col.transform.name == "Trampulin2(Clone)")
        {
            rb.velocity = new Vector3(speed * 3, 15, 0);
            rotation = -1;
        }
        if (col.transform.name == "Schaf2(Clone)")
        {
            die = true;
            drehung = 10;
            rb.AddForce(new Vector3(speed, 10, 0) * 25);
        }
        if (col.transform.name == "Straßenbahn(Clone)" && col.collider.GetType() == typeof(CapsuleCollider))
        {
            die = true;
            speed = -5;
            drehung = 10;
            rb.AddForce(new Vector3(-10, 0, 0) * 100);
        }
        if (col.transform.name == "Grünes_Auto(Clone)" || col.transform.name == "Rotes_Auto(Clone)" || col.transform.name == "Weißes_Auto(Clone)" || col.transform.name == "Blaues_Auto(Clone)")
        {
            if (col.collider.GetType() == typeof(CapsuleCollider) && drehung == 0)
            {
                die = true;
                drehung = 10;
                rb.AddForce(new Vector3(10, 10, 0) * 100);
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        colliders = col;
    }
    // Update is called once per frame
   void Update()
    {
        //   Debug.Log(Input.mousePosition.y + );
        if (Time.timeScale == 1.0f)
        {
            velocity = rb.velocity;
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName != "menu 1" && sceneName != "erste" && sceneName != "Shop" && a.spieler == this.gameObject)
            {
                if (einmal == 0)
                {
                    a.errungenschaftAn = false;
                    a.doubleJumpEingesammelt = false;
                    durchgehendSprungAbgebrochen = false;
                    a.bodenBerührt = false;
                    a.duppleJump = PlayerPrefs.GetInt("AnfangsDoublejumps");
                    this.transform.position = new Vector3(0f, 2.72f, -0.01f);
                    einmal = 1;
                    neuerHintergrund = true;
                    a.money = PlayerPrefs.GetFloat("money");
                    length = 0;
                    c = 2;
                    loadMap = true;
                }
                if (loadMap)
                {
                    int durchgänge = 0;
                    durchgänge++;
                    this.transform.position -= new Vector3(0, 50, 0);
                    if (!die) {
                        mainCamera.transform.position = new Vector3(0, this.transform.position.y + 4, 0);
                    }
                    if (biom == 0)
                    {
                        biom = Random.Range(1, 4);
                    }
                    else if (biom == 1)
                    {
                        biom = Random.Range(2, 4);
                    }
                    else if(biom == 2)
                    {
                       while(biom == 2)
                        {
                            biom = Random.Range(1, 4);
                        }
                    }
                    else if(biom == 3)
                    {
                        biom = Random.Range(1, 3);
                    }
                    length = 0;
                    if (biom == 1)
                    {
                        SchafWarnung.gameObject.SetActive(false);
                        SchafWarnung2.gameObject.SetActive(false);
                        StraßenbahnWarnung.gameObject.SetActive(false);
                        Häuserkette.transform.position = this.transform.position - new Vector3 (0,-6.5f,-1);
                        WieseHintergrund.transform.position = this.transform.position - new Vector3(0, 50f, -1);
                        Haus = Instantiate(häuser_3, new Vector3(this.transform.position.x, this.transform.position.y - 5.5f + y, -1), Quaternion.identity);
                        Haus = Instantiate(häuser_3, new Vector3(this.transform.position.x + 5.55f * 2, this.transform.position.y - 5.5f + y, -1), Quaternion.identity);
                        length += 5.55f * 3 + 3;
                        for (int i = 0; length < 500; i++)
                        {
                            if (c < 6)
                            {
                                c = c + 0.1f;
                            }
                            int haus = 0;
                            //  if (length < 500)
                            //  {
                            //      haus = Random.Range(1, 4);
                            //  }
                            //  else
                            // {
                            haus = Random.Range(1, 4);
                            int münze = Random.Range(1, 10);
                            //    }
                            if (i == 0)
                            {
                                haus = 2;
                            }
                            if (i != 0)
                            {
                                y = Random.Range(-1.1f, 1.1f);
                            }
                            if (haus == 1)
                            {
                                Haus = Instantiate(häuser_1, new Vector3(this.transform.position.x + length + 3.73f, this.transform.position.y - 4 + y, -1), Quaternion.identity);
                                length += 3.73f * 2;
                            }
                            if (haus == 2)
                            {
                                Haus = Instantiate(häuser_2, new Vector3(this.transform.position.x + length + 8.925f, this.transform.position.y - 4 + y, -1), Quaternion.identity);
                                length += 8.925f * 2;
                            }
                            if (haus == 3)
                            {
                                Haus = Instantiate(häuser_3, new Vector3(this.transform.position.x + length + 5.55f, this.transform.position.y - 4 + y, -1), Quaternion.identity);
                                length += 5.55f * 2;
                            }
                            if (haus != 0)
                            {
                                if (length < 500)
                                {
                                    length += Random.Range(2, c);
                                }
                                else
                                {
                                    length += Random.Range(c - 2, c);
                                }
                            }
                            else
                            {
                                //length += 6.74f / 2;
                            }
                            int doppelJump = Random.Range(0, 20);
                            if (doppelJump == 1 || doppelJump == 2)
                            {
                                Instantiate(dupppleJump, new Vector3(this.transform.position.x + length - 5, this.transform.position.y + 1.5f, -1), Quaternion.identity);
                            }                            if (haus != 0)
                            {
                                if (length < 500)
                                {
                                    length += Random.Range(2, c);
                                }
                                else
                                {
                                    length += Random.Range(c - 2, c);
                                }
                            }
                            else
                            {
                                //length += 6.74f / 2;
                            }
                            if (münze == 1 || münze == 2)
                            {
                                Instantiate(Münze, Haus.transform.position - new Vector3(2, -5, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(0, -5, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(-2, -5, -1), Quaternion.identity);
                                if (haus == 2 || haus == 3)
                                {
                                    Instantiate(Münze, Haus.transform.position - new Vector3(4, -5, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-4, -5, -1), Quaternion.identity);
                                }
                                if (haus == 3)
                                {
                                    Instantiate(Münze, Haus.transform.position - new Vector3(6, -5, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-6, -5, -1), Quaternion.identity);
                                }
                            }else if (münze == 3)
                            {
                                Instantiate(Münze, Haus.transform.position - new Vector3(1, -5, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(0, -5, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(-1, -5, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(1, -6, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(0, -6, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(-1, -6, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(1, -7, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(0, -7, -1), Quaternion.identity);
                                Instantiate(Münze, Haus.transform.position - new Vector3(-1, -7, -1), Quaternion.identity);
                            }else if (münze == 4)
                            {
                                if (haus == 1)
                                {
                                    Instantiate(Münze, Haus.transform.position - new Vector3(1, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(0, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-1, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(1, -8, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(0, -8, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-1, -8, -1), Quaternion.identity);
                                }
                                else if (haus == 2 || haus == 3)
                                {
                                    Instantiate(Münze, Haus.transform.position - new Vector3(2, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(0, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-2, -7, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(2, -8, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(0, -8, -1), Quaternion.identity);
                                    Instantiate(Münze, Haus.transform.position - new Vector3(-2, -8, -1), Quaternion.identity);
                                }
                            }
                            else
                            {
                                int t = 0;
                                t = Random.Range(2, 4);
                                if (t == 3)
                                {
                                    GameObject Trampolin = null;
                                    if (haus == 1)
                                    {
                                        float l = 0;
                                        l = Random.Range(1, 4);
                                        Trampolin = Instantiate(Trampolin1, Haus.transform.position - new Vector3(-3.5f + l, -8 + 3.6f, -1), Quaternion.identity);
                                    }
                                    if (haus == 2)
                                    {
                                        float l = 0;
                                        l = Random.Range(1, 7.5f);
                                        Trampolin = Instantiate(Trampolin1, Haus.transform.position - new Vector3(-8f + l, -8 + 3.6f, -1), Quaternion.identity);
                                    }
                                    if (haus == 3)
                                    {
                                        float l = 0;
                                        l = Random.Range(1, 4.5f);
                                        Trampolin = Instantiate(Trampolin1, Haus.transform.position - new Vector3(-5f + l, -8 + 3.6f, -1), Quaternion.identity);
                                    }
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5, 2, 0), Quaternion.identity);
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5, 3, 0), Quaternion.identity);
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5 * 2, 4, 0), Quaternion.identity);
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5 * 2, 5, 0), Quaternion.identity);
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5 * 3, 6, 0), Quaternion.identity);
                                    Instantiate(Münze, Trampolin.transform.position + new Vector3(speed / 5 * 3, 7, 0), Quaternion.identity);
                                }
                                else
                                {
                                    t = Random.Range(1, 5);
                                    if (t == 4) {
                                        Instantiate(Trampolin2, Haus.transform.position - new Vector3(0, -8 + 3.6f, -1), Quaternion.identity);
                                    }
                                }
                            }
                        }
                        Instantiate(Portal, this.transform.position + new Vector3(500, 5f, 0), Quaternion.identity);
                        Instantiate(häuser_2, new Vector3(this.transform.position.x + 500 + 8.925f, this.transform.position.y - 4 + y, -1), Quaternion.identity);
                        loadMap = false;
                    }
                    if (biom == 2)
                    {
                        spawnSchaf = this.transform.position.x;
                        WieseHintergrund.transform.position = this.transform.position + new Vector3(0, 6f, 1);
                        Häuserkette.transform.position = this.transform.position + new Vector3(0, 50, -1);
                        for (int i = 0; i < 13; i++)
                        {
                            int wiese = Random.Range(1, 4);
                            if (wiese == 1)
                            {
                                Wiese = Instantiate(Wiese1, new Vector3(this.transform.position.x + i * 41.252f , this.transform.position.y - 4, -1), Quaternion.identity);
                            }
                            if (wiese == 2)
                            {
                                Wiese = Instantiate(Wiese2, new Vector3(this.transform.position.x + i * 41.252f , this.transform.position.y - 4, -1), Quaternion.identity);
                            }
                            if (wiese == 3)
                            {
                                Wiese = Instantiate(Wiese3, new Vector3(this.transform.position.x + i * 41.252f, this.transform.position.y - 4, -1), Quaternion.identity);
                            }
                        }
                        loadMap = false;
                        Instantiate(Portal, this.transform.position + new Vector3(500, 5f, 0), Quaternion.identity);
                    }
                    if (biom == 3)
                    {
                        Häuserkette.transform.position = this.transform.position - new Vector3(0, -6.5f, -1);
                        WieseHintergrund.transform.position = this.transform.position - new Vector3(0, 50f, -1);
                        Tram = Instantiate(Straßenbahn, this.transform.position + new Vector3(speed * 3, 1.5f, 0), Quaternion.identity);
                        spawnAuto = this.transform.position.x + speed * 2;
                        SchafWarnung.gameObject.SetActive(false);
                        SchafWarnung2.gameObject.SetActive(false);
                        StraßenbahnWarnung.gameObject.SetActive(false);
                        for (int i = 0; i < 13; i++) {
                            Instantiate(Straße, new Vector3(this.transform.position.x + i * 41.3f, this.transform.position.y, -1), Quaternion.identity); //41,3
                        }
                        Portal2 = Instantiate(Portal, this.transform.position + new Vector3(500, 1.5f, 0), Quaternion.identity);
                        loadMap = false;
                    }
                }
                if (biom == 2)
                {
                    if (rb.velocity.x < speed && !die) {
                        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
                    }
                    if (rb.velocity.x < 0.1f)
                    {
                    //    rb.AddForce(new Vector3(10, 0, 0) * 100);
                    }
                    if (spawnSchaf - this.transform.position.x < speed && spwanschaf == 1)
                    {
                        SchafWarnung.gameObject.SetActive(true);
                    }
                    if (spawnSchaf - this.transform.position.x < speed * 2 && spwanschaf == 2)
                    {
                        SchafWarnung2.gameObject.SetActive(true);
                    }
                    StraßenbahnWarnung.gameObject.SetActive(false);
                    if (spawnSchaf < this.transform.position.x)
                    {
                        SchafWarnung.gameObject.SetActive(false);
                        SchafWarnung2.gameObject.SetActive(false);
                        spawnSchaf = this.transform.position.x + speed * 3f;
                        GameObject Schaf = null;
                        int s = 0;
                        s = Random.Range(1, 4);
                        if (s == 1)
                        {
                            spwanschaf = 1;
                            Schaf = Instantiate(Schaf1, new Vector3(this.transform.position.x + speed * 5, this.transform.position.y + 3, 0), Quaternion.identity);
                            if (Random.Range(1, 4) == 3)
                            {
                            //    Instantiate(Trampolin1, Schaf.transform.position + new Vector3(-5, 0, 0), Quaternion.identity);
                            //    Instantiate(dupppleJump, Schaf.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
                            }
                        }
                        else if (s == 2)
                        {
                            spwanschaf = 2;
                            Schaf = Instantiate(Schaf2, new Vector3(this.transform.position.x + speed * 5, this.transform.position.y + 3, 0), Quaternion.identity);
                        }
                        else
                        {
                            spwanschaf = 0;
                            int t = 0;
                            t = Random.Range(1, 5);
                            if (t == 4)
                            {
                                Instantiate(Trampolin2, this.transform.position + new Vector3(speed * 5, 3, 0), Quaternion.identity);
                            }
                        }
                    }
                }
                if (biom == 3)
                {
                    if (Tram.transform.position.x - this.transform.position.x < speed * 2)
                    {
                        StraßenbahnWarnung.gameObject.SetActive(true);
                    }
                    if (Tram.transform.position.x - this.transform.position.x < 5 || Tram.transform.position.x - this.transform.position.x > 2 * speed)
                    {
                        StraßenbahnWarnung.gameObject.SetActive(false);
                    }
                    if (rb.velocity.x < speed && !die)
                    {
                        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
                    }
                    if (spawnAuto < this.transform.position.x && Portal2.transform.position.x - this.transform.position.x > speed * 4)
                    {
                        spawnAuto = this.transform.position.x + speed * Random.Range(1.7f, 2.5f);
                        int r = Random.Range(1, 6);
                        if (r == 1)
                        {
                            Tram = Instantiate(Straßenbahn, this.transform.position + new Vector3(speed * 4, 1.5f, 0), Quaternion.identity);
                            spawnAuto -= 2.5f;
                        }
                        if (r == 2)
                        {
                            Instantiate(Auto1, this.transform.position + new Vector3(speed * 4, 1.5f, 0), Quaternion.identity);
                        }
                        if (r == 3)
                        {
                            Instantiate(Auto2, this.transform.position + new Vector3(speed* 4, 1.5f, 0), Quaternion.identity);
                            Instantiate(Auto3, this.transform.position + new Vector3(speed * 6, 1.5f, 0), Quaternion.identity);
                            Tram = Instantiate(Straßenbahn, this.transform.position + new Vector3(speed * 8, 1.5f, 0), Quaternion.identity);
                            spawnAuto += speed * 3.5f;
                        }
                        if (r == 4)
                        {
                            Instantiate(Auto3, this.transform.position + new Vector3(speed * 4, 1.5f, 0), Quaternion.identity);
                        }
                        if (r == 5)
                        {
                            Instantiate(Auto4, this.transform.position + new Vector3(speed * 4, 1.5f, 0), Quaternion.identity);
                        }
                    }
                }
                if (rb.velocity.x < 0.1f && !die)
                {
                    rb.AddForce(new Vector3(10, 0, 0) * 10);
                }
                else
                {
                    if (rb.velocity.y < 0 && !die)
                    {
                        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
                    }
                }
                if (jumping > 0)
                {
                    jumping--;
                }
                else
                {
                    anim.SetBool("Jumping", true);
                    einmalGrounted = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    sprungBegonnen = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    sprungVomBoden--;
                    if (sprungBegonnen)
                    {
                        if (durchgehendSprungAbgebrochen == false)
                        {
                            a.springeDurchgehend = a.score;
                            durchgehendSprungAbgebrochen = true;
                        }
                    }
                }
                if(sprungVomBoden < 2)
                {
                    sprungVomBoden--;
                }
                if (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                {
                    yWegMaus = Input.mousePosition.y;
                }
                if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButton(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                {
                   if(Input.mousePosition.y < yWegMaus - Screen.height / 32)
                    {
                        if (!einmalNachUnten)
                        {
                            rb.AddForce(new Vector3(0, -6 * 20, 0) * 3.5f);
                            einmalNachUnten = true;
                            yWegMaus = Input.mousePosition.y;
                            anim.SetBool("Jumping", false);
                        }
                    }
                }
                if (rb.velocity.x > 0)
                {
                    if (started == 1)
                    {
                        started = 2;
                    }
                    if (isGrounded)
                    {
                        grounted = 2;
                        float faktor = 0;
                        if (biom == 3)
                        {
                            faktor = 4.3f;
                        }
                        else
                        {
                            faktor = 3.5f;
                        }
                        if (speed > PlayerPrefs.GetInt("maxSpeed"))
                        {
                            speed = PlayerPrefs.GetInt("maxSpeed");
                        }
                        if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButton(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                        {
                            if (einmalNachUnten == false)
                            {
                                sprungVomBoden = 2;
                                anim.SetBool("Running", false);
                                rb.AddForce(new Vector3(0, 6 * 20, 0) * faktor);
                                yWegMaus = Input.mousePosition.y;
                                PlayAudio();
                                this.audioSource.Play();
                            } 
                        }
                    }
                    else
                    {
                        grounted--;
                        if (grounted < 1)
                        {
                            float faktor = 0;
                            faktor = 3.5f;
                            if (a.duppleJump > 0)
                            {
                                if (Input.GetMouseButtonUp(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButtonUp(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                                {
                                    if (sprungVomBoden < 0 && einmalNachUnten == false)
                                        {
                                        if (doppelKlick > 0)
                                        {
                                            if (rb.velocity.y < 0)
                                            {
                                                rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                                                rb.AddForce(new Vector3(0, 6 * faktor * 30, 0));
                                            }
                                            else
                                            {
                                                rb.AddForce(new Vector3(0, 6 * 30 * faktor, 0));
                                            }
                                            a.duppleJump--;
                                            a.doupleJumpsEingesetz++;
                                        }
                                        else
                                        {
                                            doppelKlick = 20;
                                        }
                                    }
                                }
                            }
                        }
                        grounted = 0;
                    }
                    if (Input.GetMouseButtonUp(0) && Input.mousePosition.x < Screen.width - Screen.width / 6 || Input.GetMouseButtonUp(0) && Input.mousePosition.y < Screen.height - Screen.height / 6)
                    {
                        einmalNachUnten = false;
                    }

                }
                if (neuerHintergrund)
                {
                    Instantiate(hintergrund, new Vector3(this.transform.position.x - 4.3f, 6, 0), Quaternion.identity);
                    neuerHintergrund = false;
                }
                isGrounded = false;
                if (started == 2)
                {
                    if (rb.velocity.x < 0.01f && biom == 1 || this.transform.position.y < mainCamera.transform.position.y - 11 || a.geheZumMenu)
                    {
                        if (colliders.transform.name != "dubbleJump(Clone)")
                        {
                            a.money = PlayerPrefs.GetFloat("money");
                            if (this.transform.name == "Liva")
                            {
                                PlayerPrefs.SetFloat("money", Mathf.Round(a.münzen * 1.5f + a.money));
                            }
                            else
                            {
                                PlayerPrefs.SetFloat("money", Mathf.Round(a.münzen + a.money));
                            }
                            a.münzen = 0;
                            a.money = PlayerPrefs.GetFloat("money");
                            SceneManager.LoadScene(1);
                            if (PlayerPrefs.GetFloat("rekort") < a.score)
                            {
                                PlayerPrefs.SetFloat("rekort", Mathf.Round(a.score));
                                a.recort = PlayerPrefs.GetFloat("rekort");
                            }
                            if (!durchgehendSprungAbgebrochen)
                            {
                                a.springeDurchgehend = a.score;
                            }
                            a.doupleJumpsEingesetz = 0;
                            a.geheZumMenu = false;
                            loadMap = false;
                            SchafWarnung.gameObject.SetActive(false);
                            SchafWarnung2.gameObject.SetActive(false);
                            StraßenbahnWarnung.gameObject.SetActive(false);
                        }
                    }
                }
            }
            else
            {
                die = false;
                transform.rotation = Quaternion.identity;
                drehung = 0;
                started = 0;
                if (this.gameObject.name == "Luki")
                {
                    this.transform.position = new Vector3(-100f, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Timi")
                {
                    this.transform.position = new Vector3(-200f, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Jani")
                {
                    this.transform.position = new Vector3(-300f, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Fini")
                {
                    this.transform.position = new Vector3(-400f, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Matze")
                {
                    this.transform.position = new Vector3(-500, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Flo")
                {
                    this.transform.position = new Vector3(-600, 2.72f, -0.01f);
                }
                if (this.gameObject.name == "Liva")
                {
                    this.transform.position = new Vector3(-700, 2.72f, -0.01f);
                }
                rb.velocity = new Vector3(0, 0, 0);
                einmal = 0;
                speed = PlayerPrefs.GetInt("anfangsSpeed");
                c = 0;
            }
        }
    }
    void FixedUpdate()
    {
        if (rotation > 0)
        {
            rotation--;
            this.transform.Rotate(0, 0, -4);
        }
        if (rotation == -1)
        {
            rotation = 90;
        }
        if (drehung > 0)
        {
            drehung--;
            this.transform.Rotate(0, 0, -10);
            if (drehung == 1)
            {
                a.geheZumMenu = true;
            }
        }
        if (this.gameObject.name == "Flo")
        {
            speed += Random.Range(-0.9f, 0.9f);
            if (speed < 3f)
            {
                speed = 3f;
            }
        }
        else //if (a.menü == false)
        {
            speed += 0.001f * PlayerPrefs.GetInt("beschleunigung");
        }
        doppelKlick--;
    }
    IEnumerator PlayAudio ()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
        audio.Play();
    }
}

