using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenade;
    public Transform caster;
    void Update()
    {
        SpawnGrenade();
    }

    public void SpawnGrenade()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenka = Instantiate(grenade);
            grenka.transform.position = caster.position;
        }
    }
}
