using System;

namespace MultilayerPerceptron
{
    public class CharGenerator
    {
        private Random rand = new Random();
        
        public int[] Get2()
        {
            return new[]
            {
                0, 0, 1, 1, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 0, 1, 1, 1, 1,
                0, 0, 1, 1, 0, 0,
                0, 0, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0
            };
        }

        public int[] Get3()
        {
            return new[]
            {
                0, 0, 1, 1, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 0, 1, 1, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 0, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0
            };
        }
        
        public int[] Get4()
        {
            return new[]
            {
                0, 1, 1, 0, 1, 1,
                0, 1, 1, 0, 1, 1,
                0, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 0, 0, 0, 0, 0
            };
        }
        
        public int[] Get5()
        {
            return new[]
            {
                0, 0, 0, 0, 0, 0,
                0, 1, 1, 1, 1, 1,
                0, 1, 1, 0, 0, 0,
                0, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 1, 1,
                0, 1, 1, 1, 1, 1
            };
        }
        
        public int[] Get7()
        {
            return new[]
            {
                0, 0, 0, 0, 0, 0,
                1, 1, 1, 1, 1, 0,
                0, 0, 0, 0, 1, 0,
                0, 0, 0, 1, 0, 0,
                0, 0, 1, 0, 0, 0,
                0, 1, 0, 0, 0, 0
            };
        }
        
        public int[] Get_noized(int[] number, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int randomIndex = rand.Next(number.Length);
                number[randomIndex] ^= 1;
            }
            return number;
        }
    }
}