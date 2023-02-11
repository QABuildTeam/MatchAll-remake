using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UIEditorTools.Editor;
using MatchAll.Views;

namespace MatchAll.Editor
{
    [AppContextGenerationUtility.CodeGeneration]
    public class GenerateUIViewOnAddressableSpriteDisplay : AppContextGenerationUtility.GenerateUIViewOnIValueDisplay<AddressableSpriteDisplay, AssetReference>
    {
        protected override string DoneCodeTemplate => @"            {0}.Dispose();
";
        protected override List<string> UsingClauses => new List<string> { "MatchAll.Views", "UnityEngine.AddressableAssets" };
    }
}
