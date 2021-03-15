using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotEnemyBehaviour : SteerableBehaviour
{

  private Vector3 direction;
  GameManager gm;

  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.CompareTag("enemy")) return;
      Destroy(gameObject);
  }

  void Start()
  {
      Vector3 posPlayer = GameObject.FindWithTag("Player").transform.position;
      direction = (posPlayer - transform.position).normalized;
      gm = GameManager.GetInstance();
  }

  void Update()
  {
      if(gm.is_paused) return;
      Thrust(direction.x, direction.y);
  }

  private void OnBecameInvisible()
  {
      gameObject.SetActive(false);
  }

}