using System;
using System.Reflection;

namespace Lab7Table
{
   

    public class DiagonalMatrix
    {
        private bool[,] matrix = new bool[16, 16];


        public bool[] GetWord(int wordNumber)
        {
            if (wordNumber < 0 || wordNumber >= 16)
            {
                throw new ArgumentException("Номер слова выходит за пределы матрицы.");
            }

            bool[] word = new bool[16];

            for (int i = wordNumber; i < 16; i++)
            {
                word[i - wordNumber] = matrix[i, wordNumber];
            }

            for (int i = 0; i < wordNumber; i++)
            {
                word[16 - wordNumber + i] = matrix[i, wordNumber];
            }

            return word;
        }

        public void SetWord(int wordNumber, bool[] word)
        {
            if (wordNumber < 0 || wordNumber >= 16)
            {
                throw new ArgumentException("Номер слова выходит за пределы матрицы.");
            }

            if (word.Length != 16)
            {
                throw new ArgumentException("Массив чисел слишком большой для записи в матрицу.");
            }
            for (int i = wordNumber; i < 16; i++)
            {
                matrix[i, wordNumber] = word[i - wordNumber];
            }

            for (int i = 0; i < wordNumber; i++)
            {
                matrix[i, wordNumber] = word[16 - wordNumber + i];
            }
        }


        public void SetDiogonalColumn(int columnNumber, bool[] column)
        {
            if (columnNumber < 0 || columnNumber >= 16)
            {
                throw new ArgumentException("Номер столбца выходит за пределы матрицы.");
            }

            for (int col = 0; col < 16 - columnNumber; col++)
                matrix[columnNumber + col, col] = column[col];
            for (int col = 16 - columnNumber, i = 0; col < 16; col++, i++)
                matrix[i, col] = column[16 - columnNumber + i];
        }

        public bool[] GetDiogonalColumn(int columnNumber)
        {
            if (columnNumber < 0 || columnNumber >= 16)
            {
                throw new ArgumentException("Номер столбца выходит за пределы матрицы.");
            }
            bool[] column = new bool[16];

            for (int col = 0; col < 16 - columnNumber; col++)
                column[col] = matrix[columnNumber + col, col];
            for (int col = 16 - columnNumber, i = 0; col < 16; col++, i++)
                column[16 - columnNumber + i] = matrix[i, col];
            return column;
        }

        public bool f5(bool x1, bool x2)
        {
            return x2;
        }
        public bool f10(bool x1, bool x2)
        {
            return !x2;
        }

        public bool f0(bool x1, bool x2)
        {
            return false;
        }

        public bool f15(bool x1, bool x2)
        {
            return true;
        }

        public bool[] SumAB(bool k0, bool k1, bool k2)
        {
            bool[] sumAB = new bool[16];

            for (int i = 0; i < 16; i++)
            {
                bool[] Iword = GetWord(i);
                if (Iword[0] == k0 && Iword[1] == k1 && Iword[2] == k2)
                {
                    bool[] A = { Iword[3], Iword[4], Iword[5], Iword[6] };
                    bool[] B = { Iword[7], Iword[8], Iword[9], Iword[10] };

                    bool[] S = SumBinaryArrays(A, B);

                    int si = 0;

                    for(int j=11;j<16;j++)
                    {
                        Iword[j]= S[si];
                        si++;
                    }
                    SetWord(i, Iword);
                }
            }
            return sumAB;
        }

        public bool[] ExecuteFunction(int columnNumber1, int columnNumber2, int rezColumnNumber, int functionNumber)
        {
            if (columnNumber1 < 0 || columnNumber1 > 15 || columnNumber2 < 0 || columnNumber2 > 15 || rezColumnNumber < 0 || rezColumnNumber > 15)
                throw new ArgumentException("Входные параметры должны находиться в диапазоне от 0 до 15.");
            if (columnNumber1 == columnNumber2 || columnNumber1 == rezColumnNumber || columnNumber2 == rezColumnNumber)
                throw new ArgumentException("Входные параметры не могут быть равны друг другу.");
            if (functionNumber < 0 || functionNumber > 15)
                throw new ArgumentException("Номер функциидолжны находиться в диапазоне от 0 до 15.");
            bool[] result = new bool[16];

            Type type = this.GetType();
            string fname = "f" + functionNumber.ToString();
            var method = type.GetMethod(fname);
            if (method == null)
            {
                throw new ArgumentException("Такая функция не определена"+ fname);
            }

            bool[] A = GetWord(columnNumber1);
            bool[] B = GetWord(columnNumber2);

            for (int i = 0; i < 16; i++)
            {

                result[i] = (bool)method.Invoke(this, new object[] { A[i], B[i] });
            }
            SetWord(rezColumnNumber, result);
            return result;
        }


        private static bool[] SumBinaryArrays(bool[] arr1, bool[] arr2)
        {

            bool[] result = new bool[arr1.Length + 1];
            bool carry = false;

            for (int i = arr1.Length - 1; i >= 0; i--)
            {
                bool bit1 = arr1[i];
                bool bit2 = arr2[i];

                bool sum = bit1 ^ bit2 ^ carry;
                carry = (bit1 & bit2) | (bit2 & carry) | (bit1 & carry);

                result[i + 1] = sum;
            }

            result[0] = carry;

            return result;
        }

        public List<int> FindSame(bool?[] key)
        {
            List<int> rezKeys = new List<int>();

            if (key.Length != 16)
            {
                throw new ArgumentException("Ключ долен состоять из 16 эллементов.");
            }
            for(int j= 0; j<16; j++)
            {
                bool[] checkWord = GetWord(j);
                bool same = true;
                for (int i = 0; i <16; i++)
                {
                    if(key[i]==null|| checkWord[i]== key[i])
                    {
                        continue;
                    }
                    else
                    {
                        same = false;
                        break;
                    } 
                }
                if (same)
                    rezKeys.Add(j);
            }
            return rezKeys;
        }


        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] ? '1' : '0' + "\t");
                }
                Console.WriteLine();
            }
        }
        public static string BoolArrayToString(bool[] array)
        {
            return new string(array.Select(b => b ? '1' : '0').ToArray());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            DiagonalMatrix diagonalMatrix = new DiagonalMatrix();

            bool[] m = { true, true, true, true, true, false, false, false, false, true, true, true, false, false, false, false };
            diagonalMatrix.SetWord(3, m);


            Console.WriteLine("Исходная матрица:");
            diagonalMatrix.PrintMatrix();

            Console.WriteLine("\nСлова 3:" + DiagonalMatrix.BoolArrayToString(diagonalMatrix.GetWord(3)));
        }
    }


}
