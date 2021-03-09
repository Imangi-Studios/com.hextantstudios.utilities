using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Hextant.Editor
{
    public class SelectionHistoryWindow : EditorWindow, IHasCustomMenu
    {
        private GUIStyle _previousLabelStyle;
        private GUIStyle _nextLabelStyle;

        private GUIStyle PreviousLabelStyle
        {
            get
            {
                if( _previousLabelStyle == null )
                {
                    _previousLabelStyle = new GUIStyle(EditorStyles.label);
                    _previousLabelStyle.alignment = TextAnchor.MiddleLeft;
                }

                return _previousLabelStyle;
            }
        }

        private GUIStyle NextLabelStyle
        {
            get
            {
                if( _nextLabelStyle == null )
                {
                    _nextLabelStyle = new GUIStyle(EditorStyles.label);
                    _nextLabelStyle.alignment = TextAnchor.MiddleRight;
                }

                return _nextLabelStyle;
            }
        }

        /// <summary>
        /// Implements IHasCutomMenu callback to add items into the right click menu and context menu on the window.
        /// </summary>
        /// <param name="menu">Menu to add into.</param>
        public virtual void AddItemsToMenu(GenericMenu menu)
        {
            menu.AddItem(
                new GUIContent("Clear History"),
                false,
                new GenericMenu.MenuFunction(SelectionHistory.instance.Clear));
        }

        [MenuItem("Window/Imangi/SelectionHistory")]
        private static SelectionHistoryWindow OpenSelectionHistoryWindow()
        { 
            var window = EditorWindow.GetWindow<SelectionHistoryWindow>(false, "History");

            var minSize = window.minSize;
            minSize.y = 24;
            window.minSize = minSize;

            return window;
        }

        private void OnEnable()
        {
            SelectionHistory.instance.SelectionUpdated += Repaint;
        }

        private void OnDisable()
        {
            SelectionHistory.instance.SelectionUpdated -= Repaint;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUI.BeginDisabledGroup(!SelectionHistory.instance.HasPreviousEntries());

            var leftArrowCode = "\u2190";
            if( GUILayout.Button(leftArrowCode, GUILayout.MinWidth(35)) )
            {
                SelectionHistory.instance.Back();
            }

            EditorGUI.EndDisabledGroup();

            {
                var previousObjects = SelectionHistory.instance.GetPreviousObjects();
                var previousLabel = GetNameForSelectionObjects(previousObjects);
                EditorGUILayout.LabelField(
                    previousLabel,
                    PreviousLabelStyle,
                    GUILayout.MinWidth(40),
                    GUILayout.ExpandWidth(true));
            }

            GUILayout.FlexibleSpace();

            {
                var nextObjects = SelectionHistory.instance.GetNewerObjects();
                var nextLabel = GetNameForSelectionObjects(nextObjects);
                EditorGUILayout.LabelField(
                    nextLabel,
                    NextLabelStyle,
                    GUILayout.MinWidth(40),
                    GUILayout.ExpandWidth(true));
            }

            EditorGUI.BeginDisabledGroup(!SelectionHistory.instance.HasNewerEntries());

            var rightArrowCode = "\u2192";
            if( GUILayout.Button(rightArrowCode, GUILayout.MinWidth(35)) )
            {
                SelectionHistory.instance.Forward();
            }

            EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndHorizontal();
        }

        private string GetNameForSelectionObjects(Object[] objects)
        {
            if( objects == null || objects.Length == 0)
            {
                return string.Empty;
            }

            var label = objects[0].name;

            if( objects.Length > 1)
            {
                label += $" [+{objects.Length - 1}]";
            }

            return label;
        }
    }
}