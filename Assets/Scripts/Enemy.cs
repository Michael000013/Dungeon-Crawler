using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy:MonoBehaviour
{
    [Header("Movement")]

    public float speed = 3f;

    [SerializeField] private float Attack_Damage = 10f;

    [SerializeField] private float Attack_Speed = 1f;

    private float Can_Attack;

    [Header("Health")]

    private float Health;

    private Transform target;
    [SerializeField] private float maxHealth;


    private void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        Health -= dmg;
        Debug.Log("Enemy Health: " + Health);

        if(Health <= 0)
        {
            Destroy(gameObject);
        }
    }

   

    private void FixedUpdate()
    {
        if(target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Attack_Speed <= Can_Attack)
            {
                other.gameObject.GetComponent<Player_Health>().UpdateHealth(-Attack_Damage);

                Can_Attack = 0f;
            }
            else
            {
                Can_Attack += Time.deltaTime;
            }

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(Attack_Speed <= Can_Attack)
            {
                other.gameObject.GetComponent<Player_Health>().UpdateHealth(-Attack_Damage);
                Can_Attack = 0f;
            }
            else
            {
                Can_Attack += Time.deltaTime;
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;

        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
           
        }
    }


}