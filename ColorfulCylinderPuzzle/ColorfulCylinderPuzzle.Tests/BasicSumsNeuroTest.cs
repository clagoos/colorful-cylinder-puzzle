using System;
using AForge.Neuro;
using AForge.Neuro.Learning;
using NUnit.Framework;

namespace ColorfulCylinderPuzzle.Tests
{
    [TestFixture]
    public class BasicSumsNeuroTest
    {
        // a + b, c * d
        // 

        private readonly double[][] input =
        {
            new double[] {0, 0, 0, 0, 1, 0, 0, 1},
            new double[] {0, 0, 0, 1, 0, 1, 1, 0},
            new double[] {0, 0, 1, 0, 0, 1, 1, 0},
            new double[] {1, 0, 0, 0, 0, 1, 0, 0},
            new double[] {0, 1, 0, 0, 1, 0, 1, 0},
            new double[] {1, 0, 0, 0, 0, 1, 0, 1},
            new double[] {1, 0, 0, 1, 0, 0, 0, 1},
            new double[] {1, 0, 0, 1, 1, 0, 0, 0},
            new double[] {1, 0, 0, 1, 0, 1, 1, 0},
            new double[] {0, 1, 0, 1, 0, 1, 1, 0},
            new double[] {0, 0, 1, 0, 1, 0, 0, 1},
            new double[] {0, 1, 1, 0, 0, 1, 0, 1},
            new double[] {1, 0, 0, 1, 0, 0, 1, 0},
            new double[] {1, 0, 1, 0, 1, 0, 0, 0},
            new double[] {1, 0, 1, 0, 0, 1, 0, 1},
            new double[] {1, 0, 1, 0, 1, 0, 1, 0}
        };
        private readonly double[][] output =
        {
            new double[] {0, 0, 0, 0, 1, 0}, // 0 2
            new double[] {0, 0, 1, 0, 1, 0}, // 1 2
            new double[] {0, 1, 0, 0, 1, 0}, // 2 2
            new double[] {0, 1, 0, 0, 0, 0}, // 2 0
            new double[] {0, 0, 1, 1, 0, 0}, // 1 4
            new double[] {0, 1, 0, 0, 0, 1}, // 2 1
            new double[] {0, 1, 1, 0, 0, 0}, // 3 0
            new double[] {0, 1, 1, 0, 0, 0}, // 3 0
            new double[] {0, 1, 1, 0, 1, 0}, // 3 2
            new double[] {0, 1, 1, 0, 1, 0}, // 3 2
            new double[] {0, 1, 0, 0, 1, 0}, // 1 2
            new double[] {0, 1, 1, 0, 0, 1}, // 3 1
            new double[] {0, 1, 1, 0, 0, 0}, // 3 0
            new double[] {1, 0, 0, 0, 0, 0}, // 4 0
            new double[] {1, 0, 0, 0, 0, 1}, // 4 1
            new double[] {1, 0, 0, 1, 0, 0} // 4 4
        };

        private const int inputCount = 8;
        private const int firstLayerNeurons = 8;
        private const int secondLayerNeurons = 4;
        private const int thirdLayerNeurons = 4;
        private const int lastLayerNeurons = 6;

        [Test]
        public void Test()
        {
            var network = new ActivationNetwork(new SigmoidFunction(), inputCount, firstLayerNeurons, secondLayerNeurons, thirdLayerNeurons, lastLayerNeurons);
            var teacher = new BackPropagationLearning(network);
            var lastError = double.MaxValue;
            var counter = 0;
            while (true)
            {
                counter++;
                var error = teacher.RunEpoch(input, output);
                if ((lastError - error < 0.00001 && error < 0.01) || counter > 1200000)
                    break;
                lastError = error;
            }

            var result1 = network.Compute(new double[] {1, 0, 1, 0, 1, 0, 1, 0});
            Console.WriteLine($"2 + 2, 2 * 2 = {result1[0]}, {result1[1]}");
            var result2 = network.Compute(new double[] {0, 1, 0, 1, 1, 0, 0, 1});
            Console.WriteLine($"1 + 1, 2 * 1 = {result2[0]}, {result2[1]}");
            var result3 = network.Compute(new double[] {1, 0, 1, 0, 0, 1, 0, 0});
            Console.WriteLine($"2 + 2, 1 * 0 = {result3[0]}, {result3[1]}");
            var result4 = network.Compute(new double[] {0, 1, 0, 0, 0, 1, 1, 0});
            Console.WriteLine($"1 + 0, 1 * 2 = {result4[0]}, {result4[1]}");
        }

        [Test]
        public void TestGenetic()
        {
            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(), inputCount, firstLayerNeurons, secondLayerNeurons, thirdLayerNeurons, lastLayerNeurons);
            EvolutionaryLearning superTeacher = new EvolutionaryLearning(network, 20);

            double lastError = double.MaxValue;
            int counter = 0;
            while (true)
            {
                counter++;
                var error = superTeacher.RunEpoch(input, output);
                if ((lastError - error < 0.00001 && error < 0.01) || counter > 12000)
                    break;
                lastError = error;
            }

            var result1 = network.Compute(new double[] {1, 0, 1, 0, 1, 0, 1, 0});
            Console.WriteLine($"2 + 2, 2 * 2 = {result1[0]}, {result1[1]}");
            var result2 = network.Compute(new double[] {0, 1, 0, 1, 1, 0, 0, 1});
            Console.WriteLine($"1 + 1, 2 * 1 = {result2[0]}, {result2[1]}");
            var result3 = network.Compute(new double[] {1, 0, 1, 0, 0, 1, 0, 0});
            Console.WriteLine($"2 + 2, 1 * 0 = {result3[0]}, {result3[1]}");
            var result4 = network.Compute(new double[] {0, 1, 0, 0, 0, 1, 1, 0});
            Console.WriteLine($"1 + 0, 1 * 2 = {result4[0]}, {result4[1]}");
        }
    }
}