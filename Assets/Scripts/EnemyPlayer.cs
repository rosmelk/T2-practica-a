using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : MonoBehaviour
{
    public float _velocidad  = 4;
    
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer sr;
     
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(_velocidad, _rb.velocity.y);   
    }
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.CompareTag("colision"))
        {
            if (sr.flipX)
            {
                sr.flipX = false;
            }else
            {
                sr.flipX = true;
            }
            _velocidad = _velocidad * -1;
        }
    }
    
}
