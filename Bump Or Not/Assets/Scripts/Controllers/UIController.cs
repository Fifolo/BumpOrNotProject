using Models;
using Views;

namespace Controllers
{
    public class UIController
    {
        UIView uiView;
        ScoreModel scoreModel;
        public UIController(UIView uiView, ScoreModel scoreModel)
        {
            this.uiView = uiView;
            this.scoreModel = scoreModel;

            GameModel.OnGameStart += GameModel_OnGameStart;
            GameModel.OnGamePaused += OnGamePaused;
            GameModel.OnGameUnPaused += OnGameUnPaused;
            GameModel.OnGameOver += OnGameOver;

            ScoreModel.OnCurrentScoreChanged += OnCurrentScoreChanged;

            uiView.Initialize();
            uiView.DisableViews();
            uiView.SwitchToMainMenuView();
        }

        private void OnCurrentScoreChanged(float currentScore) => uiView.UpdateScore(currentScore);
        private void GameModel_OnGameStart() => uiView.SwitchToInGameView();
        private void OnGamePaused() => uiView.SwitchToPauseViewView();
        private void OnGameUnPaused() => uiView.SwitchToInGameView();
        private void OnGameOver() => uiView.SwitchToGameOverView(scoreModel.ObstaclesDestroyed, scoreModel.GameScore);
    }
}
