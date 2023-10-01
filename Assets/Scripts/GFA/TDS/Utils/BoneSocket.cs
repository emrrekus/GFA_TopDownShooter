using UnityEngine;

namespace GFA.TDS.Utils
{
    public class BoneSocket : MonoBehaviour
    {
        [SerializeField]
        private string _socketName;

        public string SocketName => _socketName;
    }
}
