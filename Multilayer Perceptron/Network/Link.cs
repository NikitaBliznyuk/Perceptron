using System;

namespace MultilayerPerceptron.Network
{
    public class Link
    {
        public double Input { set; private get; }
        public double Output => Input * Weight;
        public double Weight { get; private set; }

        private static readonly Random rand = new Random();

        public Link(double weight)
        {
            Weight = weight;
        }

        public void Teach(double weightDelta)
        {
            Weight += Input * weightDelta;
        }

        public static Link[] GetLinkArray(int count, double? weight = null)
        {
            Link[] links = new Link[count];

            for (int i = 0; i < links.Length; i++)
            {
                links[i] = weight != null ? new Link(weight.Value) : new Link(rand.NextDouble() * 2.0 - 1.0);
            }
            
            return links;
        }
        
        public static Link[][] GetLinksMatrix(int width, int height)
        {
            Link[][] links = new Link[width][];

            for (int i = 0; i < width; i++)
            {
                links[i] = GetLinkArray(height);
            }
            
            return links;
        }
    }
}