using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    public int value = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("[BULLET COLLIDE]");
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().ModifyHealth(value);
        }
    }
}
