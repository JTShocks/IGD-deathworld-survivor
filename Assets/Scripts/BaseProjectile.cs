using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class BaseProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField]
    float damage;
    [SerializeField]
    DamageType damageType;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Launch(float damage,DamageType damageType,Vector2 direction,float speed)
    {
        this.damage = damage;
        this.damageType = damageType;
        rb.velocity = direction * speed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.GetComponent<IDamagable>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
