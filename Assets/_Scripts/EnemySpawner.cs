using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public GameObject enemy_ship;
  public GameObject enemy_rock;
  GameManager gm;
    public float shipSpawnDelay = 3.0f;
    private float _lastShipSpawnTimestamp = 0.0f;

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();
  }

  public void Construir()
  {
    foreach (Transform child in transform) {
        GameObject.Destroy(child.gameObject);
    }

    GameObject[] objs = GameObject.FindGameObjectsWithTag("enemy");

    foreach (GameObject child in objs) {
        GameObject.Destroy(child.gameObject);
    }

    for(int i=0; i<9; i++){
        Vector3 posicao = new Vector3(7, -i);
        Instantiate(enemy_ship, posicao, Quaternion.identity, transform);

        Vector3 posicao_rock = new Vector3(8, -i);
        Instantiate(enemy_rock, posicao_rock, Quaternion.identity, transform);
    }
  }
    void Update()
    {
        if (Time.time - _lastShipSpawnTimestamp < shipSpawnDelay) return;
        else if(gm.is_paused){
            _lastShipSpawnTimestamp = Time.time;
            return;
        }
       _lastShipSpawnTimestamp = Time.time;
       Vector3 posicao = new Vector3(Random.Range(0, 7), Random.Range(0, -8));
       Instantiate(enemy_ship, posicao, Quaternion.identity, transform);
       Vector3 posicao_rock = new Vector3(Random.Range(-7, 7), Random.Range(0, -8));
       Instantiate(enemy_rock, posicao_rock, Quaternion.identity, transform);
    }
}
