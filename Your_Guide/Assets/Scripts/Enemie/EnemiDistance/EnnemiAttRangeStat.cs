using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiAttRangeStat : MonoBehaviour
{
    private EnemiControler eControler;

    [SerializeField] private float attaqueCooldown;
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float vitesseProjectile;


    private void Awake()
    {
        eControler = transform.GetComponent<EnemiControler>();
    }


    public void SpawnProjectile()
    {

    }



}
