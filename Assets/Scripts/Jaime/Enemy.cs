using UnityEngine;
using System.Collections;
using System.Threading;

public class Enemy : MonoBehaviour {

    public static float delay;
    public float nextAtack;

    public void Start() {
        switch (enemies) {
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
        delay = 3F;
        nextAtack = Time.time + delay;
    }

    public void Update() {

        if ( nextAtack <= Time.time )
        {
            attack();
            nextAtack = Time.time + delay;
        }

    }

    public static Vector3 positionAttack; //(Vector3 posicionObjetivo)

    public GameObject enemyCharacter;
    public GameObject bullet;
    public int damage;
    public int lives;
    public float attackSpeed;
    public int weapon; // (0 mele, 1 shot)
    public int enemies; //(0 elder, 1 adult, 2 child, 3 sperm)
    public float shotScale; // Cuando falle el disparo que la bala se aleje del objetivo.
    public float meleScale; // Distancia máxima para hacer un ataque a melé. 

    public Vector3 getPosition()
    {
        Vector3 position = new Vector3();
        position.x = this.transform.localPosition.x;
        position.y = this.transform.localPosition.y;
        return position;
    }
    public Vector3 getEnemyPosition()
    {
        Vector3 position = new Vector3();
        position.x = enemyCharacter.transform.localPosition.x;
        position.y = enemyCharacter.transform.localPosition.y;
        return position;
    }
    
    private void elderInitialization() {
    }
    private void adultInitialization() {
    }
    private void childInitialization() {
    }
    private void spermInitialization() {
    }

    public void attack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        switch (enemies) {
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
        if (Mathf.Abs((Mathf.Min(this.getEnemyPosition().x, this.getPosition().x)) - Mathf.Abs(Mathf.Max(this.getEnemyPosition().x, this.getPosition().x))) <= meleScale
                && this.getEnemyPosition().y == this.getPosition().y)
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
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().elderMeleAttack();
    }
    private void elderShotAttack()
    {
        int aim = 20;
        attackPositionStrategy(aim); //positionAttack
        Instantiate(bullet, this.transform.localPosition, this.transform.localRotation);
        //this.GetComponent<AnimacionJuego>().elderShotAttack();
    }

    private void adultAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.getEnemyPosition().x, this.getPosition().x)) - Mathf.Abs(Mathf.Max(this.getEnemyPosition().x, this.getPosition().x))) <= meleScale
                && this.getEnemyPosition().y == this.getPosition().y)
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
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().adultMeleAttack();
    }
    private void adultShotAttack()
    {
        int aim = 40;
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().adultShotAttack();
    }

    private void childAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.getEnemyPosition().x, this.getPosition().x)) - Mathf.Abs(Mathf.Max(this.getEnemyPosition().x, this.getPosition().x))) <= meleScale
                && this.getEnemyPosition().y == this.getPosition().y)
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
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().childMeleAttack();
    }
    private void childShotAttack()
    {
        int aim = 60;
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().childShotAttack();
    }

    private void spermAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if (Mathf.Abs((Mathf.Min(this.getEnemyPosition().x, this.getPosition().x)) - Mathf.Abs(Mathf.Max(this.getEnemyPosition().x, this.getPosition().x))) <= meleScale
                && this.getEnemyPosition().y == this.getPosition().y)
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
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().spermMeleAttack();
    }
    private void spermShotAttack()
    {
        int aim = 80;
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().spermShotAttack();
    }

    private void attackPositionStrategy(int aim)
    {
        Vector3 positionAttack = new Vector3();

        int randValue = (int)Random.Range(1, 101);
        if (aim <= randValue)
        {
            positionAttack = this.getEnemyPosition();
        }
        else
        {
            randValue = (int)Random.Range(0, 4);
            switch (randValue)
            {
                case 0:
                    positionAttack.x = this.getEnemyPosition().x + shotScale;
                    positionAttack.y = this.getEnemyPosition().y + shotScale;
                    break;
                case 1:
                    positionAttack.x = this.getEnemyPosition().x + shotScale;
                    positionAttack.y = this.getEnemyPosition().y - shotScale;
                    break;
                case 2:
                    positionAttack.x = this.getEnemyPosition().x - shotScale;
                    positionAttack.y = this.getEnemyPosition().y + shotScale;
                    break;
                case 3:
                    positionAttack.x = this.getEnemyPosition().x + shotScale;
                    positionAttack.y = this.getEnemyPosition().y + shotScale;
                    break;
            }
        }
    }

    public ImagePosition move() {
        switch (enemies)
        {
            case 0: // Elder
                //elderMove();
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
        return new ImagePosition();
    }
}
