using UnityEngine;

public class Weapon_Collide : MonoBehaviour
{
    public int value = -10; // negative to damage, positive to heal
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
        if (collision.CompareTag("Parry Box"))
        {
            Debug.Log("Parried");
        }
        else if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().ModifyHealth(value);
        }
    }
}
