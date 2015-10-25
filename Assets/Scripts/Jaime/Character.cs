using UnityEngine;
using System.Collections;
using System.Threading;

public class Character : MonoBehaviour
{

    public float attackDelay = 3F; //Cadencia de disparo
    private float nextAtack;
    private float moveDelay;
    private float nextMove;
    public void Start()
    {
        switch (choosenCharacter)
        {
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
        nextAtack = Time.time + attackDelay;

        moveDelay = moveSpeed;
        nextMove = Time.time + moveDelay;
    }

    private float moveSpeed = 0.20F;
    public void Update()
    {

        if (nextMove <= Time.time)
        {
            move();
            nextMove = Time.time + moveDelay;
        }

        if (nextAtack <= Time.time)
        {
            attack();
            nextAtack = Time.time + attackDelay;
        }

    }

    public GameObject enemyCharacter;
    public GameObject projectile;

    public int choosenCharacter; //(0 elder, 1 adult, 2 child, 3 sperm)
    public float shotScale = 4F; // Cuando falle el disparo que la bala se aleje del objetivo.
    public float meleScale = 2F; // Distancia máxima para hacer un ataque a melé. 
    public float adjustMoveDistance = 1F;

    private void elderInitialization()
    {
    }
    private void adultInitialization()
    {
    }
    private void childInitialization()
    {
    }
    private void spermInitialization()
    {
    }

    public void attack()
    { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        switch (choosenCharacter)
        {
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

    private void elderAttack()
    { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
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
        int aim = 20;
        Vector3 destine = attackLocationStrategy(aim); //positionAttack

        Quaternion rotation;
        if ((destine.x - transform.position.x) >= 0)
        {
            rotation = Quaternion.LookRotation(destine - transform.position, transform.TransformDirection(Vector3.up));
        }
        else
        {
            rotation = Quaternion.LookRotation(destine - transform.position, transform.TransformDirection(Vector3.down));
        }

        Vector3 origin = this.transform.localPosition; //Hace falta saber de donde sale la bala.
        GameObject projectileObject = Instantiate(projectile, origin, new Quaternion(0, 0, rotation.z, rotation.w)) as GameObject;
        projectileObject.GetComponent<Projectile>().Init(destine);
    }

    private void adultAttack()
    { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
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

    private void childAttack()
    { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
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

    private void spermAttack()
    { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
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

    private int predefinedPath;
    private int steps = 20; //4 segundos (moveSpeed 0.20F * 20)
    private int count_steps = 0;
    private bool toCenter = false;
    public void move() //Siempre termina mirando a la izquierda
    {
        //En el random se podría tener en cuenta el tipo de character para hacer unos movimientos u otros
        int randValue = (int)Random.Range(1, 3); //0 goCenter, 1 Predefined1, 2 Predefined2
        if (count_steps <= 0)
        {
            if (toCenter == false)
                predefinedPath = 0;
            else
            {
                predefinedPath = randValue;
            }
            count_steps = steps;
        }
        else
        {
            count_steps--;
        }
        Debug.Log(predefinedPath);

        switch (predefinedPath)
        {
            case 0:
                moveToTheCenter(count_steps);
                break;
            case 1:
                prefedinedPathOne(count_steps);
                break;
            case 2:
                prefedinedPathTwo(count_steps);
                break;
        }
    }

    private void moveToTheCenter(int count_steps)
    {
        switch (count_steps)
        {
            case 0:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 1:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 2:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 3:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 4:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 5:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 6:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 7:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 8:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 9:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 10:
                this.transform.localScale = -this.transform.localScale;
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 11:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 12:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 13:
                this.transform.localScale = -this.transform.localScale;
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 14:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 15:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 16:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 17:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 18:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
            case 19:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
        }
    }
    private void prefedinedPathOne(int count_steps)
    {
        switch (count_steps)
        {
            case 0:
                this.transform.localScale = -this.transform.localScale;
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 1:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 2:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 3:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 4:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 5:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
            case 6:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
            case 7:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
            case 8:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 9:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 10:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 11:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
            case 12:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 13:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 14:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 15:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 16:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 17:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 18:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                GetComponent<MovimientoProtagonista>().andar();
                break;
            case 19:
                GetComponent<MovimientoProtagonista>().noAndar();
                break;
        }
    }
    private void prefedinedPathTwo(int count_steps)
    {
        switch (count_steps)
        {
            case 0:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 1:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 2:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 3:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 4:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 9:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 10:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 11:
                this.transform.Translate(-moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 12:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 13:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 14:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 15:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 16:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 17:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 18:
                this.transform.Translate(moveSpeed * adjustMoveDistance, 0f, 0f);
                break;
            case 19:
                this.transform.localScale = -this.transform.localScale;
                break;
        }
    }
}
