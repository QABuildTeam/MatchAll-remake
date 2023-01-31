using System.Collections.Generic;
using UnityEngine;
using UIEditorTools.Editor;
using MatchAll.Views;

namespace MatchAll.Editor
{
    [GameContextGenerationUtility.CodeGeneration]
    public class GenerateUIViewOnSpriteDisplay : GameContextGenerationUtility.GenerateUIViewOnIValueDisplay<SpriteDisplay, Sprite>
    {
        protected override List<string> UsingClauses => new List<string> { "MatchAll.Views", "UnityEngine" };
    }
}
