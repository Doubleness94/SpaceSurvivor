using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPooling : MonoBehaviour
{
    public static WeaponPooling instance;

    public GameObject[] weaponPrefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        instance = this;
        pools = new List<GameObject>[weaponPrefabs.Length];
    }

    private void Init()
    {
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int i)
    {
        GameObject select = null;

        foreach(GameObject weapon in pools[i])
        {
            if (!weapon.activeSelf)
            {
                select = weapon;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(weaponPrefabs[i], transform);
            pools[i].Add(select);
        }

        return select;
    }
}
