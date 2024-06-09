using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace UnityEditor.Rendering.PostProcessing
{
    [PostProcessEditor(typeof(ScanlineEffect))]
    public class ScanlineEffectEditor : PostProcessEffectEditor<ScanlineEffect>
    {
        private SerializedParameterOverride scanlineSpeed;
        private SerializedParameterOverride scanlineStrength;
        private SerializedParameterOverride scanlineCycle;

        public override void OnEnable()
        {
            scanlineSpeed    = FindParameterOverride(x => x.scanlineSpeed);
            scanlineStrength = FindParameterOverride(x => x.scanlineStrength);
            scanlineCycle    = FindParameterOverride(x => x.scanlineCycle);
        }

        public override void OnInspectorGUI()
        {
            EditorUtilities.DrawHeaderLabel("Scanline Effect");

            PropertyField(scanlineSpeed, new GUIContent("Speed"));
            PropertyField(scanlineStrength, new GUIContent("Strength"));
            PropertyField(scanlineCycle, new GUIContent("Cycle"));
        }
    }
}