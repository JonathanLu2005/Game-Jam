using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/BurstFire")] // The name that appears on right click -> create -> patterns

public class PatternBurstFire : BulletPattern
{
    public int count = 20;
    public float speed = 5f;
    public float bulletInterval = 0.1f;

    public override IEnumerator Execute(BulletEmitter emitter)
    {

        // "Up" here is relative to the parent emitter i.e where it is facing

        Vector2 dir = emitter.transform.up;

        for (int i = 0; i < count; i++) {
            BulletSystem.Instance.Spawn(emitter.transform.position, dir * speed);
            yield return new WaitForSeconds(bulletInterval);
        }

        yield break;
    }

}
