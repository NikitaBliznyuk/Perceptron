using System;
using MultilayerPerceptron.Network;

namespace MultilayerPerceptron
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Perceptron perceptron = new Perceptron(2, 2, 1);
            int count = perceptron.Teach(new[]
            {
                new TeachVector
                {
                    Input = new[] {0, 0},
                    Output = new[] {0.0}
                },
                new TeachVector
                {
                    Input = new[] {0, 1},
                    Output = new[] {1.0}
                },
                new TeachVector
                {
                    Input = new[] {1, 0},
                    Output = new[] {1.0}
                },
                new TeachVector
                {
                    Input = new[] {1, 1},
                    Output = new[] {0.0}
                }
            }, 0.5, 0.5);
            Console.WriteLine(count);

            perceptron.Test(new[] {0, 1});
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.WriteLine(perceptronOutputLink.Output);
            }

            perceptron.Test(new[] {1, 1});
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.WriteLine(perceptronOutputLink.Output);
            }

            perceptron.Test(new[] {1, 0});
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.WriteLine(perceptronOutputLink.Output);
            }

            perceptron.Test(new[] {0, 0});
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.WriteLine(perceptronOutputLink.Output);
            }
        }
    }
}