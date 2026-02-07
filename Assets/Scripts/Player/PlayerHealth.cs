using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private Coroutine healRoutine;
    private float healRoutineTimeLeft;
    private Coroutine damageRoutine;
    private float damageRoutineTimeLeft;
    public int startingHealth = 100;
    public int health = 100;
    public int lives = 3;

    public void ModifyHealth(int value) {
        health += value;
        PlayerData.iframesTime = PlayerData.maxIframesTime;
        if (health <= 0) {
            lives--;
            health = startingHealth;
            transform.position = new Vector2(0,0);
        } else if (health >= startingHealth) {
            health = startingHealth;
        }
        Debug.Log("Damaged");
    }

    public void HealOverTimeRoutine(int value, int duration) {
        healRoutineTimeLeft = duration;

        if (healRoutine == null) {
            healRoutine = StartCoroutine(HealOverTime(value));
        }
    }

    IEnumerator HealOverTime(int value) {
        while (healRoutineTimeLeft > 0) {
            ModifyHealth(value);
            if (health >= startingHealth) {
                health = startingHealth;
            } 
            healRoutineTimeLeft -= 1f;
            yield return new WaitForSeconds(1f);
        }

        healRoutine = null;
    }

    public void DamageOverTimeRoutine(int value, int duration) {
        damageRoutineTimeLeft = duration;
        PlayerData.iframesTime = PlayerData.maxIframesTime;

        if (damageRoutine == null) {
            damageRoutine = StartCoroutine(DamageOverTime(value));
        }
    }

    IEnumerator DamageOverTime(int value) {
        while (damageRoutineTimeLeft > 0) {
            ModifyHealth(value);
            if (health <= 0) {
                transform.position = new Vector2(0,0);
                damageRoutine = null;
                yield break;
            }
            damageRoutineTimeLeft -= 1f;
            yield return new WaitForSeconds(1f);
        }

        damageRoutine = null;
    }
}