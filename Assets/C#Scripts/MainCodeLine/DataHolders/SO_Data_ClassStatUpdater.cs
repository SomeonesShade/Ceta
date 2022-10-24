using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassStatsManager", menuName = "ScriptableObjects/ClassStatsManager")]
public class SO_Data_ClassStatUpdater : ScriptableObject
{
    public int currentClass;
    public SO_Data_NormalStats[] ClassStats;
}
