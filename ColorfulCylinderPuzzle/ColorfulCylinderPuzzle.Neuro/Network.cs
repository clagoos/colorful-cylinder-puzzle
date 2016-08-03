using Accord.Neuro;
using Accord.Neuro.Networks;
using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorfulCylinderPuzzle.Neuro
{
    //This class is just a little bit adjusted copy of code from link below (link to example of using DeepBeliefNetwork)
    //TODO: It requires major changes in the future, it exists just as a reminder of how to use DeepBeliefNetwork for now... :)
    //there is an example of using DeepBeliefNetwork on github: https://github.com/primaryobjects/deep-learning/blob/XOR/DeepLearning/Program.cs
    public class Network
    {
        private readonly ISupervisedLearning teacher;
        private readonly DeepBeliefNetwork network;

        private int learningCycles = 1000;

        public int InputsCount { get; } = 182;
        public int HiddenLayerNeuronsCount { get; } = 26;
        public int OutputsCount { get; } = 5;

        /// <summary>
        /// Use this constructor only if you want to specify different neurons count than default.
        /// </summary>
        public Network(int inputsCount, int hiddenLayerNeuronsCount, int outputsCount)
        {
            InputsCount = inputsCount;
            HiddenLayerNeuronsCount = hiddenLayerNeuronsCount;
            OutputsCount = outputsCount;
        }

        public Network()
        {
            // Setup the deep belief network and initialize with random weights.
            network = new DeepBeliefNetwork(InputsCount, HiddenLayerNeuronsCount, OutputsCount);
            new GaussianWeights(network).Randomize();
            network.UpdateVisibleWeights();

            // Setup the learning algorithm.
            teacher = new BackPropagationLearning(network)
            {
                LearningRate = 0.2,
                Momentum = 0.5
            };
        }

        public IEnumerable<double> Learn(double[][] inputs, double[][] outputs)
        {
            // Run supervised learning.
            for (int i = 0; i < learningCycles; i++)
            {
                var error = teacher.RunEpoch(inputs, outputs) / inputs.Length;
                yield return error;
            }
        }

        public double TestAccuracy(double[][] testInputs, double[][] testOutputs)
        {
            // Test the resulting accuracy.
            var correctCounter = 0;
            for (int i = 0; i < testInputs.Length; i++)
            {
                double[] outputValues = network.Compute(testInputs[i]);
                if (GetIndexOfMaxElement(outputValues) == GetIndexOfMaxElement(testOutputs[i]))
                {
                    correctCounter++;
                }
            }
            return Math.Round((correctCounter / (double)testInputs.Length * 100), 2);
        }

        private static int GetIndexOfMaxElement(double[] values)
        {
            return values.ToList().IndexOf(values.Max());
        }
    }
}