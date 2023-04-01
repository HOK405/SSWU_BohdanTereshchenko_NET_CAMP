using System.Text;

namespace Task2_OneColorLineInMatrix
{
    internal class ColorMatrix
    {// молодець, що константу винесено.
        private const int UPPER_LIMIT = 17;
        private const int LOWER_LIMIT = 0;

        private int _rows;
        private int _columns;
        private int[,] _matrix;
//краще повертати як параметри результату в методі
        public int Color { get; private set; } = 0;
        public int LineLength { get; private set; } = 1;
        public int LineRow { get; private set; } = 0;
        public int ColumnStart { get; private set; } = 0;
        public int ColumnFinish { get; private set; } = 0;

        public ColorMatrix(int rows = 3, int columns = 3)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new int[rows, columns];
        }

        public void FillRandomly()
        {
            Random random = new Random();

            int amount = _rows * _columns;

            for (int i = 0; i < amount; i++)
            {//Чому так дивно?
                _matrix[i / _columns, i % _columns] = random.Next(LOWER_LIMIT, UPPER_LIMIT);
            }
        }

        public void FindLine()
        {
            for (int i = 0; i < _rows; i++)
            {
                int lineColor = _matrix[i, 0];
                int lineRow = i;
                int lineColumnStart = 0;

                for (int j = 1; j < _columns; j++)
                {
                    if (_matrix[i,j] != lineColor)
                    {
                        lineColor = _matrix[i, j];
                        lineColumnStart = j;
                    }
                    int lineColumnFinish = j;
                    if (LineLength < lineColumnFinish - lineColumnStart + 1)
                    {
                        Color = lineColor;
                        LineLength = lineColumnFinish - lineColumnStart + 1;
                        LineRow = lineRow;
                        ColumnStart = lineColumnStart;
                        ColumnFinish = lineColumnFinish;
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    result.Append(_matrix[i, j] + "\t");
                }
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
