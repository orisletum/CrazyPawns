using Pawns.Views;
using System;
using System.Linq;
using UnityEngine;
namespace Pawns.Services
{
    public class GroundCheckService : MonoBehaviour
    {
        public static Action<PawnView, bool> ChangeColorAction = delegate { };
        private Material defaultMaterial;
        private Material deleteMaterial;
        private GenerateGamePlaneService generateGamePlaneService;

        public void Initialize(PawnSettings pawnSettings, GenerateGamePlaneService _generateGamePlaneService)
        {
            generateGamePlaneService = _generateGamePlaneService;
            deleteMaterial = pawnSettings.DeleteMaterial;
            defaultMaterial = pawnSettings.DefaultMaterial;
            ChangeColorAction += ChangeColorOnce;
        }
        public void ChangeColorOnce(PawnView pawn, bool state)
        {
            Material material = state ? defaultMaterial : deleteMaterial;
            ChangeColor(pawn, material);

        }
        private void ChangeColor(PawnView pawn, Material material)
        {
            pawn.Connects.ToList().ForEach(connector =>
            {
                connector.ChangeColor(material);
            });
            pawn.PawnBox.ChangeColor(material);
        }
    }
}