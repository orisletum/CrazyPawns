using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
namespace Pawns.Views
{
    public class PawnBody : MonoBehaviour
    {
        private void OnValidate()
        {
            if (renderer == null)
                renderer = GetComponent<Renderer>();
        }
        [SerializeField] private PawnMovement pawnMovement;
        [SerializeField] private Renderer renderer;
        public void ChangeColor(Material material) => renderer.material = material;


        private Vector3 offset;
        private float groundY;
        private bool isDragging = false;
        private float smoothSpeed = 4f;
        void Start()
        {
            groundY = transform.position.y;
        }

        public void OnMouseDown()
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    isDragging = true;


                    Plane plane = new Plane(Vector3.up, Vector3.up * groundY);
                    if (plane.Raycast(ray, out float distance))
                    {
                        offset = transform.position - ray.GetPoint(distance);
                        pawnMovement.MouseDown(offset);
                    }
                }
            }
        }

        public void OnMouseDrag()
        {
            if (isDragging)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Plane plane = new Plane(Vector3.up, Vector3.up * groundY);
                if (plane.Raycast(ray, out float distance))
                {
                    Vector3 point = ray.GetPoint(distance);
                    point.y = groundY;
                    pawnMovement.MouseDrag(point);


                }
            }
        }

        public void OnMouseUp()
        {
            isDragging = false;
            pawnMovement.MouseUp();
        }

    }
}