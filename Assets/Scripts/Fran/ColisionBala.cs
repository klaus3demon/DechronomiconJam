using UnityEngine;
using System.Collections;

public class ColisionBala : MonoBehaviour {
	public bool amigo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
	if (!amigo) {
		if(other.tag == "Player"){
				//GameObject.Find(Canvas).GetComponent<Vidas>().vidamenos();
			}
		}
		if (amigo) {
			GameObject.FindGameObjectWithTag("Enemigo").GetComponent<Character>().vida();
		}
	}
}
