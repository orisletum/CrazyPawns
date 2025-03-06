using UnityEngine;

public class ConnectorView : MonoBehaviour
{
    [SerializeField] private PawnView pawnView;
    public PawnView Pawn=>pawnView;
    public void SetupLine(LineView _line) => line = _line;

    [SerializeField]private LineView line = null;
    public LineView Line =>line;
    [SerializeField]private ConnectorView connection = null;
    public ConnectorView Connection =>connection;
    public void SetConnection(ConnectorView connectView)
    {
        connection= connectView;
    }
    public void ChangeColor(Material material)
    {
        GetComponent<Renderer>().material = material;
    }
    public void ResetConnector()
    {
        line = null;
        connection = null;
    }
    private void OnMouseDown()
    {
        if(connection==null)
            PawnActions.OnMouseDownStartConnection.Invoke(this);
    }
   
    private void OnMouseUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out ConnectorView connect))
            {
                if (connection != null) return;
                PawnActions.AddConnectionAction.Invoke(this, connect);
            }
            else
            {
                PawnActions.RemoveConnectionAction.Invoke(this);
                PawnActions.OnMouseUpEndConnection.Invoke();
            }
        }
        else
            PawnActions.OnMouseUpEndConnection.Invoke();
        

        
    }

   
   
}
