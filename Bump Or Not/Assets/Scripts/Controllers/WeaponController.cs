using UnityEngine;
using Views;

namespace Controllers
{
    public class WeaponController
    {
        App app;
        public WeaponController(App app)
        {
            this.app = app;
            PlayerView.OnPlayerFireBeingHeld += OnPlayerFireBeingHeld;
        }
        
        private void OnPlayerFireBeingHeld(PlayerView playerView, Vector3 destination)
        {
            app.Views.WeaponView.Fire(destination);
        }
    }
}