using UnityEngine;

public class GenericAttack : MonoBehaviour 
{
    public int damage = 50;

    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerMovement>().Damage(damage);
            Destroy(gameObject);
        }
    }
}