using UnityEngine;

public class FireBallSpawner : MonoBehaviour
{
    public Rigidbody Fireballs;

    [SerializeField]
    public Transform damage;
    public float speed = 5.0f;
    public int cost = 10;
    public int playerhealth = 100;
    
   void Cast()
    {
        Rigidbody Fireball = (Rigidbody)Instantiate(Fireballs, transform.position, transform.rotation);
        Fireball.velocity = transform.forward * speed;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cast();   
        }
    }
    //need scriptable objects done first
    /*private void OnCollisionEnter(Collision collision)
    {
       // if (col.gameObject.tag.Equals("Player"))
        {

        }
    }*/
}