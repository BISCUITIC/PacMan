using System.Runtime.CompilerServices;

namespace Pac_Man;

internal class Map: IDrawable
{
    private const int _size = 16;
    private char[,] _map = new char[_size, _size] {
        {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'},
        {'█',' ','█',' ',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█',' ',' ',' ',' ','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','$','█','█','█',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█','$',' ',' ',' ',' ',' ','$',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ','█','█','$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█','$',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█','█','█','█',' ','█','█','█',' ','█','█',' ','█','█','█','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},        
        {'█',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','█'},        
        {'█','█','█','█','█','█','█','█','█','█','█','█','█','█','█','█'},
    };

    public char this[int x, int y] { get => _map[x, y]; set => _map[x, y] = value; }

    static public char EmptySymbol  = ' ';
    static public char СherrySymbol = '$';
    static public char PlayerSymbol = '@';
    static public char EnemySymbol  = '%';

    public int Size { get => _size; }
    public char[,] Data { get => _map; }

    public Map()
    {
        Console.CursorVisible = false;
    }

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
