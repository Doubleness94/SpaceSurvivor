using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }
    public State state { get; private set; }
    public Transform fireTrans;
    public float damage;
    public int per = 0;

    public float timeBetFire;
    public float reloadTime;
    public float lastFireTime;

    protected void Awake()
    {

    }  

    protected void OnEnable()
    {
        lastFireTime = 0;
    }

    public void Fire()
    {
        if(Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    private void Shot()
    {

    }

    private void ARshot()
    {        
        GameObject newBullet = WeaponPooling.instance.Get(0);
        newBullet.transform.position = fireTrans.position;
        newBullet.transform.rotation = fireTrans.rotation;
        Rigidbody bulletRigid = newBullet.GetComponent<Rigidbody>();
        bulletRigid.velocity = fireTrans.forward * 50;
        newBullet.GetComponent<Bullet>().Init(damage, per, timeBetFire);
    }
}
