using System;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    [SerializeField]private Cell _cellData;

    [Header("Cell Object")]
    public GameObject AreaObject;
    public GameObject GX;

    public void Play()
    {
        CheckAdjacentCell(ref WorkersArea.cells);
    }

    private bool N = true, S = true, W = true, E = true, NE = true, NW = true, SE = true, SW = true;//Стороны света как на компасе

    private void Awake()
    {
    }

    private void Update()
    {
        if (_cellData.isEmpety)
        {
            GX.SetActive(false);
        }
        if(WorkersArea.isInit)CheckAdjacentCell(ref WorkersArea.cells);
    }

    private void OnMouseOver()
    {
        AreaObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        AreaObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (WorkersArea.isInit) return;
        else
        {
            ActiveCell(ref WorkersArea.cells);
        }
    }

    public void SetCellData(Cell cell,GameObject pref)
    {
        _cellData = cell;
        _cellData.Pref = GX;
        //_cellData.Pref.SetActive(false);
        CheckTheCardinalPoints();
    }

    public Cell GetCellData()
    {
        return _cellData;
    }

    private void CheckAdjacentCell(ref Cell[,] cells)
    {
        Cell[,] cells1 = cells;
        int numberNeighbors = 0;

        if(E && !cells[_cellData.X + 1, _cellData.Y].isEmpety)
        {
            numberNeighbors++;
        }
        if (N && !cells[_cellData.X, _cellData.Y+1].isEmpety)
        {
            numberNeighbors++;
        }
        if (W && !cells[_cellData.X-1, _cellData.Y].isEmpety)
        {
            numberNeighbors++;
        }
        if (S && !cells[_cellData.X, _cellData.Y-1].isEmpety)
        {
            numberNeighbors++;
        }
        if (NE && !cells[_cellData.X + 1, _cellData.Y + 1].isEmpety )
        {
            numberNeighbors++;
        }
        if (NW && !cells[_cellData.X - 1, _cellData.Y + 1].isEmpety )
        {
            numberNeighbors++;
        }
        if (SE && !cells[_cellData.X + 1, _cellData.Y - 1].isEmpety )
        {
            numberNeighbors++;
        }
        if (SW && !cells[_cellData.X - 1, _cellData.Y - 1].isEmpety)
        {
            numberNeighbors++;
        }

        Debug.Log(numberNeighbors.ToString());
        _cellData.numberNeighbors = numberNeighbors;
        CellHandler.AllCells.Add(this);
    }

    public void DeactivateCell(ref Cell[,] cells) 
    {
        _cellData.isEmpety = true;
        _cellData.Pref.SetActive(false);

        cells[_cellData.X, _cellData.Y].isEmpety = true;
    }

    public void ActiveCell(ref Cell[,] cells)
    {
        _cellData.isEmpety = false;
        _cellData.Pref.SetActive(true);

        cells[_cellData.X, _cellData.Y].isEmpety = false;
    }

    private void CheckTheCardinalPoints()
    {
        if(_cellData.X == 0)
        {
            W = false;
        }
        else if(_cellData.X == _cellData.MaxX - 1)
        {
            E = false;
        }
        if(_cellData.Y == 0)
        {
            S = false;
        }
        else if(_cellData.Y == _cellData.MaxY - 1)
        {
            N = false;
        }

        if(!S)
        {
            SE = false;
            SW = false;
        }
        if(!N)
        {
            NE = false;
            NW = false;
        }
        if (!W)
        {
            SW = false;
            NW = false;
        }
        if (!E)
        {
            SE = false;
            NE = false;
        }
    }
}
