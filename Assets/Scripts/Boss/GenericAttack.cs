using UnityEngine;

public class GenericAttack : MonoBehaviour 
{
    // positive to heal, negative to take health
    public int dmg = -1;
    public int duration = 5;

    void Start() {

    }

    void Update() {

    }

    /*
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerMovement>().ModifyHealth(value);
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerMovement>().HealOverTimeRoutine(value, duration);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHealth>().DamageOverTimeRoutine(value, duration);
            Destroy(gameObject);
        }
    }
    */

    //private void OnTriggerEnter2D(Collider2D collision) {
    //    if (collision.CompareTag("Player")) {
    //        collision.GetComponent<PlayerMovement>().SpeedOverTimeRoutine(value, duration); // Change speed of player
    //        Destroy(gameObject);
    //    }
    //}
}