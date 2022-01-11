using UnityEngine;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetScoreText(float scoreAmount)
    {
        scoreText.text = ((int)scoreAmount).ToString();
    }
}