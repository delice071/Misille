using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject missile;
    public float dogma;
    public float dogmaSpeed;

    private void Start()
    {
        InvokeRepeating("Spawn", dogma, dogmaSpeed);
    }

    void Spawn()
    {
        Instantiate(missile, transform.position, Quaternion.identity);
    }

}
