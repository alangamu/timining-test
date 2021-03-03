using System;
using System.Collections.Generic;

[Serializable]
public class Report 
{
    public int ShovelID;
    public float Performance;
    public float PlannedPerformance;
    public List<LastStatesClass> LastStates;
}

[Serializable]
public class LastStatesClass
{
    public string Start;
    public string End;
    public string Name;
    public string Color;
}
