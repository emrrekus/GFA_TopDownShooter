using GFA.TDS.UI.Pagination;
using UnityEngine;

namespace GFA.TDS.UI.Pages
{
    public class ArmoryPage : Page
    {
        
        [SerializeField] private Animator _animator;
        protected override void OnOpened()
        {  
            _animator.Play("Armory Screen");
        }

        protected override void OnClosed()
        {
        }
    }
}