using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateConnectionService
{
    private GenerateGamePlaneService generateGamePlaneService;
    private PawnSettings pawnSettings;
    private LineView lineView;
    private GamePlaneView planeView;
    private ConnectorView firstConnector = null;
    private List<ConnectionModel> connections = new List<ConnectionModel>();
    public void Initialize(PawnSettings _pawnSettings, GamePlaneView _planeView, GenerateGamePlaneService _generateGamePlaneService)
    {
        generateGamePlaneService = _generateGamePlaneService;
        pawnSettings = _pawnSettings;
        planeView = _planeView;
        lineView = _pawnSettings.LinePrefab;

        PawnActions.RemoveConnectionAction += RemoveConnection;
        PawnActions.AddConnectionAction += CheckConnection;
        PawnActions.OnMouseDownStartConnection += SelectConnector;
        PawnActions.OnMouseUpEndConnection += ResetColorConnectors;
    }

    private void CheckConnection(ConnectorView firstConnector, ConnectorView connector)
    {
        if (AreConnectorsValid(firstConnector, connector))
        {
            AddConnection(firstConnector, connector);
            PawnActions.OnMouseUpEndConnection.Invoke();
        }
    }

    private void SelectConnector(ConnectorView connector)
    {
        if (firstConnector == null)
        {
            firstConnector = connector;
            ColorizeConnectors(connector);
            return;
        }

        ResetColorConnectors();

        if (AreConnectorsValid(firstConnector, connector))
            AddConnection(firstConnector, connector);
        

        firstConnector = null;
    }

    private bool AreConnectorsValid(ConnectorView first, ConnectorView second)
    {
        return first != second && first.Pawn != second.Pawn &&
            !IsAlreadyConnected(first.Pawn, second.Pawn) && !IsConnected(second);       
    }

    private bool IsAlreadyConnected(PawnView firstPawn, PawnView secondPawn)
    {
        return firstPawn.CheckConnection(secondPawn);
    }

    private bool IsConnected(ConnectorView connector)
    {
        return connector.Connection != null;
    }

    private void ColorizeConnectors(ConnectorView activeConnector)
    {
        var connectedPawns = activeConnector.Pawn.model.connectedPawns;

        foreach (var pawn in generateGamePlaneService.Pawns)
        {
            if (!connectedPawns.Contains(pawn) && pawn != activeConnector.Pawn)
                foreach (var connect in pawn.Connects)
                {
                    if (connect.Line == null && connect != activeConnector)
                        connect.ChangeColor(pawnSettings.ActiveConnectorMaterial);
                }
        }
    }
    private void ResetColorConnectors()
    {
        foreach (var pawn in generateGamePlaneService.Pawns)
            foreach (var connect in pawn.Connects)
                connect.ChangeColor(pawnSettings.DefaultMaterial);
    }

    private void RemoveConnection(ConnectorView connector)
    {
        ConnectionModel connection = connections
        .FirstOrDefault(c => c.connectors.Contains(connector));
        if (connection != null)
        {
            connection.line.RemoveLine();
            connection.connectors.ForEach(x => x.ResetConnector());
            var pawn0 = connection.pawns[0];
            var pawn1 = connection.pawns[1];
            pawn0.model.connectedPawns.Remove(pawn1);
            pawn1.model.connectedPawns.Remove(pawn0);
            connections.Remove(connection);
        }



    }

    private void AddConnection(ConnectorView start, ConnectorView end)
    {
        bool isConnected = connections.Select(x => x.connectors.Contains(start) && x.connectors.Contains(end)).FirstOrDefault();
        if (!isConnected)
        {

            LineView line = planeView.CreateLine(lineView, start, end);
            ConnectionModel connection = new ConnectionModel()
            {
                pawns = new List<PawnView>() { start.Pawn, end.Pawn },
                connectors = new List<ConnectorView>() { start, end },
                line = line
            };
            start.SetConnection(end);
            end.SetConnection(start);
            start.SetupLine(line);
            end.SetupLine(line);
            line.SubscribeOnCreate(start.Pawn.gameObject.GetComponent<PawnMovement>(), LineConnector.start);
            line.SubscribeOnCreate(end.Pawn.gameObject.GetComponent<PawnMovement>(), LineConnector.end);
            connections.Add(connection);
            start.Pawn.model.connectedPawns.Add(end.Pawn);
            end.Pawn.model.connectedPawns.Add(start.Pawn);
            Debug.Log("connections: " + connections.Count);
            firstConnector = null;
        }
    }
}
