using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private float creationTime;
    void Start()
    {
        creationTime = Time.time;
    }

    private int secondsLife = 5;
    void Update()
    {
        this.transform.Translate(Vector3.right * projectileSpeed);
        if ((creationTime + secondsLife) <= Time.time)
            Destroy(this.gameObject);
    }

    public float projectileSpeed;

    private Vector3 destine;
    public void Init(Vector3 destine)
    {
        this.destine = destine;
    }

}

