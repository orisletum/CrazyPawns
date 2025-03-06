using UnityEngine;
using UniRx;
public enum LineConnector
{
    start,end
}

namespace Pawns.Views
{
    public class LineView : MonoBehaviour
    {
        private ConnectorView start;
        private ConnectorView end;
        private CompositeDisposable disposables = new CompositeDisposable();
        public ConnectorView startConnection = null;
        [SerializeField] private LineRenderer lineRenderer;

        public void SubscribeOnCreate(PawnMovement pawn, LineConnector lineConnector)
        {

            pawn.PawnPosition
                  .Subscribe(pos =>
                  {
                      if (lineConnector == LineConnector.start)
                          UpdateStartPosition();
                      else
                          UpdateEndPosition();
                  })
                  .AddTo(disposables);
        }

        private void UpdateStartPosition() => lineRenderer.SetPosition(0, start.transform.position);
        public void UpdateEndPosition() => lineRenderer.SetPosition(1, end.transform.position);
        private void OnDestroy() => disposables.Clear();
        public void SetLine(ConnectorView _start, ConnectorView _end)
        {
            start = _start;
            end = _end;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, start.transform.position);
            lineRenderer.SetPosition(1, end.transform.position);
        }
        public void RemoveLine() { Destroy(gameObject, 0); }
    }
}