using UnityEngine;
using System.Collections;

public class Heroe : MonoBehaviour {
	public GameObject malvado,arena,cassio;
	// Use this for initialization
	void Start () {
	switch (PlayerPrefs.GetInt("heroe")) {
		
		case 0: cassio.SetActive(true);break;
		case 1: malvado.SetActive (true);break;
		case 2: arena.SetActive (true);break;

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
