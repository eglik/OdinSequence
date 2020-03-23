using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(SequenceController))]
public class SequenceControllerEditor : Editor
{
    private ReorderableList sequenceList;

    private void OnEnable()
    {
        SequenceController sequenceController = target as SequenceController;

        sequenceList = new ReorderableList(serializedObject, serializedObject.FindProperty("sequences"),
            true, true, true, true);

        sequenceList.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Sequence List");
        };

        sequenceList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = sequenceList.serializedProperty.GetArrayElementAtIndex(index);
            var sequence = element.FindPropertyRelative("sequence");
            rect.y += 2;
            
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 120, EditorGUIUtility.singleLineHeight),
                sequence, GUIContent.none);

            try
            {
                Sequence targetSequence = sequenceController.GetTargetObject(sequenceController.sequences, index).GetComponent<Sequence>();

                element.FindPropertyRelative("select").intValue = EditorGUI.Popup(
                    new Rect(rect.x + 125, rect.y, rect.width - 125, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("select").intValue, targetSequence.GetSequenceArray());

                sequenceController.CastingSequence(sequenceController.sequences,
                    index, 
                    sequenceController.GetTargetObject(sequenceController.sequences, index).GetComponent(
                       targetSequence.GetSequenceArray()[element.FindPropertyRelative("select").intValue]));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        sequenceList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}