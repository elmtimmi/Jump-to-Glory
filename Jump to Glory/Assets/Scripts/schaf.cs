using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schaf : MonoBehaviour {
    public Transform Schaf1;
    bool einmal;
    public GameObject Trampolin;
    public GameObject dupppleJump;
    public bool schaf1;
    public bool schaf2;
    public GameObject mainCamera;
    private mainCamera b;
    GameObject Iteam;
    GameObject Tramp;
    // Use this for initialization
    void Start () {
        //Transform Schaf = Instantiate(Schaf1) as Transform;
        //Physics.IgnoreCollision(Schaf1.GetComponent<Collider>(), GetComponent<Collider>());
        b = mainCamera.GetComponent<mainCamera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (schaf2)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(-2.5f, this.GetComponent<Rigidbody>().velocity.y, 0);
        }
        if (this.transform.rotation.z < -0.1f && !einmal && schaf1)
        {
            Tramp = Instantiate(Trampolin, this.transform.position + new Vector3(-5, 0, 0), Quaternion.identity);
            Iteam = Instantiate(dupppleJump, this.transform.position + new Vector3(-4, 2, 0), Quaternion.identity);
            einmal = true;
        }
        if (this.transform.rotation.z > 0.225f && !einmal && schaf1)
        {
            Tramp = Instantiate(Trampolin, this.transform.position + new Vector3(-5, 0, 0), Quaternion.identity);
            Iteam = Instantiate(dupppleJump, this.transform.position + new Vector3(-4, 2, 0), Quaternion.identity);
            einmal = true;
        }
        if (Iteam != null)
        {
            Iteam.transform.position = new Vector3(Iteam.transform.position.x, Tramp.transform.position.y+ 2, Iteam.transform.position.z);
        }
    }
}
