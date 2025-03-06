using Pawns.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConnectionModel 
{
    public List<PawnView> pawns;
    public List<ConnectorView> connectors;
    public LineView line;
}
