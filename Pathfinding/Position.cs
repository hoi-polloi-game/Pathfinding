using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinding
{
    public class Position
    {
        public int Top { get; set; }
        public int Left { get; set; }

        public Position()
        { }

        public Position(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public static bool operator ==(Position x, Position y)
        {
            return x?.Top == y?.Top && x?.Left == y?.Left;
        }

        public static bool operator !=(Position x, Position y)
        {
            return !(x == y);
        }

        public override bool Equals(Object obj)
        {
            return obj is Position && this == (Position) obj;
        }
        public override int GetHashCode()
        {
            return Top.GetHashCode() ^ Left.GetHashCode();
        }
    }

    public static class PositionExtensions
    {
        public static bool ContainsPosition(this IEnumerable<Position> positions, Position searchingPosition)
        {
            return positions.Any(p => p.Top == searchingPosition.Top && p.Left == searchingPosition.Left);
        }
    }
}