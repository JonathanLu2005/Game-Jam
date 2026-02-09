using System.ComponentModel;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Velocity;
    public float Lifetime = 10f;

    float timer;

    public void Initialize(Vector2 velocity)
    {
        
        Velocity = velocity;
        timer = 0f;
        //Debug.Log("Inside Initialise Function");
        //Debug.Log(Velocity);
    }

    private void Start()
    {
        //Initialize(new Vector2(5,5));
    }

    void Update()
    {
        transform.position += (Vector3)(Velocity * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer > Lifetime)
            BulletSystem.Instance.Release(this);

    }
}
