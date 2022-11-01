using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    Vector3 scale;
    Vector3 pointDirection;
    Vector3 direction;
    float speed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        scale = transform.localScale;
    }

    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;

        GetDirectionToCursor();
        Rotate();
    }

    private void FixedUpdate()
    {

        rb.velocity = direction * speed;

    }

    private void GetDirectionToCursor() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        pointDirection = (mousePos - transform.position).normalized;
    }

    private void Rotate() 
    {
        float mult = pointDirection.x > 0.2f ? 1 : -1;
        Debug.Log(pointDirection);
        transform.localScale = new Vector3(scale.x * mult, scale.y, 0);

    }

}
