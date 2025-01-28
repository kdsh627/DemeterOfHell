using UnityEngine;
using UnityEngine.Tilemaps;

public class TileHighlighter : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private Color highlightColor = new Color(1, 1, 1, 1);
    private Color defaultColor = new Color(1, 1, 1, 0);
    private Vector3Int[] previousHighlightedCells; // 이전에 강조한 셀
    private bool InTileMap = true;

    void Update()
    {
        //마우스 위치
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0.0f;

        //마우스 위치 기준 셀좌표 계산
        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPosition);

        // 현재 셀 기준으로 2x2 영역 계산
        Vector3Int[] cellsToHighlight = new Vector3Int[4]
        {
            cellPosition, // 기준 셀
            cellPosition + new Vector3Int(1, 0, 0), // 오른쪽
            cellPosition + new Vector3Int(0, 1, 0), // 위쪽
            cellPosition + new Vector3Int(1, 1, 0)  // 오른쪽 위
        };

        // 이전 강조된 셀 복원
        if (previousHighlightedCells != null)
        {
            foreach (var cell in previousHighlightedCells)
            {
                if (tilemap.HasTile(cell)) // 셀이 유효한 경우
                {
                    tilemap.SetColor(cell, defaultColor); // 색상 복원
                }
            }
        }

        // 현재 2x2 영역 강조
        foreach (var cell in cellsToHighlight)
        {
            if (!tilemap.HasTile(cell)) // 셀이 유효하지 않으면
            {
                InTileMap = false;
            }
        }

        if (InTileMap)
        {
            foreach (var cell in cellsToHighlight)
            {
                tilemap.SetColor(cell, highlightColor); // 색상 변경
            }
        }

        // 강조된 셀 저장
        previousHighlightedCells = cellsToHighlight;
        InTileMap = true;
    }
}
