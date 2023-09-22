using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace GFA.TDS.BoosterSystem.Editör
{
    
    [CustomEditor(typeof(BoosterContainer))]
    public class BoosterContainerEditor : UnityEditor.Editor
    {
        private Booster _booster;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            _booster= EditorGUILayout.ObjectField(_booster,typeof(Booster),false)as Booster;


            if (GUILayout.Button("Add")&& _booster)
            {
                (target as BoosterContainer).AddBooster(_booster);
            }
            
        }
    }
}
