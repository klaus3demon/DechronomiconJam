using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImagenCentral : MonoBehaviour {
	public GameObject pequeña,grande;
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void imagenpalcentro(){
		grande.GetComponent<Image> ().sprite = pequeña.GetComponent<Image> ().sprite;
		grande.tag = pequeña.tag;

	}
}
