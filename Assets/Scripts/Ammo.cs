
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private float lifeTime = 0;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 45 * Time.deltaTime);
        lifeTime = lifeTime + 1 * Time.deltaTime;
        if (lifeTime > 4)
        {
            Destroy(gameObject);
            lifeTime = 0;
        }
    }


}