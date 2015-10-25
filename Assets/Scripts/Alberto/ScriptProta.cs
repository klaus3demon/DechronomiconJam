using UnityEngine;
using System.Collections;

public class ScriptProta : MonoBehaviour {
    public GameObject player;
    public GameObject bala;
    public float speed = 0.2f;
    public float rotationSpeed = 100.0F; //Velocidad de rotación
    public float fuerza = 2000.0f;
    //ForceMode2D mode = ForceMode2D.Force;
    public float spacing = 1.0f;
    public bool enaire = false;
    public static bool direccionderecha = true;
    public static int modocombate = 0;
    public static int contadorbalas = 0;
    public static int contadorespadazos = 0;
    public static int contadorgarrazos = 0;
    public float tiempoinicial = 0.0f;
    public float delay = 2.0f;
    public float delaygolpe = 1.0f;
    public int tiempoborradobala = 5;
    public int tiempoiniciodisparobala = 0;
    public GameObject dad;

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
			GetComponent<MovimientoProtagonista>().andar();
			this.transform.localScale = new Vector3 (-1f,1f,1f);
            if (enaire == false)
            {
                transform.Translate((-speed), 0f, 0f);
                direccionderecha = false;
            }
            if (enaire == true)
            {
                transform.Translate((-0.05f), 0f, 0f);
                direccionderecha = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<MovimientoProtagonista>().noAndar();
        }
        if (Input.GetKey(KeyCode.D))
        {
			GetComponent<MovimientoProtagonista>().andar();
			this.transform.localScale = new Vector3 (1f,1f,1f);
            if (enaire == false)
            {
                transform.Translate(speed, 0f, 0f);
                direccionderecha = true;
            }
            if (enaire == true)
            {
                transform.Translate(0.05f, 0f, 0f);
                direccionderecha = true;
            }
        }
        //------------- Parar animación de pies al soltar el botón
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<MovimientoProtagonista>().noAndar();
        }
        //------------- Atacar con barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cronosAttack();
        }
        //---------------------- Codigo para que el disparo sea láser dejando pulsado clic
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            cronosShotAttack();
        }*/
    }
    //------------- Desactiva las propiedades especiales del personaje al estar en el aire
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo"){
            enaire = false;
        }
    }
    private void cronosAttack()
    {
        //------------- Modo combate disparos
        if (modocombate == 0) {
            if (contadorbalas <= 3) {
                Vector2 v = this.transform.localPosition;
                v.x /= 2;
                v.x += 0.1f;
                v.y /= 2;
                GameObject referencia = Instantiate(bala, v, this.transform.localRotation) as GameObject;
                referencia.transform.parent = dad.transform;
                contadorbalas += contadorbalas + 1;
				GetComponent<AudioSource>().Play();

                if (contadorbalas == 3)
                {
                    tiempoinicial = Time.time;
                }
            }
            else
            {
                if (Time.time >= tiempoinicial + delay)
                {
                    contadorbalas = 0;
                }
            }
        }
        //------------- Modo combate espada
        if (modocombate == 1)
        {
            if (contadorespadazos != 1)
            {
                Vector2 v = this.transform.localPosition;
                v.x = 0.02f;
                Instantiate(bala, v, this.transform.localRotation);
                contadorespadazos += contadorespadazos + 1;
                tiempoinicial = Time.time;
				GetComponent<AudioSource>().Play();
            }
            else
            {    
                if (Time.time >= tiempoinicial + delaygolpe)
                {
                    contadorespadazos = 0;
                }
            }
        }
        //------------- Modo combate garrazos
        if (modocombate == 2)
        {
            if (contadorgarrazos < 2)
            {
                Vector2 v = this.transform.localPosition;
                v.x = 0.02f;
                Instantiate(bala, v, this.transform.localRotation);
                contadorgarrazos += contadorgarrazos + 1;
				GetComponent<AudioSource>().Play();
                if (contadorgarrazos == 2) {
                    tiempoinicial = Time.time;
                }       
            }
            else
            {
                if (Time.time >= tiempoinicial + delaygolpe)
                {
                    contadorgarrazos = 0;
                }
            }
        }
    }
}
