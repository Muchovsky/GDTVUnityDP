using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] Vector3 speed;

    IObjectPool<Bullet> bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        bulletPool.Release(this);
    }
}