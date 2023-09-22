using System;
using GFA.TDS.BoosterSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GFA.TDS.UI.Popups
{
    public class BoosterSelectionPopup : Popup
    {
        [SerializeField] private BoosterList _boosterList;

        [SerializeField] private BoosterCard _boosterCardPrefab;
        [SerializeField] private Transform _container;

        private void Start()
        {
          Open();
        }

        protected override void OnOpened()
        {
            base.OnOpened();

            var boosters = new Booster[3];

            for (int i = 0; i < 3; i++)
            {
                var randomBooster = _boosterList.Get(Random.Range(0, _boosterList.Lenght));
                var inst = Instantiate(_boosterCardPrefab, _container);

                inst.Booster = randomBooster;
            }
        }
    }
}
