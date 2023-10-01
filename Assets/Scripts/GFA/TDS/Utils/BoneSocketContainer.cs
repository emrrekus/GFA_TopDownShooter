using System;
using UnityEngine;

namespace GFA.TDS.Utils
{
    public class BoneSocketContainer : MonoBehaviour
    {
        private BoneSocket []_sockets;

        private void Awake()
        {
           _sockets = GetComponentsInChildren<BoneSocket>();
        }


        public bool TryGetSocket(string socketName, out Transform socket)
        {
            var x = GetSocket(socketName);
            if (x)
            {
                socket = x;
                return true;
            }

            socket = null;
            return false;
        }
        public Transform GetSocket(string socketName)
        {
            foreach (var so in _sockets)
            {
                if (so.SocketName == socketName)
                {
                    return so.transform;
                }
            }

            return null;
        }
    }
}
