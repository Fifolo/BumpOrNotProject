using UnityEngine;
using TMPro;

namespace Views
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI obstaclesDestroyedAmount;
        [SerializeField] private TextMeshProUGUI totalScoreAmount;

        public void Initialize(int obstaclesDestroyed, float totalScore)
        {
            obstaclesDestroyedAmount.text = obstaclesDestroyed.ToString();
            totalScoreAmount.text = totalScore.ToString();
        }
    }
}
