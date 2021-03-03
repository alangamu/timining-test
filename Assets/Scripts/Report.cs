using System;
using System.Collections.Generic;

/// <summary>
/// Class for service handling
/// </summary>
[Serializable]
public class Report 
{
    public int ShovelID;
    public float Performance;
    public float PlannedPerformance;
    public List<LastStatesClass> LastStates;
}

/// <summary>
/// Class for service handling
/// </summary>
[Serializable]
public class LastStatesClass
{
    public string Start;
    public string End;
    public string Name;
    public string Color;
}
