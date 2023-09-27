using System;
using UnityEngine;
using UnityEngine.UI;

namespace GFA.TDS.UI
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class Popup : MonoBehaviour
    {
        private Canvas _canvas;
        private GraphicRaycaster _raycaster;
        public bool IsOpen => _canvas.enabled;

        [SerializeField] private string _name;
        public string Name => _name;


        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _raycaster = GetComponent<GraphicRaycaster>();
        }

        public void Open()
        {
            if(IsOpen) return;
            _canvas.enabled = true;
            _raycaster.enabled = true;
            OnOpened();
        }

       

        public void Close()
        {
            if(!IsOpen) return;
            _canvas.enabled = false;
            _raycaster.enabled = false;
            OnClosed();
        }

        protected virtual void OnClosed()
        {
        }

        protected virtual void OnOpened()
        {
            
        }
    }
}
