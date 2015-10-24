using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /*
        enemyCharacter = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(transform.localPosition, enemyCharacter.transform.localPosition);
        Debug.Log(angle);
        */
        this.transform.Rotate(new Vector3(0F, 0F, anguloEntreDosPuntos(this.transform.localPosition, Enemy.positionAttack)));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right);
    }

    private float anguloEntreDosPuntos(Vector3 a, Vector2 b)
    {
        return Mathf.Atan2(b.y-a.y, b.x-a.x);
    }

    /*
function AngleDeg(x1, y1, x2, y2:double):double;
begin
  result:=RadToDeg(ArcTan2(y2-y1, x2-x1));
  if result<0 then result:=360.0+result;
  if result>=360.0 then result:=0;
    end;
    */
    public int liveSeconds = 5;
    public GameObject enemyCharacter;
}

