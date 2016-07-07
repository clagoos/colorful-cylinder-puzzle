using System;
using AForge.Neuro;
using AForge.Neuro.Learning;
using NUnit.Framework;

namespace ColorfulCylinderPuzzle.Tests
{
    [TestFixture]
    public class XorNeuroTest
    {
        private readonly double[][] input =
        {
            new double[] {0, 0}, new double[] {0, 1},
            new double[] {1, 0}, new double[] {1, 1}
        };
        private readonly double[][] output =
        {
            new double[] {0}, new double[] {1},
            new double[] {1}, new double[] {0}
        };

        [Test]
        public void Test()
        {
            ActivationNetwork network = new ActivationNetwork(
                new SigmoidFunction(),
                2, // two inputs in the network
                2, // two neurons in the first layer
                1); // one neuron in the second layer

            BackPropagationLearning teacher = new BackPropagationLearning(network);

            double lastError = double.MaxValue;
            int counter = 0;
            while (true)
            {
                counter++;
                var error = teacher.RunEpoch(input, output);
                if (lastError - error < 0.0000001 && error < 0.001)
                    break;
                lastError = error;
            }

            //var bla = network.Compute(input[0])[0];
            //var round = Math.Round(network.Compute(input[0])[0], 2);
            //var result = output[0][0];
            //Assert.IsTrue(Math.Abs(round - result) < double.Epsilon);
            Assert.IsTrue(Math.Abs(network.Compute(input[0])[0] - output[0][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[1])[0] - output[1][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[2])[0] - output[2][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[3])[0] - output[3][0]) < 0.03);
            Console.WriteLine($"Loop counter = {counter}.");
        }

        [Test]
        public void TestGenetic()
        {
            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(), 2, 2, 1);
            EvolutionaryLearning superTeacher = new EvolutionaryLearning(network, 10);

            double lastError = double.MaxValue;
            int counter = 0;
            while (true)
            {
                counter++;
                var error = superTeacher.RunEpoch(input, output);
                if (lastError - error < 0.0000001 && error < 0.0001)
                    break;
                lastError = error;
            }

            Assert.IsTrue(Math.Abs(network.Compute(input[0])[0] - output[0][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[1])[0] - output[1][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[2])[0] - output[2][0]) < 0.03);
            Assert.IsTrue(Math.Abs(network.Compute(input[3])[0] - output[3][0]) < 0.03);
            Console.WriteLine($"Loop counter = {counter}.");
        }
    }
}