using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    public static BulletSystem Instance;

    public Bullet bulletPrefab;

    void Awake()
    {
        Instance = this;
    }

    public Bullet Spawn(Vector2 pos, Vector2 velocity)
    {

        var b = GameObject.Instantiate(bulletPrefab);
        b.transform.position = pos;
        b.Initialize(velocity);
        //Debug.Log("Called initialize");
        return b;
    }

    public void Release(Bullet b)
    {
        b.gameObject.SetActive(false);
    }
}
