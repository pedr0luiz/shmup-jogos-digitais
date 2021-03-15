using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolantBehaviour : SteerableBehaviour, IDamageable
{
    // Start is called before the first frame update
    float angle = 0;

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;
        Thrust(0, Mathf.Cos(angle));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
