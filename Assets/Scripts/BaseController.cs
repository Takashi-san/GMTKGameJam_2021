using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] float _maxVelocity = 1;
    [SerializeField] float _acceleration = 1;
    
    Rigidbody2D _rb2d;
    float _input = 0;

    void Start () 
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        UpdateInput();
    }

    void FixedUpdate()
    {
        MoveBase();
    }

    void UpdateInput() 
    {
        _input = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            _input += -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _input += 1;
        }
    }

    void MoveBase()
    {
        if (_input == 0) 
        {
            _rb2d.velocity = Vector2.MoveTowards(_rb2d.velocity, Vector2.zero, _acceleration * Time.fixedDeltaTime);            
        }
        else
        {
            _rb2d.velocity += Vector2.right * _input * _acceleration * Time.fixedDeltaTime;
        }
        _rb2d.velocity = Vector2.ClampMagnitude(_rb2d.velocity, _maxVelocity);
    }
}
