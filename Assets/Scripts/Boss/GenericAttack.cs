using UnityEngine;

public class GenericAttack : MonoBehaviour 
{
    // positive to heal, negative to take health
    public int damage = 50;

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerMovement>().ModifyHealth(damage);
            Destroy(gameObject);
        }
    }
}