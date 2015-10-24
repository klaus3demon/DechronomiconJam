using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(5f, 0f, 0f);
    }
}

