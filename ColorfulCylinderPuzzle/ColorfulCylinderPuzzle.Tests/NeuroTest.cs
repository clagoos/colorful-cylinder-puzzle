using System;
using AForge.Neuro;
using AForge.Neuro.Learning;
using NUnit.Framework;

namespace ColorfulCylinderPuzzle.Tests
{
    [TestFixture]
    public class NeuroTest
    {
        [Test]
        public void Test()
        {
            ActivationNetwork network = new ActivationNetwork(new SigmoidFunction(), 3, 2, 2);

            BackPropagationLearning teacher = new BackPropagationLearning(network);

            var error = teacher.RunEpoch(new[] {new double[] {0, 1, 1}, new double[] {1, 1, 0}}, new[] {new double[] {0, 1, 1}, new double[] {1, 1, 0}});
        }
    }
}