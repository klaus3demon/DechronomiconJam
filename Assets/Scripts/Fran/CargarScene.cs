using UnityEngine;
using System.Collections;

public class CargarScene : MonoBehaviour {
	public string scene;
	public GameObject heroePpal;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CargaLa(){

		switch (heroePpal.tag) {
		
		case "Cassio" : PlayerPrefs.SetInt ("heroe",0);Debug.Log (heroePpal.tag);Application.LoadLevel (scene);break;
		case "Malvado" :  PlayerPrefs.SetInt ("heroe",1);Debug.Log (heroePpal.tag);Application.LoadLevel (scene);break;
		case "Arena" : PlayerPrefs.SetInt ("heroe",1);Debug.Log (heroePpal.tag);Application.LoadLevel (scene);break;
		
		
		}

		//Application.LoadLevel (scene);
	}
}
