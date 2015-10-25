using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {
	public GameObject vida1,vida2,vida3;
	private int contador;
	// Use this for initialization
	void Start () {
		contador = 3;
	}
	
	// pdate is called once per frame
	void Update () {
		
	}
	public void vidamenos(){
		if (contador == 3) {
			vida3.SetActive(false);
		}
		if (contador == 2) {
			vida2.SetActive(false);
		}
		if (contador == 1) {
			vida1.SetActive(false);
			Application.LoadLevel ("Gameover");
			
		}
		
		
	}
}