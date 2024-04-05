using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;
    public float maxLifeTime;

    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void Init(float damage, int per, float lifeTime)
    {
        this.damage = damage;
        this.per = per;
        this.maxLifeTime = lifeTime;
        Invoke("Disable", maxLifeTime);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }    
}
