using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CatPlayer : MonoBehaviour
{
    public float fuerzaSalto = 10;
    public float velocidad = 10;
   
    public GameObject balaPrefab;
    
    private Rigidbody2D _rb;
    private Animator _anima_personaje;
    private SpriteRenderer _renderer;
    
    private const int derecha = 1;
    private const int izquierda = -1;
    private const int arriba = 1;
    
    private const string _EstadoAnimacion ="Estado";
    private const int  Idle = 0;
    private const int  Run = 1;
    private const int  Jump = 2;
    private const int  Slide = 3;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anima_personaje = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();  
    }
    void Update()
    {
        AnimacionPersonaje(Idle);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        
        //Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazamiento(derecha);
        }
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazamiento(izquierda);
        }
        
        //disparar 
        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar(); 
        }

        //saltar
        if (Input.GetKeyUp(KeyCode.Space))//Cuando suelto la tecla
        {
            _rb.AddForce(Vector2.up * fuerzaSalto , ForceMode2D.Impulse);
        }
        
        
    }
    
    //metodo para desplazarse
    private void Desplazamiento(int position)
    {
        _rb.velocity = new Vector2(velocidad * position, _rb.velocity.y);
        _renderer.flipX = position == izquierda;
        AnimacionPersonaje(Run);
    }
    private void AnimacionPersonaje(int animation)
    {
        _anima_personaje.SetInteger(_EstadoAnimacion, animation);
    }
    private void Disparar()
    {
        var x = transform.position.x;
        var y = transform.position.y-2;
        
        var bulletGo =Instantiate(balaPrefab, new Vector2(x,y), quaternion.identity);

        if (_renderer.flipX)
        {
            var controller = bulletGo.GetComponent<BalaController>();
            controller.Velocidad2 = controller.Velocidad2 * -1;
        }
        
    }

}
