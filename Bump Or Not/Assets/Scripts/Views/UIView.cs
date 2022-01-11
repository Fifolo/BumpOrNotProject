using UnityEngine;
using System.Collections.Generic;

namespace Views
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private InGameMenu _inGameMenu;
        [SerializeField] private MainMenu _mainMenu;

        private List<GameObject> views;
        private GameObject _currentView;
        private Transform _transform;
        private void Awake() => _transform = transform;

        public void Initialize()
        {
            if (!_transform) _transform = transform;

            views = new List<GameObject>();
            foreach (Transform child in _transform)
            {
                views.Add(child.gameObject);
            }
        }

        public void DisableViews()
        {
            if (!views.HasItems()) return;

            foreach (GameObject view in views)
            {
                view.SetActive(false);
            }
        }
        private void SwitchView(GameObject toView)
        {
            if (toView != _currentView)
            {
                if (_currentView) _currentView.SetActive(false);

                _currentView = toView;
                _currentView.SetActive(true);
            }
        }
        public void SwitchToMainMenuView() => SwitchView(_mainMenu.gameObject);
        public void SwitchToInGameView() => SwitchView(_inGameMenu.gameObject);
        public void SwitchToPauseViewView() => SwitchView(_pauseMenu.gameObject);
        public void SwitchToGameOverView(int obstaclesDestroyed, float gameScore)
        {
            SwitchView(_gameOverMenu.gameObject);
            _gameOverMenu.Initialize(obstaclesDestroyed, gameScore);
        }
        public void UpdateScore(float currentScore) => _inGameMenu.SetScoreText(currentScore);
    }
}