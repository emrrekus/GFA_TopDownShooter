using GFA.TDS.Mediators;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TDS.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private PlayerMediator _playerMediator;

        [SerializeField] private Image _fillImage;
        
        private void Update()
        {

            var health = _playerMediator.Health / _playerMediator.Attributes.MaxHealth;
            _fillImage.fillAmount = health;

        }
    }
}

