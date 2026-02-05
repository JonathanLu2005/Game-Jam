using System.Collections.Generic;
using UnityEngine;

public class BulletPool
{
    Queue<Bullet> pool = new Queue<Bullet>();
    Bullet prefab;

    public BulletPool(Bullet prefab, int startCount)
    {
        this.prefab = prefab;
        for (int i = 0; i < startCount; i++)
            AddNew();
    }

    void AddNew()
    {
        var b = GameObject.Instantiate(prefab);
        b.gameObject.SetActive(false);
        pool.Enqueue(b);
    }

    public Bullet Get()
    {
        if (pool.Count == 0)
            AddNew();

        var b = pool.Dequeue();
        b.gameObject.SetActive(true);
        return b;
    }

    public void Release(Bullet b)
    {
        b.gameObject.SetActive(false);
        pool.Enqueue(b);
    }
}
