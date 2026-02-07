using UnityEngine;

public class Boss_Look_Player : MonoBehaviour
{
    public bool isFlipped = false;
    public void LookAt(Transform goal)
    {
        if (goal.position.x < transform.position.x && !isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        if (goal.position.x > transform.position.x && isFlipped)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }
}
