using AForge.Neuro;
using AForge.Neuro.Learning;
using NUnit.Framework;

namespace ColorfulCylinderPuzzle.Tests
{
    [TestFixture]
    public class NeuroTesting
    {
        [Test]
        public void Test()
        {
            // initialize input and output values
            double[][] input = new double[4][]
            {
                new double[] {0, 0}, new double[] {0, 1},
                new double[] {1, 0}, new double[] {1, 1}
            };
            double[][] output = new double[4][]
            {
                new double[] {0}, new double[] {1},
                new double[] {1}, new double[] {0}
            };

            // create neural network
            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(2),
                2, // two inputs in the network
                2, // two neurons in the first layer
                1); // one neuron in the second layer

            // create teacher
            BackPropagationLearning teacher = new BackPropagationLearning(network);

            double lastError = double.MaxValue;
            int counter = 0;
            while (true)
            {
                counter++;
                // run epoch of learning procedure
                var error = teacher.RunEpoch(input, output);
                if (lastError - error < 0.0000001)
                    break;
                lastError = error;
                // check error value to see if we need to stop
                // ...
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.IsTrue(network.Compute(input[0]) == output[0]);
                Assert.IsTrue(network.Compute(input[1]) == output[1]);
                Assert.IsTrue(network.Compute(input[2]) == output[2]);
                Assert.IsTrue(network.Compute(input[3]) == output[3]);
            }
        }
    }
}