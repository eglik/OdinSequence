using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(SequenceController))]
public class SequenceControllerEditor : Editor
{
    private ReorderableList list1;
    private ReorderableList list2;

    private void OnEnable()
    {
        SequenceController sequenceController = target as SequenceController;

        list1 = new ReorderableList(serializedObject, serializedObject.FindProperty("startSequences"),
            true, true, true, true);

        list1.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "Start Sequence");
        };

        list1.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list1.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 120, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("sequence"), GUIContent.none);

            try
            {
                Sequence targetSequence = sequenceController.GetTargetObject(sequenceController.startSequences, index).GetComponent<Sequence>();

                element.FindPropertyRelative("select").intValue = EditorGUI.Popup(
                    new Rect(rect.x + 125, rect.y, rect.width - 125, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("select").intValue, targetSequence.GetSequenceArray());

                sequenceController.CastingSequence(sequenceController.startSequences,
                    index, 
                    sequenceController.GetTargetObject(sequenceController.startSequences, index).GetComponent(
                       targetSequence.GetSequenceArray()[element.FindPropertyRelative("select").intValue]));
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        };

        list2 = new ReorderableList(serializedObject, serializedObject.FindProperty("endSequences"),
            true, true, true, true);

        list2.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, "End Sequence");
        };

        list2.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = list2.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            
            EditorGUI.PropertyField(
                new Rect(rect.x, rect.y, 120, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("sequence"), GUIContent.none);
            
            try
            {
                Sequence targetSequence = sequenceController.GetTargetObject(sequenceController.endSequences, index).GetComponent<Sequence>();

                element.FindPropertyRelative("select").intValue = EditorGUI.Popup(
                    new Rect(rect.x + 125, rect.y, rect.width - 125, EditorGUIUtility.singleLineHeight),
                    element.FindPropertyRelative("select").intValue, targetSequence.GetSequenceArray());

                sequenceController.CastingSequence(sequenceController.endSequences, index,
                    sequenceController.GetTargetObject(sequenceController.endSequences, index).GetComponent(
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
        list1.DoLayoutList();
        list2.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}