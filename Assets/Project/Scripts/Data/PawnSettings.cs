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
    /// ������ �����
    /// </summary>
    public BlockView BlockPrefab => blockPrefab;
    /// <summary>
    /// ������ ������
    /// </summary>
    public PawnView PawnPrefab => pawnPrefab;
    /// <summary>
    /// ������ �����
    /// </summary>
    public LineView LinePrefab => linePrefab;
     /// <summary>
    /// ������ ������� �������� � ������;
    /// </summary>
    public float InitialZoneRadius => initialZoneRadius;
    /// <summary>
    /// ���������� ����������� ��� ������� ���� �����;
    /// </summary>
    public int InitialPawnCount => initialPawnCount;
    /// <summary>
    /// �������� ��� �������� ��������� ��� ������������� �����������;
    /// </summary>
    public Material ActiveConnectorMaterial => activeConnectorMaterial;

    /// <summary>
    ///�������� ��� �������� ��������� �����;
    /// </summary>
    public Material DeleteMaterial => deleteMaterial;
    /// <summary>
    /// ����������� �������� 
    /// </summary>
    public Material DefaultMaterial => defaultMaterial;
    /// <summary>
    /// ������ ��������� �����(���������� ������ �� �������);
    /// </summary>
    public Vector2 CheckerboardSize => checkerboardSize;
    /// <summary>
    /// ������ �� ���� ������ ��������� �����;
    /// </summary>
    public Color BlackCellColor => blackCellColor;
    /// <summary>
    /// ������ �� ���� ������ ��������� �����;
    /// </summary>
    public Color WhiteCellColor => whiteCellColor;
}
