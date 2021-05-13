using UnityEngine;

[System.Serializable]
public struct Cell
{
    /// <summary>
    /// Жива ли клетка
    /// </summary>
    public bool isEmpety;

    /// <summary>
    /// Допустимое значение по X
    /// </summary>
    public int MaxX;

    /// <summary>
    /// Допустимое значение по Y
    /// </summary>
    public int MaxY;

    /// <summary>
    /// Кол-во соседних живых клеток
    /// </summary>
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

    /// <summary>
    /// Объект для вывода
    /// </summary>
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
}