using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileTransform;
    [SerializeField] private InputActionReference fire;
    [SerializeField] private ProjectilePool pool;

    [SerializeField] private float fireRate = 0.3f;

    private float nextFireTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fire.action.IsPressed() && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnEnable()
    {
        fire.action.started += FireStarted;
        fire.action.canceled += FireCanceled;
    }

    private void OnDisable()
    {
        fire.action.started -= FireStarted;
        fire.action.canceled -= FireCanceled;
    }

    private void FireStarted(InputAction.CallbackContext context)
    {
        // Optional: Handle the initial press if needed
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    private void FireCanceled(InputAction.CallbackContext context)
    {
        // Optional: Handle the release if needed
    }

    private void Fire()
    {
        pool.Shoot(projectileTransform);
    }
}
