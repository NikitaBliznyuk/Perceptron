namespace MultilayerPerceptron.Network
{
    public class Neuron
    {
        private NeuronType type;

        public Neuron(NeuronType type)
        {
            this.type = type;
        }
    }

    public enum NeuronType
    {
        Input, Hidden, Output
    }
}