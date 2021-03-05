﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
  
    Animator animator;
    private void Start()
    {
       animator = GetComponent<Animator>();
    }
    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
       float yInput = Input.GetAxis("Vertical");
       float xInput = Input.GetAxis("Horizontal");
       Thrust(xInput, yInput);
       if (yInput != 0 || xInput != 0)
       {
           animator.SetFloat("velocity", 1.0f);
       }
       else
       {
           animator.SetFloat("velocity", 0.0f);
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
   if (collision.CompareTag("enemy"))
   {
       Destroy(collision.gameObject);
       TakeDamage();
   }
}


    
}
