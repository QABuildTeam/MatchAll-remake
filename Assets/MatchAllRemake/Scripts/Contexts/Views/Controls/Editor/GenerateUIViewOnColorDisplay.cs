using System.Collections.Generic;
using UnityEngine;
using UIEditorTools.Editor;
using MatchAll.Views;

namespace MatchAll.Editor
{
    [AppContextGenerationUtility.CodeGeneration]
    public class GenerateUIViewOnColorDisplay : AppContextGenerationUtility.GenerateUIViewOnIValueDisplay<ColorDisplay, Color>
    {
        protected override List<string> UsingClauses => new List<string> { "MatchAll.Views", "UnityEngine" };
    }
}
