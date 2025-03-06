using Pawns.Views;
using UnityEngine;
[CreateAssetMenu(menuName = "Game/PawnSettings", fileName = "PawnSettings")]
public class PawnSettings : ScriptableObject
{
    [SerializeField] private BlockView blockPrefab;
    [SerializeField] private PawnView pawnPrefab;
    [SerializeField] private LineView linePrefab;
    [SerializeField] private float initialZoneRadius=3;
    [SerializeField] private int initialPawnCount = 4;
    [SerializeField] private Material activeConnectorMaterial;
    [SerializeField] private Material deleteMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Vector2 checkerboardSize= new Vector2(8,8);
    [SerializeField] private Color blackCellColor= Color.black;
    [SerializeField] private Color whiteCellColor = Color.white;
    /// <summary>
    /// префаб блока
    /// </summary>
    public BlockView BlockPrefab => blockPrefab;
    /// <summary>
    /// префаб фигуры
    /// </summary>
    public PawnView PawnPrefab => pawnPrefab;
    /// <summary>
    /// префаб линии
    /// </summary>
    public LineView LinePrefab => linePrefab;
     /// <summary>
    /// радиус области создания в юнитах;
    /// </summary>
    public float InitialZoneRadius => initialZoneRadius;
    /// <summary>
    /// количество спавнящихся при запуске игры фигур;
    /// </summary>
    public int InitialPawnCount => initialPawnCount;
    /// <summary>
    /// материал для покраски доступных для подсоединения коннекторов;
    /// </summary>
    public Material ActiveConnectorMaterial => activeConnectorMaterial;

    /// <summary>
    ///материал для покраски удаляемых фигур;
    /// </summary>
    public Material DeleteMaterial => deleteMaterial;
    /// <summary>
    /// стандартный материал 
    /// </summary>
    public Material DefaultMaterial => defaultMaterial;
    /// <summary>
    /// размер шахматной доски(количество клеток по стороне);
    /// </summary>
    public Vector2 CheckerboardSize => checkerboardSize;
    /// <summary>
    /// первый из двух цветов шахматной доски;
    /// </summary>
    public Color BlackCellColor => blackCellColor;
    /// <summary>
    /// второй из двух цветов шахматной доски;
    /// </summary>
    public Color WhiteCellColor => whiteCellColor;
}
