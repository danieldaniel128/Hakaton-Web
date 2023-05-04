using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassData", menuName = "ScriptableObjects/Class", order = 1)]
public class ClassScriptableObject : ScriptableObject
{
    public string Name;
    public List<ActionScriptableObject> Actions;
}
