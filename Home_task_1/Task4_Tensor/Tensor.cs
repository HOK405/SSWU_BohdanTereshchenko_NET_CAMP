using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Tensor
{
    internal class Tensor
    {
        private int[] _sizes;
        private Array? _tensor;

        public Tensor(int[] sizes)
        {
            if (sizes != null)
            {
                for (int i = 0; i < sizes.Length; i++)
                {
                    if (sizes[i] <= 0)
                    {
                        throw new ArgumentOutOfRangeException("The value must be greater than zero");
                    }
                }
            }
            else
            {
                throw new NullReferenceException("An array mustn't be null.");
            }

            _sizes = sizes;
            _tensor = FormTensor(sizes);
        }

        public Tensor()
        {
            _sizes = new int[0];
            _tensor = default;
        }

        public int DimensionsAmount
        {
            get { return _sizes.Length; }
        }

        private Array FormTensor(int[] sizes, int currentIndex = 0)
        {
            int currentSize = sizes[currentIndex];
            currentIndex++;

            if (currentIndex == sizes.Length)
            {
                return Array.CreateInstance(typeof(int), currentSize);
            }

            Array array = Array.CreateInstance(typeof(Array), currentSize);
            for (int i = 0; i < currentSize; i++)
            {
                array.SetValue(FormTensor(sizes, currentIndex), i);
            }

            return array;
        }
    }
}
