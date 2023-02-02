using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using MatchAll.Environment;

namespace MatchAll.Settings
{
    [CreateAssetMenu(fileName = "GameEndMessageSettings", menuName = "Game Settings/Game End Message Settings")]
    public class GameEndMessageSettings : ScriptableObject
    {
        [Serializable]
        private class MessageDescriptor
        {
            public GameEndType type;
            public string messageText;
            public AssetReference imageReference;
            public string buttonText;
        }
        [SerializeField]
        private MessageDescriptor[] descriptors;

        public string MessageText(GameEndType type)
        {
            return descriptors.FirstOrDefault(d => d.type == type)?.messageText;
        }
        public AssetReference ImageReference(GameEndType type)
        {
            return descriptors.FirstOrDefault(d => d.type == type)?.imageReference;
        }
        public string ButtonText(GameEndType type)
        {
            return descriptors.FirstOrDefault(d => d.type == type)?.buttonText;
        }
    }
}
