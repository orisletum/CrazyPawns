using UnityEngine;
namespace Pawns.Views
{
    public class GamePlaneView : MonoBehaviour
    {
        private Color firstBlockColor;
        private Color secondBlockColor;

        public void SetColors(Color first, Color second)
        {
            firstBlockColor = first;
            secondBlockColor = second;
        }

        public BlockView CreateBlock(BlockView blockView, Vector3 pos, bool isBlack)
        {

            var block = Instantiate(blockView, pos, Quaternion.identity, transform);
            var color = isBlack ? firstBlockColor : secondBlockColor;
            block.Renderer.materials[0].color = block.Renderer.materials[1].color = color;
            block.gameObject.name = "Block";
            return block;
        }

        public PawnView GeneratePawns(PawnView pawnView, Vector3 pos)
        {
            var pawn = Instantiate(pawnView, pos, Quaternion.identity, transform);
            var pawnModel = new PawnModel();
            pawn.model = pawnModel;
            pawn.gameObject.name = "Pawn";
            return pawn;
        }


        public LineView CreateLine(LineView lineView, ConnectorView start, ConnectorView end)
        {
            var line = Instantiate(lineView, Vector3.zero, Quaternion.identity, transform);

            line.SetLine(start, end);
            line.startConnection = start;
            return line;
        }
    }
}