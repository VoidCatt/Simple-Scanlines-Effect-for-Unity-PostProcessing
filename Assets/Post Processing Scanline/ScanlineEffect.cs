namespace UnityEngine.Rendering.PostProcessing
{
    [System.Serializable]
    [PostProcess(typeof(ScanlineEffectRenderer), PostProcessEvent.AfterStack, "Custom/Scanline Effect")]
    public class ScanlineEffect : PostProcessEffectSettings
    {
        [Range(-1, 1)]
        public FloatParameter scanlineSpeed = new FloatParameter() { value = 0 };

        [Range(0, 1)]
        public FloatParameter scanlineStrength = new FloatParameter() { value = 0 };

        [Range(200, 1000)]
        public IntParameter scanlineCycle = new IntParameter() { value = 200 };
    }

    [UnityEngine.Scripting.Preserve]
    internal sealed class ScanlineEffectRenderer : PostProcessEffectRenderer<ScanlineEffect>
    {
    #region Define
        private static readonly int scanlineSpeed    = Shader.PropertyToID("_ScanlineSpeed");
        private static readonly int scanlineStrength = Shader.PropertyToID("_ScanlineStrength");
        private static readonly int scanlineCycle    = Shader.PropertyToID("_ScanlineCycle");
    #endregion


        public override void Render(PostProcessRenderContext context)
        {
            var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/CRTEffect"));

            sheet.properties.SetFloat(scanlineSpeed, settings.scanlineSpeed);
            sheet.properties.SetFloat(scanlineStrength, settings.scanlineStrength);
            sheet.properties.SetInt(scanlineCycle, settings.scanlineCycle);

            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}