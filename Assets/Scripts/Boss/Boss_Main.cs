using UnityEngine;

public class Boss_Main : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Boss_Data.timeSinceAttack += Time.deltaTime;
    }
}
