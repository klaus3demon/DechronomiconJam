using UnityEngine;
using System.Collections;

public class CargarScene : MonoBehaviour {
	public string scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CargaLa(){
		Application.LoadLevel (scene);
	}
}
