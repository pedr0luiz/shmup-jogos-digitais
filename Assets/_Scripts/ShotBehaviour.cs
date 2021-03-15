using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotBehaviour : SteerableBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    void Start()
    {
     gm = GameManager.GetInstance();   
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.is_paused) return;
        Thrust(1, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player")) return;
       IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
       if (!(damageable is null))
       {
           gm.Hit();
           damageable.TakeDamage();
       }
       Destroy(gameObject);
   }
}
