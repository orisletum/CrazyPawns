using Pawns.Views;
using System;
using System.Collections.Generic;

[Serializable]
public class PawnModel
{
    public List<PawnView> connectedPawns = new List<PawnView>();
   
    private bool onDesk = true;
    public bool OnDesk
    {
        get => onDesk;
        set => onDesk = value;
    }

    public PawnModel() 
    {
        onDesk = true;
        connectedPawns.Clear();
        connectedPawns = new List<PawnView>();
    }
}
