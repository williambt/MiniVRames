using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
public class HideSelected : Editor
{
    static List<GameObject> _hiddenObjects = new List<GameObject>();

    [MenuItem("GameObject/Hide %h")]
    static void ToggleHide()
    {
        foreach ( var obj in Selection.gameObjects)
        {
            obj.SetActive(!obj.activeSelf);
            if (!obj.activeSelf)
                _hiddenObjects.Add(obj);
            else
                _hiddenObjects.Remove(obj);
        }
    }
    [MenuItem("GameObject/Unhide All %#h")]
    static void UnhideAll()
    {
        foreach (var obj in _hiddenObjects)
        {
            obj.SetActive(true);
        }
        _hiddenObjects.Clear();
    }
}
