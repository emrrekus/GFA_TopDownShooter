using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GFA.TDS
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] private int _sceneToLoadIndex;
        [SerializeField] private Image _progressBar;
        

        private IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();
            var operation = SceneManager.LoadSceneAsync(_sceneToLoadIndex);
            while (operation.isDone == false)
            {
                _progressBar.fillAmount = operation.progress;
                yield return null;
            }
        }
    }
}
