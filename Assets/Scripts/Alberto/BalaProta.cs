using UnityEngine;
using System.Collections;

public class BalaProta : MonoBehaviour {
    private float direccion;
	// Use this for initialization
	void Start () {
        if (ScriptProta.direccionderecha == true)
        {
            direccion = 0.1f;
        }
        else
        {
            direccion = -0.1f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (ScriptProta.direccionderecha == true) {
            this.transform.Translate(direccion, 0f, 0f);
        }
        else
        {
            this.transform.Translate(direccion, 0f, 0f);
        }
    }
}
