using UnityEngine;

public class HotZone : MonoBehaviour
{
    private float timer = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer += 1;
            if (timer % 50 == 0)
            {
                Boss_Data.health--;
                Debug.Log("Player is in hot zone, health: " + Boss_Data.health);
            }
        }
    }
}
