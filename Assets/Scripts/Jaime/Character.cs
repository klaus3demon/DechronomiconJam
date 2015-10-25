using UnityEngine;
using System.Collections;
using System.Threading;

public class Character : MonoBehaviour {

    private float attackDelay;
    private float nextAtack;
    private float moveDelay;
    private float nextMove;
    public void Start() {
        switch (choosenCharacter) {
            case 0: // Elder
                elderInitialization();
                break;
            case 1: // Adult
                adultInitialization();
                break;
            case 2: // Child
                childInitialization();
                break;
            case 3: // Sperm
                spermInitialization();
                break;
        }
        attackDelay = 3F;
        nextAtack = Time.time + attackDelay;

        moveDelay = 0.25F;
        nextMove = Time.time + moveDelay;
    }

    private float speed = 0.25f;
    int direction;
    int count_direction = 0;
    public void Update() {

        if ( nextMove <= Time.time)
        {
            int randValue = (int)Random.Range(0, 2); //0 derecha, 1 izquierda
            if (count_direction <= 0)
            {
                direction = randValue;
                count_direction = 4;
            }      
            else
            {
                if (direction == 0)
                {
                    move(0);
                }
                else
                {
                    move(1);
                }
                count_direction--;
            }
			GetComponent<MovimientoProtagonista>().andar();
            nextMove = Time.time + moveDelay;
        }

        if ( nextAtack <= Time.time )
        {
            attack();
            nextAtack = Time.time + attackDelay;
        }

    }

    public GameObject enemyCharacter;

    public int damage;
    public int lives;
    public float attackSpeed;
    public int choosenCharacter ; //(0 elder, 1 adult, 2 child, 3 sperm)
    private float shotScale = 4F; // Cuando falle el disparo que la bala se aleje del objetivo.
    private float meleScale = 2F; // Distancia máxima para hacer un ataque a melé. 
    public GameObject projectile;

    private void elderInitialization() {
    }
    private void adultInitialization() {
    }
    private void childInitialization() {
    }
    private void spermInitialization() {
    }

    public void attack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        switch (choosenCharacter) {
            case 0: // Elder
                elderAttack();
                break;
            case 1: // Adult
                adultAttack();
                break;
            case 2: // Child
                childAttack();
                break;
            case 3: // Sperm
                spermAttack();
                break;
        }
    }

    private void elderAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)) - 
            Mathf.Abs(Mathf.Max(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x))) 
            <= meleScale
            && this.enemyCharacter.transform.localPosition.y == this.transform.localPosition.y)
        {
            elderMeleAttack();
        }
        else
        {
            elderShotAttack();
        }
 
    }
    private void elderMeleAttack()
    {
        int aim = 100;
        //Esperar X tiempo;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().elderMeleAttack();
    }
    private void elderShotAttack()
    {
        int aim = 10;
        Vector3 destine = attackLocationStrategy(aim); //positionAttack

        Quaternion realRotation;

        if ( (destine.x - transform.position.x) >= 0)
        {
            Debug.Log("Destino positivo");
            realRotation = Quaternion.LookRotation(destine - transform.position, transform.TransformDirection(Vector3.up));
        }
        else
        {
            Debug.Log("Destino negativo");
            realRotation = Quaternion.LookRotation(destine - transform.position, transform.TransformDirection(Vector3.down));
        }

        Vector3 origin = this.transform.localPosition; //Hace falta saber de donde sale la bala.
        Quaternion falseRotation = new Quaternion(0F, 0F, 0F, 0F);
        //Vector3 rotation = attackAngle(origin, destine);
        GameObject projectileObject = Instantiate(projectile, this.transform.localPosition, new Quaternion(0, 0, realRotation.z, realRotation.w)) as GameObject;
        projectileObject.GetComponent<Projectile>().Init(destine);
    }

    private void adultAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)) -
            Mathf.Abs(Mathf.Max(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)))
            <= meleScale
            && this.enemyCharacter.transform.localPosition.y == this.transform.localPosition.y)
        {
            adultMeleAttack();
        }
        else
        {
            adultShotAttack();
        }
    }
    private void adultMeleAttack()
    {
        int aim = 100;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().adultMeleAttack();
    }
    private void adultShotAttack()
    {
        int aim = 40;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().adultShotAttack();
    }

    private void childAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)) -
            Mathf.Abs(Mathf.Max(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)))
            <= meleScale
            && this.enemyCharacter.transform.localPosition.y == this.transform.localPosition.y)
        {
            childMeleAttack();
        }
        else
        {
            childShotAttack();
        }
    }
    private void childMeleAttack()
    {
        int aim = 100;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().childMeleAttack();
    }
    private void childShotAttack()
    {
        int aim = 60;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().childShotAttack();
    }

    private void spermAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)) -
            Mathf.Abs(Mathf.Max(this.enemyCharacter.transform.localPosition.x, this.transform.localPosition.x)))
            <= meleScale
            && this.enemyCharacter.transform.localPosition.y == this.transform.localPosition.y)
        {
            spermMeleAttack();
        }
        else
        {
            spermShotAttack();
        }
    }
    private void spermMeleAttack()
    {
        int aim = 100;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().spermMeleAttack();
    }
    private void spermShotAttack()
    {
        int aim = 80;
        attackLocationStrategy(aim);
        //this.GetComponent<AnimacionJuego>().spermShotAttack();
    }

    private Vector3 attackLocationStrategy(int aim)
    {
        Vector3 attackLocation = new Vector3();
        int randValue = (int)Random.Range(1, 101);
        if (aim >= randValue)
        {
            attackLocation.x = this.enemyCharacter.transform.localPosition.x;
            attackLocation.y = this.enemyCharacter.transform.localPosition.y;
        }
        else
        {
            randValue = (int)Random.Range(0, 4);
            Debug.Log(randValue);
            switch (randValue)
            {
                case 0:
                    attackLocation.x = this.enemyCharacter.transform.localPosition.x + shotScale;
                    attackLocation.y = this.enemyCharacter.transform.localPosition.y + shotScale;
                    break;
                case 1:
                    attackLocation.x = this.enemyCharacter.transform.localPosition.x + shotScale;
                    attackLocation.y = this.enemyCharacter.transform.localPosition.y - shotScale;
                    break;
                case 2:
                    attackLocation.x = this.enemyCharacter.transform.localPosition.x - shotScale;
                    attackLocation.y = this.enemyCharacter.transform.localPosition.y + shotScale;
                    break;
                case 3:
                    attackLocation.x = this.enemyCharacter.transform.localPosition.x + shotScale;
                    attackLocation.y = this.enemyCharacter.transform.localPosition.y + shotScale;
                    break;
            }
        }
        return attackLocation;
    }
    /*
    public Vector3 attackAngle(Vector3 origin, Vector3 destine)
    {
        float angle;
        Debug.Log(origin.y);
        if (origin.x >= 0 && origin.y >= 0)
        {
            Debug.Log("+ +");
            angle = Vector3.Angle(origin, destine);
            Debug.Log(angle);
            return new Vector3(0F, 0F, angle);
        }
        else if (origin.x < 0 && origin.y >= 0)
        {
            Debug.Log("- +");
            angle = Vector3.Angle(origin, destine);
            Debug.Log(angle);
            return new Vector3(0F, 180F, angle);
        }
        else if (origin.x < 0 && origin.y < 0)
        {
            Debug.Log("- -");
            angle = Vector3.Angle(origin, destine);
            Debug.Log(angle);
            return new Vector3(0F, 180F, angle);
        }
        else // (origin.x >= 0 && origin.y < 0)
        {
            Debug.Log("+ -");
            angle = Vector3.Angle(origin, destine);
            Debug.Log(angle);
            return new Vector3(0F, 0F, angle);
        }
        
    }
    */
    public void move(int direction) { //0 derecha, 1 izquierda
        switch (choosenCharacter)
        {
            case 0: // Elder
                elderMove(direction);
                break;
            case 1: // Adult
                //adultMove();
                break;
            case 2: // Child
                //childMove();
                break;
            case 3: // Sperm
                //spermMove();
                break;
        }
    }

    public void elderMove(int direction)
    {
        if (direction == 0)
            this.transform.Translate(speed, 0f, 0f);
        else
            this.transform.Translate(-speed, 0f, 0f);
    }
}
