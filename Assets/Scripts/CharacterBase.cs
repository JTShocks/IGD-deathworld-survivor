using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour, IDamagable
{
    [SerializeField]
    float MaxHealth;
    float health;
    protected Animator animator;
    [SerializeField]
    protected float speed, accel;
    protected Vector2 moveDir;
    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;
    [SerializeField]
    protected List<DamageMod> damageMods = new List<DamageMod>();
    

    protected virtual void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = MaxHealth;
    }
    public virtual void TakeDamage(float damage, DamageType damageType = null)
    {
        
        health -= damage*(1+damageMods.Find(x => x.Equals((DamageType)damageType)).Value);
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public struct DamageMod
{
    [SerializeField]
    DamageType damageType;
    /// <summary>
    ///postive percentage is weakness, negative percentage is resistance 
    /// </summary>
    [SerializeField]
    [Range(-3,3)]
    float percentage;
    public float Value { get { return percentage; } }
    public DamageMod(DamageType damageType,float percentage)
    {
        this.damageType = damageType;
        this.percentage = percentage;
    }
    void AddMod(float value)
    {
        percentage += value;
    }
    /// <summary>
    /// checks if DamageMod is a DamageType
    /// </summary>
    /// <param name="damageType"></param>
    /// <returns></returns>
    public bool Equals(DamageType damageType)
    {
       return this.damageType.Equals(damageType);
    }
}
