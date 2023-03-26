using System.Text;

namespace Task1_SpiralSnake
{
    internal class SpiralMatrix
    {
        private int _rows;
        private int _columns;
        private int[,] _matrix;

        public SpiralMatrix(int rows = 3, int columns = 3)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new int[rows, columns];
        }

        public void FormSpiralLeftTop()
        {
            int printValue = 1;

            int startRowIndex = 0; 
            int finishRowIndex = _rows - 1;

            int startColumnIndex = 0; 
            int finishColumnIndex = _columns - 1;

            int itemsAmount = _rows * _columns;

            while (printValue <= itemsAmount)
            {
                // down
                for (int row = startRowIndex; row <= finishRowIndex && printValue <= itemsAmount; row++)
                {
                    _matrix[row, startColumnIndex] = printValue++;
                }
                startColumnIndex++;

                // right
                for (int column = startColumnIndex; column <= finishColumnIndex && printValue <= itemsAmount; column++)
                {
                    _matrix[finishRowIndex, column] = printValue++;
                }
                finishRowIndex--;

                // up 
                for (int row = finishRowIndex; row >= startRowIndex && printValue <= itemsAmount; row--)
                {
                    _matrix[row, finishColumnIndex] = printValue++;
                }
                finishColumnIndex--;

                // left
                for (int column = finishColumnIndex; column >= startColumnIndex && printValue <= itemsAmount; column--)
                {
                    _matrix[startRowIndex, column] = printValue++;
                }
                startRowIndex++;
            }
        }

        public void FormSpiralRightBottom()
        {
            int printValue = 1;

            int startRowIndex = _rows - 1;
            int finishRowIndex = 0;

            int startColumnIndex = _columns - 1;
            int finishColumnIndex = 0;

            int itemsAmount = _rows * _columns;

            while (printValue <= itemsAmount)
            {
                // up 
                for (int row = startRowIndex; row >= finishRowIndex && printValue <= itemsAmount; row--)
                {
                    _matrix[row, startColumnIndex] = printValue++;
                }
                startColumnIndex--;

                //  left 
                for (int column = startColumnIndex; column >= finishColumnIndex && printValue <= itemsAmount; column--)
                {
                    _matrix[finishRowIndex, column] = printValue++;
                }
                finishRowIndex++;

                // down 
                for (int row = finishRowIndex; row <= startRowIndex && printValue <= itemsAmount; row++)
                {
                    _matrix[row, finishColumnIndex] = printValue++;
                }
                finishColumnIndex++;

                // right 
                for (int column = finishColumnIndex; column <= startColumnIndex && printValue <= itemsAmount; column++)
                {
                    _matrix[startRowIndex, column] = printValue++;
                }
                startRowIndex--;
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