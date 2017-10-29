using System;
using MultilayerPerceptron.Network;

namespace MultilayerPerceptron
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CharGenerator charGenerator = new CharGenerator();
            Perceptron perceptron = new Perceptron(36, 6, 5);
            int count = perceptron.Teach(new[]
            {
                new TeachVector
                {
                    Input = charGenerator.Get2(),
                    Output = new[] {1.0, 0.0, 0.0, 0.0, 0.0}
                },
                new TeachVector
                {
                    Input = charGenerator.Get3(),
                    Output = new[] {0.0, 1.0, 0.0, 0.0, 0.0}
                },
                new TeachVector
                {
                    Input = charGenerator.Get4(),
                    Output = new[] {0.0, 0.0, 1.0, 0.0, 0.0}
                },
                new TeachVector
                {
                    Input = charGenerator.Get5(),
                    Output = new[] {0.0, 0.0, 0.0, 1.0, 0.0}
                },
                new TeachVector
                {
                    Input = charGenerator.Get7(),
                    Output = new[] {0.0, 0.0, 0.0, 0.0, 1.0}
                }
            }, 0.5, 0.5);
            Console.WriteLine(count);

            perceptron.Test(charGenerator.Get_noized(charGenerator.Get2(), 5));
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.Write(perceptronOutputLink.Output.ToString("0.00") + "  ");
            }
            
            Console.WriteLine();
            perceptron.Test(charGenerator.Get_noized(charGenerator.Get5(), 2));
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.Write(perceptronOutputLink.Output.ToString("0.00") + "  ");
            }
            
            Console.WriteLine();
            perceptron.Test(charGenerator.Get_noized(charGenerator.Get7(), 12));
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.Write(perceptronOutputLink.Output.ToString("0.00") + "  ");
            }
            
            Console.WriteLine();
            perceptron.Test(charGenerator.Get_noized(charGenerator.Get3(), 20));
            foreach (var perceptronOutputLink in perceptron.OutputLinks)
            {
                Console.Write(perceptronOutputLink.Output.ToString("0.00") + "  ");
            }
        }
    }
}