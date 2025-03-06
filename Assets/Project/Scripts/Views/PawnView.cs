using Pawns.Services;
using UnityEngine;
namespace Pawns.Views
{
    public class PawnView : MonoBehaviour
    {
        [SerializeField] private ConnectorView[] connectViews;
        [SerializeField] private PawnMovement pawnMovement;
        [SerializeField] private PawnBody pawnBoxView;

        public PawnModel model;

        public LayerMask layerMask;
        public ConnectorView[] Connects => connectViews;
        public PawnBody PawnBox => pawnBoxView;
        public void Update()
        {
            if (!pawnMovement.IsDragging.Value)
            {
                if (!model.OnDesk) RemovePawn();
                return;
            }

            Vector3 direction = Vector3.down;
            RaycastHit hit;
            bool state = Physics.Raycast(transform.position + Vector3.up * 0.1f, direction, out hit, 1, layerMask);

            if (model.OnDesk != state)
            {
                model.OnDesk = state;
                GroundCheckService.ChangeColorAction.Invoke(this, model.OnDesk);

            }
        }
        public bool CheckConnection(PawnView pawn) => model.connectedPawns.Contains(pawn);
        private void RemovePawn()
        {
            model.OnDesk = true;

            foreach (var connect in connectViews)
            {
                PawnActions.RemoveConnectionAction.Invoke(connect);
            }

            PawnActions.RemovePawnAction.Invoke(this);

            foreach (var pawn in model.connectedPawns)
            {
                pawn.model.connectedPawns.Remove(this);
            }

            Destroy(gameObject, 0);
        }


    }
}