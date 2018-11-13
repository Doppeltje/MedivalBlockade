using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Changer : MonoBehaviour
{

    public float redfade = 1;
    public float bluefade = 1;
    public float greenfade = 1;
    public float opacity = 1;

    public Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color fade = new Color(redfade, bluefade, greenfade, opacity);

        rend.material.color = fade;


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.name == "arrow(Clone)")
        {
            bluefade = bluefade - .2f;
            greenfade = greenfade - .2f;



        }
    }


}
