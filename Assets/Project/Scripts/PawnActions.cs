using System;

public class PawnActions 
{
    public static Action<ConnectorView> OnMouseDownStartConnection = delegate { };
    public static Action<ConnectorView> OnMouseClickAction = delegate { };
    public static Action OnMouseUpEndConnection = delegate { };
    public static Action<ConnectorView, ConnectorView> AddConnectionAction = delegate { };
    public static Action<ConnectorView> RemoveConnectionAction = delegate { };
    public static Action<PawnView> RemovePawnAction = delegate { };
}
