using Accord.Neuro.ActivationFunctions;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace ColorfulCylinderPuzzle.Neuro
{
    public class Bla
    {
        public void Test()
        {
            var test = new PerceptronLearning(new ActivationNetwork(new BernoulliFunction(0.02), 12, new[] {3, 4, 2}));
        }
    }
}