using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Content : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().position =  new Vector3 (this.GetComponent<RectTransform>().position.x, this.transform.parent.parent.transform.position.y, 0);
	}
}
