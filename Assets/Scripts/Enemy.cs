﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public ScoreScript score;

    public GameObject enemy;
    public Animator anim;
    private Lock_On _lockOn;
    IsTargeted _targeted;


    private Vector2 curPos;
    private Vector2 lastPos;


    private bool moving = false;
    private bool hurt = false;
    [SerializeField]private int health = 30;
    private int damage = 4;
    private int curHealth;


    // Use this for initialization
    void Start()
    {
        score = FindObjectOfType<ScoreScript>();
        curHealth = health;
        _lockOn = FindObjectOfType<Lock_On>();
        _targeted = FindObjectOfType<IsTargeted>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if object is moving
        curPos = enemy.transform.position;
        if (curPos == lastPos)
        {
            anim.SetBool("Moving", moving);
        }
        else
        {
            anim.SetBool("Moving", !moving);
        }
        //set last position to current position
        lastPos = curPos;

        //check if enemy is hit by turret
        if (curHealth < health)
        {
            anim.SetBool("Hurt", !hurt);
        }
        else
        {
            anim.SetBool("Hurt", hurt);
        }

        // check if enemy dies
        if (health <= 0)
        {
            _lockOn.target = null;
            //_targeted.isTargeted = false;
            // destroy the unit
            Destroy(gameObject);
            AddScore();
        }
    }

    void AddScore()
    {
        // add score on kill
        score.scoreValue += 1;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "arrow(Clone)")
        {
            health -= damage;
            curHealth = health;
        }
        else
        {
            return;
        }
    }
}
