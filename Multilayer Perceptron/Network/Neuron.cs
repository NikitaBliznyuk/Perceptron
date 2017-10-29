using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MultilayerPerceptron.Network
{
    public class Neuron
    {
        private readonly List<Link> inputLinks;
        private readonly List<Link> outputLinks;
        private double threshold;

        public Neuron()
        {
            inputLinks = new List<Link>();
            outputLinks = new List<Link>();
        }
        
        public enum LinkType {Input, Output}

        public void AddLink(LinkType linkType, Link link)
        {
            switch (linkType)
            {
                case LinkType.Input:
                    inputLinks.Add(link);
                    break;
                case LinkType.Output:
                    outputLinks.Add(link);
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public void Teach(double weightDelta, double threasholdDelta)
        {
            threshold += threasholdDelta;
        }

        public double GetValue()
        {
            double result = inputLinks.Sum(link => link.Output) + threshold;
            return Activate(result);
        }

        private double Activate(double x)
        {
            return 1.0 / (1 + Math.Pow(Math.E, -x));
        }
    }
}