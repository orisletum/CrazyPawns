using UnityEngine;
namespace Pawns.Views
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;
        public Renderer Renderer => renderer;
        private void OnValidate()
        {
            if (renderer == null) renderer = GetComponent<Renderer>();
        }
    }
}