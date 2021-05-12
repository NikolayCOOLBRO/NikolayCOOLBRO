using UnityEngine;

[System.Serializable]
public struct Cell
{
    public bool isEmpety;

    public int MaxX;
    public int MaxY;

    public int numberNeighbors;

    private int _x;
    public int X
    {
        get
        {
            return _x;
        }
        set
        {
            if(value < 0)
            {
                _x = 0;
            }
            else if(value >= MaxX)
            {
                _x = MaxX - 1;
            }
            else
            {
                _x = value;
            }
        }
    }

    private int _y;
    public int Y
    {
        get
        {
            return _y;
        }
        set
        {
            if (value < 0)
            {
                _y = 0;
            }
            else if (value >= MaxY)
            {
                _y = MaxY - 1;
            }
            else
            {
                _y = value;
            }
        }
    }

    public GameObject Pref;

    public Cell(int x, int y, int maxX, int maxY)
    {
        isEmpety = true;
        _x = x;
        _y = y;
        this.MaxX = maxX;
        this.MaxY = maxY;
        Pref = null;
        numberNeighbors = 0;
    }

    public static bool operator ==(Cell cell1, Cell cell2)
    {
        return cell1.X == cell2.X && cell1.Y == cell2.Y;
    }

    public static bool operator !=(Cell cell1, Cell cell2)
    {
        return cell1.X != cell2.X && cell1.Y != cell2.Y;
    }
}