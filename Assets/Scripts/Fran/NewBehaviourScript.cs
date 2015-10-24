using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject hola;
	// Use this for initialization
	public int speed =1;
	public float spacing = 10.0f;
	private Vector3 pos;
	
	public void Start() {
		pos = transform.position;
	}
	
	public void Update() {
		if (Input.GetKey(KeyCode.W))
			pos.y=1;
		if (Input.GetKey(KeyCode.S))
			pos.y -= 1;
		if (Input.GetKey(KeyCode.A))
			transform.Translate ((-0.1f),0f,0f) ;
		if (Input.GetKey(KeyCode.D))
			transform.Translate (0.1f,0f,0f) ;
		

	}

}
