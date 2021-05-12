using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkersArea : MonoBehaviour
{
    public int Width;
    public int Heigth;

    [SerializeField] private Transform _parent;
    private GameObject _p;
    private Camera _camera;

    [Header("This UI")]
    [SerializeField]private Button Button_Play;
    [SerializeField]private Button Button_Clear;
    [SerializeField]private Button Button_RestartInit;
    [SerializeField]private TMP_InputField IF_Width;
    [SerializeField]private TMP_InputField IF_Higth;

    [Header("This Prefab")]
    [SerializeField]private CellObject cellPrefab;
    [SerializeField]private GameObject background;

    public static Cell[,] cells;
    public static bool isInit;

    private void Awake()
    {
        isInit = false;
        _camera = Camera.main;
        InitCells();
        Button_RestartInit.onClick.AddListener(RestartInitCells);
    }

    public void CheckInit()
    {
        if (isInit) isInit = false;
        else isInit = true;
    }

    private void RestartInitCells()
    {
        try
        {
            Width = int.Parse(IF_Width.text);
            Heigth = int.Parse(IF_Higth.text);
        }
        catch
        {
            Width = 10;
            Heigth = 10;
        }

        int averagesHeigthWidt = (Width + Heigth) / 2;

        _camera.orthographicSize = averagesHeigthWidt;

        Vector3 cameraPos = _camera.transform.position;
        cameraPos.x = averagesHeigthWidt / 2;
        cameraPos.z = -10;
        cameraPos.y = averagesHeigthWidt / 2;

        _camera.transform.position = cameraPos;

        Button_Clear.onClick.Invoke();

        Button_Play.onClick.RemoveAllListeners();
        Button_Clear.onClick.RemoveAllListeners();
        Destroy(_p.gameObject);
        InitCells();
    }

    private void InitCells()
    {
        cells = new Cell[Width, Heigth];

        _p = Instantiate(_parent.gameObject, Vector3.zero, transform.rotation);


        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                cells[i, j] = new Cell(i, j, Width, Heigth);
                CellObject cell = Instantiate(cellPrefab, new Vector3(i,j,0), transform.rotation, _p.transform);
                cell.SetCellData(cells[i, j], cellPrefab.gameObject);

                Button_Play.onClick.AddListener(cell.Play);
                Button_Clear.onClick.AddListener(cell.ClearCell);

                Instantiate(background, new Vector3(i,j,1), transform.rotation, transform);
            }
        }
    }
}
