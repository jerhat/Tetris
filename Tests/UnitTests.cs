using NUnit.Framework;
using System.Collections.Generic;
using Tetris;

namespace Tests
{

    public class Tests
    {
        List<TetrisTest> _tests = new List<TetrisTest>();

        [SetUp]
        public void Setup()
        {
            _tests.Add(new TetrisTest(10, "Q0", 2));
            _tests.Add(new TetrisTest(10, "Q0,Q1", 4));
            _tests.Add(new TetrisTest(10, "S0,S2,S4,S5,Q8,Q8,Q8,Q8,T1,Q1,I0,Q4", 8));
            _tests.Add(new TetrisTest(10, "Q0,Q2,Q4,Q6,Q8", 0));
            _tests.Add(new TetrisTest(10, "Q0,Q2,Q4,Q6,Q8,Q1", 2));
            _tests.Add(new TetrisTest(10, "Q0,Q2,Q4,Q6,Q8,Q1,Q1", 4));
            _tests.Add(new TetrisTest(10, "I0,I4,Q8", 1));
            _tests.Add(new TetrisTest(10, "I0,I4,Q8,I0,I4", 0));
            _tests.Add(new TetrisTest(10, "L0,J2,L4,J6,Q8", 2));
            _tests.Add(new TetrisTest(10, "L0,Z1,Z3,Z5,Z7", 2));
            _tests.Add(new TetrisTest(10, "T0,T3", 2));
            _tests.Add(new TetrisTest(10, "T0,T3,I6,I6", 1));
            _tests.Add(new TetrisTest(10, "I0,I6,S4", 1));
            _tests.Add(new TetrisTest(10, "T1,Z3,I4", 4));
            _tests.Add(new TetrisTest(10, "L0,J3,L5,J8,T1", 3));
            _tests.Add(new TetrisTest(10, "L0,J3,L5,J8,T1,T6", 1));
            _tests.Add(new TetrisTest(10, "L0,J3,L5,J8,T1,T6,J2,L6,T0,T7", 2));
            _tests.Add(new TetrisTest(10, "L0,J3,L5,J8,T1,T6,J2,L6,T0,T7,Q4", 1));
            _tests.Add(new TetrisTest(10, "S0,S2,S4,S6", 8));
            _tests.Add(new TetrisTest(10, "L0,J3,L5,J8,T1,T6,S2,Z5,T0,T7", 0));
            _tests.Add(new TetrisTest(10, "Q0,I2,I6,I0,I6,I6,Q2,Q4 ", 3));
        }

        [Test]
        public void Test()
        {
            foreach (var test in _tests)
            {
                var game = new Game(test.BoardNbColumns, test.Input);
                var actualResult = game.GetResult();

                Assert.AreEqual(test.ExpectedResult, actualResult);
            }
        }
    }
}