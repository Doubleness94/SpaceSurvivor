using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float maxHealth; // 시작 체력
    public float health { get; protected set; } //현재 체력
    public bool dead { get; protected set; } //사망상태
    public event Action onDeath; //사망시 발동할 이벤트

    protected virtual void OnEable()
    {
        dead = false;
        health = maxHealth;
    }

    public virtual void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            //사망
        }
    }

    public virtual void RestoreHealth(float newHealth)
    {
        if (dead)
            return;

        health += newHealth;
    }

    public virtual void Die()
    {
        if(onDeath != null)
            onDeath();

        dead = true;
    }
}
