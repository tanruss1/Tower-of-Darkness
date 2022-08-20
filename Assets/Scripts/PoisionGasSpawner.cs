using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionGasSpawner : MonoBehaviour
{
    public Rigidbody GasBall;

    [SerializeField]
    public Transform damage;
    public float speed = 5.0f;
    public int cost = 5;
    public int playerhealth = 100;
    public float gasDamage = 2;
    public float GasPerSecond = 1.0f;

    void Cast()
    {
        Rigidbody GasBalls = (Rigidbody)Instantiate(GasBall, transform.position, transform.rotation);
        GasBall.velocity = transform.forward * speed;

    }

    void OnGas()
    {
        gasDamage += GasPerSecond * Time.deltaTime;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cast();
        }
        void OnCollisionStay(Collision other)
        {
            if (other.collider.CompareTag("Enemy"))
            {
                OnGas();
            }
        }
    }
}
