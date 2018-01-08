using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinding
{
    public class SquareGraph
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Position> Impassable { get; set; }

        public SquareGraph(int width, int height)
        {
            Width = width;
            Height = height;

            Impassable = new List<Position>();
        }

        private bool IsInBounds(Position pos)
        {
            if (pos.Left < 0 || pos.Top < 0)
                return false;
            return pos.Left < Width && pos.Top < Height;
        }

        private bool IsPassable(Position pos)
        {
            return !Impassable.ContainsPosition(pos);
        }

        public Position[] FindNeighbors(Position pos)
        {
            var allPossible = new Position[]
            {
                new Position(pos.Top + 1, pos.Left),
                new Position(pos.Top, pos.Left + 1),
                new Position(pos.Top - 1, pos.Left),
                new Position(pos.Top, pos.Left - 1)
            };
            return allPossible.Where(p => IsInBounds(p) && IsPassable(p)).ToArray();
        }

        public void AddToImpassable(params Position[] positions){
            Impassable.AddRange(positions);
        }
    }
}
