using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, Controls.IPlayer_MapActions
{
    [SerializeField] private float speed = 5.0f;
    private Vector3 _direction;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        
        rb.AddForce(new Vector3(_direction.x, 0, _direction.y) * speed, ForceMode.Force);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        _direction = context.ReadValue<Vector2>();
        

    }
}
