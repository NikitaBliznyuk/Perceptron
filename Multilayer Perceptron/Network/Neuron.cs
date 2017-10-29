using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MultilayerPerceptron.Network
{
    public class Neuron
    {
        private double threshold;
        
        public double Value { get; private set; }

        public List<Link> InputLinks { get; }
        public List<Link> OutputLinks { get; }

        private NeuronType type;
        
        public enum NeuronType
        {
            Standart, Distributive
        }

        public Neuron(NeuronType type)
        {
            this.type = type;
            
            InputLinks = new List<Link>();
            OutputLinks = new List<Link>();
        }

        public static Neuron[] GetNeuronArray(int count, NeuronType type)
        {
            Neuron[] neurons = new Neuron[count];

            for (int i = 0; i < neurons.Length; i++)
            {
                neurons[i] = new Neuron(type);
            }
            
            return neurons;
        }
        
        public enum LinkType {Input, Output}

        public void AddLink(LinkType linkType, Link link)
        {
            switch (linkType)
            {
                case LinkType.Input:
                    InputLinks.Add(link);
                    break;
                case LinkType.Output:
                    OutputLinks.Add(link);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void Teach(double delta)
        {
            threshold += delta;
            InputLinks.ForEach(link => link.Teach(delta));
        }

        public void Process()
        {
            Value = GetValue();
            OutputLinks.ForEach(link => link.Input = Value);
        }

        private double GetValue()
        {
            double result = InputLinks.Sum(link => link.Output) + threshold;
            return type == NeuronType.Standart ? Activate(result) : result;
        }

        private double Activate(double x)
        {
            return 1.0 / (1.0 + Math.Pow(Math.E, -x));
        }
    }
}