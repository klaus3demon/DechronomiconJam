using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    private float creationTime;
    void Start()
    {
        creationTime = Time.time;
        //this.transform.TransformDirection(destine);
    }

    private int secondsLife = 5;
    void Update()
    {
        this.transform.Translate(Vector3.right);
        if ((creationTime + secondsLife) <= Time.time)
            Destroy(this.gameObject);
    }

    private Vector3 destine;
    //private Vector3 rotation;
    public void Init(Vector3 destine)
    {
        this.destine = destine;
        //this.rotation = rotation;
    }

}

