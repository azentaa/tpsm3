using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float force = 10;
    public Transform caster;
    public Rigidbody grenadePrefab;
    void Update()
    {
        SpawnGrenade();
    }

    public void SpawnGrenade()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        var grenade = Instantiate(grenadePrefab);
        grenade.transform.position = caster.position;
        grenade.GetComponent<Rigidbody>().AddForce(caster.transform.forward * force);
    }
}
