using UnityEngine;
using System.Collections;

public class ScriptProta : MonoBehaviour {
    public GameObject player;
    public GameObject bala;
    public float speed = 0.1f;
    public float rotationSpeed = 100.0F; //Velocidad de rotación
    public float fuerza = 5.0f;
    ForceMode2D mode = ForceMode2D.Force;
    public float spacing = 1.0f;
    public Vector3 pos;
    public bool enaire = false;
    public bool direccionderecha = true;

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
            //GetComponent<MovimientoProtagonista>().andar();
            if (enaire == false)
            {
                transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);
                Debug.Log(-Input.GetAxis("Horizontal"));
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cronosShotAttack();
        }
        //---------------------- Codigo para que el disparo sea láser dejando pulsado clic
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            cronosShotAttack();
        }*/
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Suelo"){
            enaire = false;
        }
    }
    private void cronosShotAttack()
    {
        Instantiate(bala, this.transform.localPosition, this.transform.localRotation);
    }
}
