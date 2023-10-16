using GFA.TDS.UI.Pagination;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GFA.TDS.UI.Pages
{
    public class GamePage : Page
    {
        [SerializeField] private Button _playbutton;
        
        protected override void OnOpened()
        {
        _playbutton.onClick.AddListener(OnPlayButtonClicked); 
        }

        protected override void OnClosed()
        {
            _playbutton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            SceneManager.LoadScene(1);
        }
    }
}
