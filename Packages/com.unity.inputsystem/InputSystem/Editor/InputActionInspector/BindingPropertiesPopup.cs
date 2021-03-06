#if UNITY_EDITOR
using System;
using UnityEditor;

namespace UnityEngine.Experimental.Input.Editor
{
    class BindingPropertiesPopup : EditorWindow
    {
        InputBindingPropertiesView m_BindingPropertyView;
        Action OnChange;

        public static void Show(Rect btnRect, ActionTreeViewItem treeViewLine, Action reload)
        {
            var w = CreateInstance<BindingPropertiesPopup>();
            w.OnChange = reload;
            w.SetProperty(treeViewLine);
            w.ShowPopup();
            w.ShowAsDropDown(btnRect, new Vector2(250, 350));
        }

        void SetProperty(ActionTreeViewItem treeViewLine)
        {
            m_BindingPropertyView = new InputBindingPropertiesView(treeViewLine.elementProperty, OnChange, new AdvancedDropdownState(), null);
        }

        void OnGUI()
        {
            m_BindingPropertyView.OnGUI();
        }
    }
}
#endif // UNITY_EDITOR
