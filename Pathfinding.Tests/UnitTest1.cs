using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pathfinding.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string basePath =
            @"C:\Users\Pearse.Hutson\Documents\Personal Projects\hoi-polloi\Pathfinding\testing";

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            Directory.CreateDirectory(basePath);
        }

        [TestMethod]
        public void TestMethod1()
        {
            var file = File.CreateText(Path.Combine(basePath, "test01.txt"));
            var graph = new SquareGraph(30, 15);
            DrawGrid(graph, file);
            file.Close();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var file = File.CreateText(Path.Combine(basePath, "test02.txt"));
            var graph = new SquareGraph(30, 15);
            graph.AddToImpassable(DiagramWalls01);
            var startPos = new Position(7, 8);
            var parents = Algorithms.BreadthFirstOne(graph, startPos);
            DrawGrid(graph, file, pointTo: parents, startPos: startPos);
            file.Close();
        }

        private void DrawGrid(SquareGraph graph, StreamWriter file, Dictionary<Position, Position> pointTo = null, Position startPos = null)
        {
            foreach (var y in Enumerable.Range(0, graph.Height))
            {
                foreach (var x in Enumerable.Range(0, graph.Width))
                {
                    var currPos = new Position(y, x);
                    var charToWrite = '.';
                    if (pointTo != null)
                    {
                        var parent = pointTo.ContainsKey(currPos) ? pointTo[currPos] : null;
                        if (parent != null)
                        {
                            if (parent.Top == currPos.Top - 1) charToWrite = '^';
                            if (parent.Top == currPos.Top + 1) charToWrite = 'v';
                            if (parent.Left == currPos.Left + 1) charToWrite = '>';
                            if (parent.Left == currPos.Left - 1) charToWrite = '<';
                        }
                    }

                    if (startPos != null && currPos == startPos)
                    {
                        charToWrite = 'A';
                    }
                    if (DiagramWalls01.ContainsPosition(new Position(y, x)))
                        charToWrite = '#';
                    file.Write(charToWrite);
                }

                file.Write(Environment.NewLine);
            }
        }

        private Position[] DiagramWalls01 => new List<int>()
        {
            21,
            22,
            51,
            52,
            81,
            82,
            93,
            94,
            111,
            112,
            123,
            124,
            133,
            134,
            141,
            142,
            153,
            154,
            163,
            164,
            171,
            172,
            173,
            174,
            175,
            183,
            184,
            193,
            194,
            201,
            202,
            203,
            204,
            205,
            213,
            214,
            223,
            224,
            243,
            244,
            253,
            254,
            273,
            274,
            283,
            284,
            303,
            304,
            313,
            314,
            333,
            334,
            343,
            344,
            373,
            374,
            403,
            404,
            433,
            434
        }.Select(i => new Position(i / 30, i % 30)).ToArray();
    }
}