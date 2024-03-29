using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : LivingEntity
{
    public float hAxis { get; private set; }
    public float vAxis { get; private set; }
    public float moveSpeed;
    public bool isMove = false;
    private Rigidbody playerRigid;
    public GameObject[] charObjs;
    public List<GameObject>[] charList;

    public Vector3 moveVec;
    public Animator[] anims;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody>();
        anims = GetComponentsInChildren<Animator>();
        charObjs = GameObject.FindGameObjectsWithTag("Character");
        CharAdd();
    }

    private void Update()
    {
        if (dead)
        {
            hAxis = 0;
            vAxis = 0;
            return;
        }

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        if(moveVec != Vector3.zero)
        {
            isMove = true;
        }
        else
        {
            isMove = false;
        }
        
    }

    private void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.V))
        {
            anims = GetComponentsInChildren<Animator>();
            charObjs = GameObject.FindGameObjectsWithTag("Character");
            CharAdd();
        }
    }

    private void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * moveSpeed * Time.deltaTime;
    }

    public void CharAdd()
    {
        CharList();
        Position();
    }

    private void CharList()
    {
        charList = new List<GameObject>[charObjs.Length];
        for(int i = 0; i < charObjs.Length; i++)
        {
            charList[i] = new List<GameObject>();
        }
    }

    private void Position()
    {
        if(charList.Length == 1)
        {
            Transform charTrans = charObjs[0].transform;
            charTrans.localPosition = Vector3.zero;
            charTrans.localRotation = Quaternion.identity;
        }
        if(charList.Length >= 2)
        {
            for(int i = 0; i < charList.Length; i++)
            {
                Transform charTrans = charObjs[i].transform;
                charTrans.localPosition = Vector3.zero;
                charTrans.localRotation = Quaternion.identity;

                Vector3 rotVec = Vector3.up * 360 * i / charList.Length;
                charTrans.Rotate(rotVec);
                charTrans.Translate(charTrans.forward * 1f, Space.World);
            }
        }
    }


    protected override void OnEable()
    {
        base.OnEable(); 
    }

    public override void RestoreHealth(float newHealth)
    {
        base.RestoreHealth(newHealth);
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        if (!dead)
        {
            //사운드?
        }
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    public override void Die()
    {
        base.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        //아이템 습득
        if(!dead)
        {

        }
    }
}
