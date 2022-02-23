using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using TMPro.EditorUtilities;

namespace JavaneseToolkit 
{
    public class JT_CreateObjectMenu
    {
        [MenuItem("GameObject/Javanese Toolkit/Javanese ANSI Text (TMP)", false, 10)]
        static void CreateJavaANSITextUGUI(MenuCommand menuCommand)
        {               
            GameObject go = null;

            #if UNITY_EDITOR
                go = ObjectFactory.CreateGameObject("Javanese ANSI Text (TMP)");
                JavaANSITextMeshProUGUI textComponent = ObjectFactory.AddComponent<JavaANSITextMeshProUGUI>(go);
            #else
                go = CreateUIElementRoot("Javanese ANSI Text (TMP)", s_TextElementSize);
                JavaANSITextMeshProUGUI textComponent = go.AddComponent<JavaANSITextMeshProUGUI>();
            #endif
            
            textComponent.color = Color.white;
            textComponent.text = "ancrk";
            textComponent.fontSize = JT_Settings.defaultFontSize;
            textComponent.margin = JT_Settings.defaultMargin;

            if (TMP_Settings.autoSizeTextContainer)
            {
                Vector2 size = textComponent.GetPreferredValues(TMP_Math.FLOAT_MAX, TMP_Math.FLOAT_MAX);
                textComponent.rectTransform.sizeDelta = size;
            }
            else
            {
                textComponent.rectTransform.sizeDelta = TMP_Settings.defaultTextMeshProUITextContainerSize;
            }

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        [MenuItem("GameObject/Javanese Toolkit/Javanese Unicode Text (TMP)", false, 10)]
        static void CreateJavaUnicodeTextUGUI(MenuCommand menuCommand)
        {   
            GameObject go = null;

            #if UNITY_EDITOR
                go = ObjectFactory.CreateGameObject("Javanese Unicode Text (TMP)");
                JavaUnicodeTextMeshProUGUI textComponent = ObjectFactory.AddComponent<JavaUnicodeTextMeshProUGUI>(go);
            #else
                go = CreateUIElementRoot("Javanese Unicode Text (TMP)", s_TextElementSize);
                JavaUnicodeTextMeshProUGUI textComponent = go.AddComponent<JavaUnicodeTextMeshProUGUI>();
            #endif

            textComponent.color = Color.white;
            textComponent.text = "ꦲꦤꦕꦫꦏ";
            textComponent.fontSize = JT_Settings.defaultFontSize;

            if (TMP_Settings.autoSizeTextContainer)
            {
                Vector2 size = textComponent.GetPreferredValues(TMP_Math.FLOAT_MAX, TMP_Math.FLOAT_MAX);
                textComponent.rectTransform.sizeDelta = size;
            }
            else
            {
                textComponent.rectTransform.sizeDelta = TMP_Settings.defaultTextMeshProUITextContainerSize;
            }

            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }

        private static TMP_DefaultControls.Resources GetStandardResources()
        {
            if (s_StandardResources.standard == null)
            {
                s_StandardResources.standard = AssetDatabase.GetBuiltinExtraResource<Sprite>(kStandardSpritePath);
                s_StandardResources.background = AssetDatabase.GetBuiltinExtraResource<Sprite>(kBackgroundSpritePath);
                s_StandardResources.inputField = AssetDatabase.GetBuiltinExtraResource<Sprite>(kInputFieldBackgroundPath);
                s_StandardResources.knob = AssetDatabase.GetBuiltinExtraResource<Sprite>(kKnobPath);
                s_StandardResources.checkmark = AssetDatabase.GetBuiltinExtraResource<Sprite>(kCheckmarkPath);
                s_StandardResources.dropdown = AssetDatabase.GetBuiltinExtraResource<Sprite>(kDropdownArrowPath);
                s_StandardResources.mask = AssetDatabase.GetBuiltinExtraResource<Sprite>(kMaskPath);
            }
            return s_StandardResources;
        }

        private static GameObject CreateUIElementRoot(string name, Vector2 size)
        {
            GameObject child = new GameObject(name);
            RectTransform rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return child;
        }

        private const string kStandardSpritePath = "UI/Skin/UISprite.psd";
        private const string kBackgroundSpritePath = "UI/Skin/Background.psd";
        private const string kInputFieldBackgroundPath = "UI/Skin/InputFieldBackground.psd";
        private const string kKnobPath = "UI/Skin/Knob.psd";
        private const string kCheckmarkPath = "UI/Skin/Checkmark.psd";
        private const string kDropdownArrowPath = "UI/Skin/DropdownArrow.psd";
        private const string kMaskPath = "UI/Skin/UIMask.psd";

        private static Vector2 s_TextElementSize = new Vector2(100f, 100f);
        private static TMP_DefaultControls.Resources s_StandardResources;
    }
}