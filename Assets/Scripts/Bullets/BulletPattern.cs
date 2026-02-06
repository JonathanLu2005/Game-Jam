using System.Collections;
using UnityEngine;


/**
 * This is an abstract class, extended/inherited by all bullet patterns. Bullet patterns are owned by Bullet Emitters.
 * Think of these as what type of attack the emitter/gun will shoot e.g. a single shot, a burst fire, a spiral attack.
 */
[CreateAssetMenu(fileName = "BulletPattern", menuName = "Scriptable Objects/BulletPattern")]
public abstract class BulletPattern : ScriptableObject
{
    public abstract IEnumerator Execute(BulletEmitter emitter);
}
