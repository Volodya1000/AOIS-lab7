using Lab7Table;

namespace TableTests
{
    public class DiogonalMatrixTests
    {
        [Fact]
        public void GetSetWord()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, false };
            diagonalMatrix.SetWord(3, m);
            Assert.Equal(m, diagonalMatrix.GetWord(3));
        }

        [Fact]
        public void GetSetColumn()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, false };
            diagonalMatrix.SetDiogonalColumn(3, m);
            Assert.Equal(m, diagonalMatrix.GetDiogonalColumn(3));
        }


        [Fact]
        public void SumWords()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, false };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SumAB(true, true, true);
            bool[] rez = diagonalMatrix.GetWord(3);
            bool[] rezeql= { true, true, true, true, true, false, false, false, false, true, true, false, true, true, true, true };
            Assert.Equal(rezeql, rez);
        }

        [Fact]
        public void ExecuteFunctionf10()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { false, false, true, true,  true, false, false, false, false, true, true, false, false, false, false, false };
            bool[]n =  { true,  true, true, true, true, true, true,  true, true, true, true, true, true,  true, true, true };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SetWord(4, n);
            diagonalMatrix.ExecuteFunction(3, 4, 15, 10);
            bool[] rez = diagonalMatrix.GetWord(15);
            bool[] rezeql = {false,false, false, false , false, false, false, false , false, false, false, false, false, false, false, false };
            Assert.Equal(rezeql, rez);
        }

        [Fact]
        public void ExecuteFunctionf15()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { false, false, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            bool[] n = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SetWord(4, n);
            diagonalMatrix.ExecuteFunction(3, 4, 15, 15);
            bool[] rez = diagonalMatrix.GetWord(15);
            bool[] rezeql = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            Assert.Equal(rezeql, rez);
        }

        [Fact]
        public void ExecuteFunctionf0()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { false, false, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            bool[] n = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SetWord(4, n);
            diagonalMatrix.ExecuteFunction(3, 4, 15, 0);
            bool[] rez = diagonalMatrix.GetWord(15);
            bool[] rezeql = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
            Assert.Equal(rezeql, rez);
        }

        [Fact]
        public void ExecuteFunctionf5()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { false, false, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            bool[] n = { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SetWord(4, n);
            diagonalMatrix.ExecuteFunction(3, 4, 15, 5);
            bool[] rez = diagonalMatrix.GetWord(15);
            Assert.Equal(n, rez);
        }

        [Fact]
        public void FindSame()
        {
            DiagonalMatrix diagonalMatrix = new();
            bool[] m = { false,true , false, true, true, false, false, false, false, true, true, false, false, false, false, false };
            bool[] n = { true, false, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            bool[] k = { false, false, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            diagonalMatrix.SetWord(3, m);
            diagonalMatrix.SetWord(4, n);
            diagonalMatrix.SetWord(5, k);
            bool?[] key= { null, null, true, true, true, false, false, false, false, true, true, false, false, false, false, false };
            List<int> rez = diagonalMatrix.FindSame(key);
            List<int> eql = new List<int> { 4,5 };
            Assert.Equal(eql, rez);
        }



    }
}