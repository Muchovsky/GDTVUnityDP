using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;

    IObjectPool<Bullet> bulletPool;

    void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease, OnDestroyBullet, maxSize: 3);
    }

    Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }
}