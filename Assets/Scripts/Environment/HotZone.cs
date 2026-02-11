using UnityEngine;
using UnityEngine.SceneManagement;

public class HotZone : MonoBehaviour
{
    private float timer = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer += 1;
            if (timer % 25 == 0)
            {
                Boss_Data.health--;
                if (Boss_Data.health <= 0)
                {
                    SceneManager.LoadScene("Win");
                }
            }
        }
    }
}
