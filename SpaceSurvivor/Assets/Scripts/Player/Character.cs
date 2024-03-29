using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Scanner scanner;
    public PlayerMovement player;
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    private void FixedUpdate()
    {
        Fire();
        anim.SetBool("isMove", player.isMove);        
    }

    private void Fire()
    {
        if(scanner.nearestTarget == null)
        {
            transform.LookAt(transform.position + player.moveVec);
            return;
        }

        Vector3 targetPos = scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir.y = 0;
        dir = dir.normalized;

        transform.rotation = Quaternion.FromToRotation(Vector3.forward, dir);
    }
}
