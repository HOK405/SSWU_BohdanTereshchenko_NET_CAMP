namespace Exercise_1
{// опукла оболонка в цілому правильна
    internal class Garden
    {
        private List<Point> _treesData;

        public Garden(List<Point> treesData)
        {
            _treesData = treesData;
        }
        public Garden()
        {
            _treesData = new List<Point>();
        }

        public void PlantTheTree(Point tree) // посадити дерево
        {
            _treesData.Add(tree);
        }

        public void DigUpTheTree(int tree)
        {
            if(tree < 0)
            {
                throw new ArgumentOutOfRangeException("The value must be greater or equal zero.");
            }
            _treesData.RemoveAt(tree);
        }

        public double GetFencePerimeter()
        {
            List<Point> points = GetShortestFence();

            double perimeter = 0;
            int count = points.Count;
            for (int i = 0; i < count; i++)
            {
                int nextIndex = (i + 1) % count;
                double dx = points[i].X - points[nextIndex].X;
                double dy = points[i].Y - points[nextIndex].Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);
                perimeter += distance;
            }

            return perimeter;
        }

        public List<Point> GetShortestFence()
        {
            if (_treesData.Count < 3)
            {
                throw new ArgumentException("There must be at least 3 points.");
            }

            List<Point> fencePointsData = new List<Point>();

            int leftMostPoint = 0;
            for (int i = 1; i < _treesData.Count; i++)
            {
                if (_treesData[i].X < _treesData[leftMostPoint].X)
                {
                    leftMostPoint = i;
                }
            }

            int p = leftMostPoint; 
            int q;
            do
            {
                fencePointsData.Add(_treesData[p]);

                q = (p + 1) % _treesData.Count;

                for (int i = 0; i < _treesData.Count; i++)
                {
                    if (GetOrientation(_treesData[p], _treesData[i], _treesData[q]) == 2)
                    {
                        q = i;
                    }
                }

                p = q;

            } while (p != leftMostPoint); 

            return fencePointsData;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Garden otherGarden = (Garden)obj;
            return GetFencePerimeter() == otherGarden.GetFencePerimeter();
        }

        public override int GetHashCode()
        {
            return GetFencePerimeter().GetHashCode();
        }

        public static bool operator >=(Garden leftGarden, Garden rightGarden)
        {
            return leftGarden.GetFencePerimeter() >= rightGarden.GetFencePerimeter();
        }

        public static bool operator <=(Garden leftGarden, Garden rightGarden)
        {
            return leftGarden.GetFencePerimeter() <= rightGarden.GetFencePerimeter();
        }

        public static bool operator >(Garden leftGarden, Garden rightGarden)
        {
            return leftGarden.GetFencePerimeter() > rightGarden.GetFencePerimeter();
        }

        public static bool operator <(Garden leftGarden, Garden rightGarden)
        {
            return leftGarden.GetFencePerimeter() < rightGarden.GetFencePerimeter();
        }

        public static bool operator ==(Garden leftGarden, Garden rightGarden)
        {
            return leftGarden.GetFencePerimeter() == rightGarden.GetFencePerimeter();
        }

        public static bool operator !=(Garden leftGarden, Garden rightGarden)
        {
            return !(leftGarden == rightGarden);
        }

        private int GetOrientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (val == 0)
            {
                return 0;
            }
            return (val > 0) ? 1 : 2; 
        }
    }
}
