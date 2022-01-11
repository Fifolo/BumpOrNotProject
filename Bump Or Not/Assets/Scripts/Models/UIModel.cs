using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName ="Models/UIModel")]
    public class UIModel : ScriptableObject
    {
        [SerializeField] GameObject mainMenu;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject gameOverMenu;
        [SerializeField] GameObject inGameMenu;

        public GameObject MainMenu => mainMenu;
        public GameObject PauseMenu => pauseMenu;
        public GameObject GameOverMenu => gameOverMenu;
        public GameObject InGameMenu => inGameMenu;
    }
}