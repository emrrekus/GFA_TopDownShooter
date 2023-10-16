using System;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TDS.UI.Pagination
{
    public class TabView : MonoBehaviour
    {
        [SerializeField] private PageTabButtonPair[] _pageTabButtonPair;

        [SerializeField] private Router _router;
        

        [System.Serializable]
        public class PageTabButtonPair
        {
            public Page Page;
            public Button Button;
        }

        private void Awake()
        {
            foreach (var pair in _pageTabButtonPair)
            {
                pair.Button.onClick.AddListener(() =>
                {
                    //request router to open the page
                    _router.ActivePage = pair.Page;
                });
            }
        }
    }
}