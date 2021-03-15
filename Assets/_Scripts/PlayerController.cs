using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject bullet;
    public Transform arma01;
    private float shootDelay = 0.5f;
    private float _lastShootTimestamp = 0.0f;
    private float pup_timer;
    Animator animator;
    private int lifes, pontos;
    public AudioClip shootSFX;
    GameManager gm;

    private void Start()
    {
       animator = GetComponent<Animator>();
       gm = GameManager.GetInstance();
    }
    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        AudioManager.PlaySFX(shootSFX);
       _lastShootTimestamp = Time.time;
        Instantiate(bullet, arma01.position, Quaternion.identity);
    }

    public void TakeDamage()
    {

       if(!gm.is_pup_active) gm.TakeDamage();
       if (gm.vidas <= 0) SceneManager.LoadScene("End");
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
       if(Input.GetKeyDown(KeyCode.Escape)) {
        gm.TogglePause();
       }
       if(gm.is_paused) return;
       if(Input.GetKeyDown(KeyCode.F)) {
        if(gm.ActivatePUP()){
            pup_timer = 0;
        }
       }
       if(gm.is_pup_active){
           pup_timer += Time.deltaTime;
           if(pup_timer > 3){
               gm.DeactivatePUP();
           }
       }
       float yInput = Input.GetAxis("Vertical");
       float xInput = Input.GetAxis("Horizontal");
       Thrust(xInput, yInput);
       if(Input.GetAxisRaw("Jump") != 0)
       {
           Shoot();
       }
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
