namespace MultilayerPerceptron.Network
{
    public class Link
    {
        public double Input { set; private get; }
        public double Output => Input * Weight;
        public double Weight { get; set; }
    }
}