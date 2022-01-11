using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private Button startButton;

        private void Awake()
        {
            if (gameView)
                startButton.onClick.AddListener(gameView.StartGame);

            else Debug.LogError($"{name}, gameView not assigned");
        }
    }
}
