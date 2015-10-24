using UnityEngine;
using System.Collections;

public class MovimientoProtagonista : MonoBehaviour {
	
	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void andar(){

			GetComponent<Animator> ().SetBool ("Move", true);
	
	}
	public void noandes(){
			GetComponent<Animator> ().SetBool ("Move", false);
		
	}
}
