using Exercise_1;
using System.Collections;
using System.Drawing;
using System.Text;

public class SnakeMatrix : IEnumerable
{
    private int[,] _matrix;

    public SnakeMatrix() { }

    public SnakeMatrix(int[,] matrix)
    {
        _matrix = matrix;
    }

    public SnakeMatrix(uint size)
    {
        if (size == 0)
        {
            throw new ArgumentException("Size should be greater than 0.");
        }
        _matrix = new int[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                _matrix[i, j] = i * (int)size + j + 1;
            }
        }
    }

    public SnakeMatrix(uint rows, uint columns)
    {
        if (rows == 0 || columns == 0)
        {
            throw new ArgumentException("Sizes should be greater than 0.");
        }
        _matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                _matrix[i, j] = i * (int)columns + j + 1;
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        int rowLength = _matrix.GetLength(0); // окремі поля для рядків та колонок
        int colLength = _matrix.GetLength(1); // бо програма має змогу виводити значення не квадратної матриці
        int numDiags = rowLength + colLength - 1;

        for (int diag = Constants.START_POSITION; diag < numDiags; diag++)
        {
            int startRow = Math.Max(Constants.START_POSITION, diag - colLength + 1);
            int endRow = Math.Min(diag, rowLength - 1);

            if (diag % 2 == Constants.EVEN_DIAGONAL)
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    int j = diag - i;
                    yield return _matrix[i, j];
                }
            }
            else
            {
                for (int i = endRow; i >= startRow; i--)
                {
                    int j = diag - i;
                    yield return _matrix[i, j];
                }
            }
        }
    }

    public override string? ToString()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            for (int j = 0; j < _matrix.GetLength(1); j++)
            {
                result.Append(_matrix[i, j] + "\t");
            }
            result.Append('\n');
        }
        return result.ToString();
    }
}
