using UnityEngine;
using System.Collections;

public class ScriptProta : MonoBehaviour {
    public GameObject player;
    public GameObject bala;
    public float speed = 0.7f;
    public float fuerza = 5.0f;
    ForceMode2D mode = ForceMode2D.Force;
    public float spacing = 1.0f;
    public Vector3 pos;
    public bool enaire = false;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && enaire == false)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * fuerza);
            enaire = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (enaire == false)
            {
                transform.Translate((-speed), 0f, 0f);
            }
            if (enaire == true)
            {
                transform.Translate((-0.05f), 0f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (enaire == false)
            {
                transform.Translate(speed, 0f, 0f);
            }
            if (enaire == true)
            {
                transform.Translate(0.05f, 0f, 0f);
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Suelo"){
            enaire = false;
        }
    }
}
