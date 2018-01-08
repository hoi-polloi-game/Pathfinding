using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    public static class Algorithms
    {
        public static Dictionary<Position, Position> BreadthFirstOne(SquareGraph graph, Position start)
        {
            var frontier = new Queue<Position>();
            frontier.Enqueue(start);
            
            var cameFrom = new Dictionary<Position, Position>()
            {
                {start, null}
            };

            while (frontier.Any())
            {
                var current = frontier.Dequeue();
                foreach (var next in graph.FindNeighbors(current))
                {
                    if (!cameFrom.Select(p => p.Key).Any(p => p == next))
                    {
                        frontier.Enqueue(next);
                        cameFrom.Add(next, current);
                    }
                }
            }

            return cameFrom;
        }
    }
}