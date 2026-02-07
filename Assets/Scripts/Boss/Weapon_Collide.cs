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
        if (collision.CompareTag("Parry Box") && PlayerData.iframesTime <= 0)
        {
            Debug.Log("Parried");
            PlayerData.iframesTime = PlayerData.maxIframesTime;
        }
        else if (collision.CompareTag("Player") && PlayerData.iframesTime <= 0)
        {
            collision.GetComponent<PlayerHealth>().ModifyHealth(value);
        }
    }
}
