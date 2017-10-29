namespace MultilayerPerceptron.Network
{
    public class Perceptron
    {
        private readonly Neuron[] inputNeurons;
        private readonly Neuron[] hiddenNeurons;
        private readonly Neuron[] outputNeurons;

        private readonly Link[] inputLinks;
        private readonly Link[] outputLinks;
        
        public Perceptron(int inputLayerNeuronCount, int hiddenLayerNeuronCount, int outputLayerNeuronCount)
        {
            inputNeurons = Neuron.GetNeuronArray(inputLayerNeuronCount);
            hiddenNeurons = Neuron.GetNeuronArray(hiddenLayerNeuronCount);
            outputNeurons = Neuron.GetNeuronArray(outputLayerNeuronCount);
            
            inputLinks = Link.GetLinkArray(inputLayerNeuronCount);
            outputLinks = Link.GetLinkArray(outputLayerNeuronCount);
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
    }
}