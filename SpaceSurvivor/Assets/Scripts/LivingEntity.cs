using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public float maxHealth; // ���� ü��
    public float health { get; protected set; } //���� ü��
    public bool dead { get; protected set; } //�������
    public event Action onDeath; //����� �ߵ��� �̺�Ʈ

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
            //���
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