using System;
using System.Linq;

namespace MultilayerPerceptron.Network
{
    public class Perceptron
    {
        private readonly Neuron[] inputNeurons;
        private readonly Neuron[] hiddenNeurons;
        private readonly Neuron[] outputNeurons;

        private readonly Link[] inputLinks;
        private readonly Link[] outputLinks;

        private const double MaxErrorValue = 0.01;
        private const int maxCount = 2000000;

        private double[] idealOutput;

        public Link[] OutputLinks => outputLinks;
        
        public Perceptron(int inputLayerNeuronCount, int hiddenLayerNeuronCount, int outputLayerNeuronCount)
        {
            inputNeurons = Neuron.GetNeuronArray(inputLayerNeuronCount, Neuron.NeuronType.Distributive);
            hiddenNeurons = Neuron.GetNeuronArray(hiddenLayerNeuronCount, Neuron.NeuronType.Standart);
            outputNeurons = Neuron.GetNeuronArray(outputLayerNeuronCount, Neuron.NeuronType.Standart);
            
            inputLinks = Link.GetLinkArray(inputLayerNeuronCount, 1.0);
            outputLinks = Link.GetLinkArray(outputLayerNeuronCount, 1.0);
            Link[][] inputHiddenLinks = Link.GetLinksMatrix(inputLayerNeuronCount, hiddenLayerNeuronCount);
            Link[][] hiddenOutputLinks = Link.GetLinksMatrix(hiddenLayerNeuronCount, outputLayerNeuronCount);

            for (int i = 0; i < inputLayerNeuronCount; i++)
            {
                inputNeurons[i].AddLink(Neuron.LinkType.Input, inputLinks[i]);
                for (int j = 0; j < hiddenLayerNeuronCount; j++)
                {
                    inputNeurons[i].AddLink(Neuron.LinkType.Output, inputHiddenLinks[i][j]);
                }
            }

            for (int i = 0; i < hiddenLayerNeuronCount; i++)
            {
                for (int j = 0; j < inputLayerNeuronCount; j++)
                {
                    hiddenNeurons[i].AddLink(Neuron.LinkType.Input, inputHiddenLinks[j][i]);
                }

                for (int j = 0; j < outputLayerNeuronCount; j++)
                {
                    hiddenNeurons[i].AddLink(Neuron.LinkType.Output, hiddenOutputLinks[i][j]);
                }
            }

            for (int i = 0; i < outputLayerNeuronCount; i++)
            {
                for (int j = 0; j < hiddenLayerNeuronCount; j++)
                {
                    outputNeurons[i].AddLink(Neuron.LinkType.Input, hiddenOutputLinks[j][i]);
                }

                outputNeurons[i].AddLink(Neuron.LinkType.Output, outputLinks[i]);
            }
        }

        public int Teach(TeachVector[] teachVector, double alpha, double beta)
        {
            int steps = 0;

            while (steps < maxCount)
            {
                double maxError = double.MinValue;
                foreach (var vector in teachVector)
                {
                    idealOutput = vector.Output;
                    int[] input = vector.Input;

                    if (input.Length != inputLinks.Length)
                        throw new ArgumentException();

                    for (int i = 0; i < inputLinks.Length; i++)
                    {
                        inputLinks[i].Input = input[i];
                    }

                    foreach (var inputNeuron in inputNeurons)
                    {
                        inputNeuron.Process();
                    }

                    foreach (var hiddenNeuron in hiddenNeurons)
                    {
                        hiddenNeuron.Process();
                    }

                    foreach (var outputNeuron in outputNeurons)
                    {
                        outputNeuron.Process();
                    }

                    double[] d = GetD();
                    maxError = Math.Max(d.Max(), maxError);

                    double[] e = GetE();

                    for (int j = 0; j < hiddenNeurons.Length; j++)
                    {
                        hiddenNeurons[j].Teach(beta * hiddenNeurons[j].Value * (1.0 - hiddenNeurons[j].Value) * e[j]);
                    }

                    for (int k = 0; k < outputNeurons.Length; k++)
                    {
                        outputNeurons[k].Teach(alpha * outputNeurons[k].Value * (1.0 - outputNeurons[k].Value) * d[k]);
                    }

                }

                steps++;

                if (maxError < MaxErrorValue)
                    return steps;
            }

            return steps;
        }

        private double[] GetD()
        {
            double[] d = new double[outputLinks.Length];

            for (int i = 0; i < outputLinks.Length; i++)
            {
                d[i] = idealOutput[i] - outputLinks[i].Output;
            }
            
            return d;
        }

        private double[] GetE()
        {
            double[] e = new double[hiddenNeurons.Length];
            double[] d = GetD();

            for (int j = 0; j < hiddenNeurons.Length; j++)
            {
                e[j] = 0.0f;
                for (int k = 0; k < outputNeurons.Length; k++)
                {
                    e[j] += d[k] * outputNeurons[k].Value * (1 - outputNeurons[k].Value) *
                             outputNeurons[k].InputLinks[j].Weight;
                }
            }
            
            return e;
        }
        
        public enum Error
        {
            No, InputWrongLength, Overflow
        }

        public void Test(int[] data)
        {
            for (int i = 0; i < inputLinks.Length; i++)
            {
                inputLinks[i].Input = data[i];
            }
            
            foreach (var inputNeuron in inputNeurons)
            {
                inputNeuron.Process();
            }
            
            foreach (var hiddenNeuron in hiddenNeurons)
            {
                hiddenNeuron.Process();
            }
            
            foreach (var outputNeuron in outputNeurons)
            {
                outputNeuron.Process();
            }
        }
    }

    public class TeachVector
    {
        public int[] Input;
        public double[] Output;
    }
}