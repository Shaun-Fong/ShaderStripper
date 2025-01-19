using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.shaunfong.ShaderStripper.Editor
{
    public class ListShaderPreProcessClasses : EditorWindow
    {

        public static void ShowDebugWindow(Vector2 pos)
        {
            var window = EditorWindow.CreateInstance<ListShaderPreProcessClasses>();
            window.titleContent = new GUIContent("IPreprocessShaders classes");
            window.ShowAuxWindow();
            window.position = new Rect(pos.x, pos.y, 500, 150);
        }

        private void OnEnable()
        {
            var scorll = new ScrollView();
            this.rootVisualElement.Add(scorll);


            var classes = GetSubClasses<UnityEditor.Build.IPreprocessShaders>();

            foreach (var cls in classes)
            {
                scorll.Add(new Label(cls.FullName));
            }
        }

        private static List<System.Type> GetSubClasses<T>()
        {
            var result = new List<System.Type>();
            var asms = System.AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in asms)
            {
                var types = asm.GetTypes();
                foreach (var t in types)
                {
                    if (t == typeof(T)) { continue; }
                    if (typeof(T).IsAssignableFrom(t))
                    {
                        result.Add(t);
                    }
                }
            }

            return result;
        }

    }
}
