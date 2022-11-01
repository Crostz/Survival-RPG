using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Transform current;

    Animator animator;

    float reachRadius = 1;

    float useCooldown = 0.4f;
    float useTimer;

    void Start()
    {
        if (current == null) return;

        animator = current.GetComponent<Animator>();
    }

    void Update()
    {

        useTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && useTimer > useCooldown) 
        {
            UseWeapon();
        }
    }

    private void UseWeapon() 
    {
        animator.Play("swing");

        Collider2D hit = Physics2D.OverlapCircle(current.transform.position, reachRadius);

        if (hit) 
        {
            Debug.Log(hit.transform.name);
        }


    }

}
