using System.Collections.Generic;
using UIEditorTools.Editor;
using MatchAll.Views;

namespace MatchAll.Editor
{
    [AppContextGenerationUtility.CodeGeneration]
    public class GenerateUIViewOnResolvedShapeObjectDisplay : AppContextGenerationUtility.GenerateUIViewOnIValueDisplay<ResolvedShapeObjectDisplay, ResolvedShapeObject>
    {
        protected override string DoneCodeTemplate => @"            {0}.Dispose();
";
        protected override List<string> UsingClauses => new List<string> { "MatchAll.Views", "UnityEngine.AddressableAssets" };
    }
}
