using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/SingleShot")] // The name that appears on right click -> create -> patterns
public class PatternSingleShot : BulletPattern
{
    public float speed = 5f;

    public override IEnumerator Execute(BulletEmitter emitter)
    {

        // "Up" here is relative to the parent emitter i.e where it is facing

        Vector2 dir = emitter.transform.up;

        BulletSystem.Instance.Spawn(emitter.transform.position, dir * speed);

        yield break;
    }
}
