using System.Collections;
using UnityEngine;


/**
 * A class for firing BulletPatterns. Treat BulletEmitters like *guns*, they can have different fire rates and shoot different patterns/attacks,
 * but do NOT change their position/direction directly. If you want to change a gun's direction, it needs to be picked up
 * by something. Attach to a parent to control position and direction.
 */
public class BulletEmitter : MonoBehaviour
{
    public BulletPattern pattern;
    private float fireRatePerSecond = 1f;

    public void setFireRatePerSecond(float f)
    {
        fireRatePerSecond = f;
    }

    void Start()
    {
        StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
    {
        
        // Don't fire if the fireRate is set to 0 or a negative
        float emitInterval = fireRatePerSecond > 0?  1f / fireRatePerSecond : 0;
        while (emitInterval > 0)
        {
            yield return new WaitForSeconds(0.2f);
            yield return StartCoroutine(pattern.Execute(this));
            yield return new WaitForSeconds(emitInterval);
        }
    }
}
