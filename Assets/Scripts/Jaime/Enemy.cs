using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

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
    }

    public void Update() {

    }

    private float positionX;
    private float positionY;
    private GameObject enemyCharacter;
    private float enemyPositionX;
    private float enemyPositionY;

    public int damage;
    public int lives;
    public float attackSpeed;
    public Vector3 positionAttack; //(Vector3 posicionObjetivo)
    public int weapon; // (0 mele, 1 shot)
    public int enemies; //(0 elder, 1 adult, 2 child, 3 sperm)
    public float shotScale; // Cuando falle el disparo que la bala se aleje del objetivo.
    public float meleScale; // Distancia máxima para hacer un ataque a melé. 

    public void getPositionX() { positionX = this.transform.position.x; }
    public void getPositionY() { positionY = this.transform.position.y; }
    public void getEnemyPositionX() { enemyPositionX = enemyCharacter.transform.position.x; }
    public void getEnemyPositionY() { enemyPositionY = enemyCharacter.transform.position.y; }

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
        if ((Mathf.Min(enemyPositionX, positionX) - Mathf.Max(enemyPositionX, positionX)) <= meleScale
                && enemyPositionY == positionY)
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
    private void elderShotAttack() {
        int aim = 20;
        attackPositionStrategy(aim);
        //this.GetComponent<AnimacionJuego>().elderShotAttack();
    }

    private void adultAttack() { //(Vector3 posicionObjetivo, float velcidadAtaque, int daño)
        if ((Mathf.Min(enemyPositionX, positionX) - Mathf.Max(enemyPositionX, positionX)) <= meleScale
                && enemyPositionY == positionY)
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
        if ((Mathf.Min(enemyPositionX, positionX) - Mathf.Max(enemyPositionX, positionX)) <= meleScale
                && enemyPositionY == positionY)
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
        if ((Mathf.Min(enemyPositionX, positionX) - Mathf.Max(enemyPositionX, positionX)) <= meleScale
                && enemyPositionY == positionY)
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
            positionAttack.x = enemyPositionX;
            positionAttack.y = enemyPositionY;
        }
        else
        {
            randValue = (int)Random.Range(0, 4);
            switch (randValue)
            {
                case 0:
                    positionAttack.x = enemyPositionX + shotScale;
                    positionAttack.y = enemyPositionY + shotScale;
                    break;
                case 1:
                    positionAttack.x = enemyPositionX + shotScale;
                    positionAttack.y = enemyPositionY - shotScale;
                    break;
                case 2:
                    positionAttack.x = enemyPositionX - shotScale;
                    positionAttack.y = enemyPositionY + shotScale;
                    break;
                case 3:
                    positionAttack.x = enemyPositionX + shotScale;
                    positionAttack.y = enemyPositionY + shotScale;
                    break;
            }
        }
    }

    public ImagePosition move() {
        switch (enemies)
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
        return new ImagePosition();
    }
}
