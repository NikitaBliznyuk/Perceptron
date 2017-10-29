namespace MultilayerPerceptron.Network
{
    public class Link
    {
        public double Input { set; private get; }
        public double Output => Input * weight;
        private double weight;

        public void Teach(double weightDelta)
        {
            weight += Input * weightDelta;
        }

        public static Link[] GetLinkArray(int count)
        {
            Link[] links = new Link[count];

            for (int i = 0; i < links.Length; i++)
            {
                links[i] = new Link();
            }
            
            return links;
        }
        
        public static Link[][] GetLinksMatrix(int width, int height)
        {
            Link[][] links = new Link[width][];

            for (int i = 0; i < width; i++)
            {
                links[i] = Link.GetLinkArray(height);
            }
            
            return links;
        }
    }
}