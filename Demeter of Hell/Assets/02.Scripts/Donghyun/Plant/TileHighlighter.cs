using UnityEngine;
using UnityEngine.Tilemaps;
using Types;

public class TileHighlighter : MonoBehaviour
{
    public Tilemap tilemap;

    private Color highlightColor = new Color(1, 1, 1, 1);
    private Color defaultColor = new Color(1, 1, 1, 0);
    private Vector3Int previousHighlightedCell; // 이전에 강조한 셀

    private void Awake()
    {
        SetGrid();
    }
    private void Update()
    {
        if (!GameManager.Instance.BeginWave) //웨이브 중이 아닐때만
        {
            HighlightCell();
        }
    }

    public void SetGrid()
    {
        tilemap = GameObject.FindGameObjectWithTag("SpawnArea").GetComponent<Tilemap>();
    }

    private void HighlightCell()
    {
        //마우스 위치
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0.0f;

        //마우스 위치 기준 셀좌표 계산
        Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPosition);

        //시간 없어서 영역은 무조건 한 칸
        //// 현재 셀 기준으로 2x2 영역 계산
        //Vector3Int[] cellsToHighlight = new Vector3Int[4]
        //{
        //    cellPosition, // 기준 셀
        //    cellPosition + new Vector3Int(1, 0, 0), // 오른쪽
        //    cellPosition + new Vector3Int(0, 1, 0), // 위쪽
        //    cellPosition + new Vector3Int(1, 1, 0)  // 오른쪽 위
        //};

        // 이전 강조된 셀 복원
        if (previousHighlightedCell != null)
        {
            if (tilemap.HasTile(previousHighlightedCell)) // 셀이 유효한 경우
            {
                tilemap.SetColor(previousHighlightedCell, defaultColor); // 색상 복원
            }
        }

        //해당 셀이 설치 영역내에 존재하고 미설치된 구역일 경우
        if (tilemap.HasTile(cellPosition) && tilemap.GetTileFlags(cellPosition) != TileFlags.LockColor)
        {
            tilemap.SetColor(cellPosition, highlightColor); // 색상 변경

            //여기서 클릭이벤트 확인
            if (Input.GetMouseButtonDown(0) && PlantManager.Instance.PaySeed())
            {
                tilemap.SetColor(cellPosition, defaultColor);
                tilemap.SetTileFlags(cellPosition, TileFlags.LockColor);
                PlantManager.Instance.SpawnPlant(tilemap.GetCellCenterWorld(cellPosition));
            }
        }

        // 강조된 셀 저장
        previousHighlightedCell = cellPosition;
    }
}
