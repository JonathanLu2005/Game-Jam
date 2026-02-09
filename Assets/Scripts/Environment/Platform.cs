using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
       
    // Code to destroy platform after certain duration
    public void SetTimer(float duration)
    {
        Invoke(nameof(DestroySelf), duration);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
