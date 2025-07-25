﻿using Pac_Man.Interfaces;

namespace Pac_Man.UserInterface;

internal class Map : IDrawable
{
    private const int _size = 25;
    public int Size { get => _size; }

    private char[,] _map = new char[25, _size] {
        {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','█',' ','█','█','█','█','█',' ','█',' ','█','█','█','█','█',' ','█','█','█',' ','█'},
        {'█',' ','█','█','█',' ','█','█','█','█','█',' ','█',' ','█','█','█','█','█',' ','█','█','█',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','█',' ','█',' ','█','█','█','█','█','█','█','█','█',' ','█',' ','█','█','█',' ','█'},
        {'█',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ','█'},
        {'█','█','█','█','█',' ','█','█','█','█','█',' ','█',' ','█','█','█','█','█',' ','█','█','█','█','█'},
        {'█','█','█','█','█',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ','█','█','█','█','█'},
        {'█','█','█','█','█',' ','█',' ','█','█','█','█',' ','█','█','█','█',' ','█',' ','█','█','█','█','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█','█','█','█','█',' ','█',' ','█','█','█','█','█','█','█','█','█',' ','█',' ','█','█','█','█','█'},
        {'█','█','█','█','█',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ','█','█','█','█','█'},
        {'█','█','█','█','█',' ','█',' ','█','█','█','█','█','█','█','█','█',' ','█',' ','█','█','█','█','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','█',' ','█','█','█','█','█',' ','█',' ','█','█','█','█','█',' ','█','█','█',' ','█'},
        {'█',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ','█'},
        {'█','█','█',' ','█',' ','█',' ','█','█','█','█','█','█','█','█','█',' ','█',' ','█',' ','█','█','█'},
        {'█',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','█','█','█','█','█','█','█',' ','█',' ','█','█','█','█','█','█','█','█','█',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'},
    };
    public char this[int x, int y] { get => _map[x, y]; set => _map[x, y] = value; }

    public static char EmptySymbol = ' ';
    public static char WallSymbol = '█';
    public static char СherrySymbol = '$';
    public static char PlayerSymbol = '@';
    public static char EnemySymbol = '%';        

    public Map() { }

    public void Draw()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Console.Write(_map[i, j]);
            }
            Console.WriteLine();
        }
    }
}
