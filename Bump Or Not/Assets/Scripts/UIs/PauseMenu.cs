using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private Button resumeButton;

        private void Awake()
        {
            if (gameView)
                resumeButton.onClick.AddListener(gameView.PauseToggle);

            else Debug.LogError($"{name}, gameView not assigned");
        }
    }
}
