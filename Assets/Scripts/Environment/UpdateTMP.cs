using TMPro;
using UnityEngine;

public class UpdateTMP : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = Boss_Data.health.ToString();
    }
}

