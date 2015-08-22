using System;

namespace DigitsRecognizerCS
{
    class Program
    {
        static void Main( string [] args )
        {
            var distance = new ManhatanDistance();
            var classifier = new BasicClassifier(distance);

            const string pathToDataDir = @"D:\repos\MLProjects\data\";

            var trainingPath = pathToDataDir + "trainingsample.csv";
            var training = DataReader.ReadObservations(trainingPath);
            classifier.Train(training);

            var validationPath = pathToDataDir + "validationsample.csv";
            var validation = DataReader.ReadObservations(validationPath);

            var correct = Evaluator.Correct(validation, classifier);
            Console.WriteLine("Correctly classified: {0:p2}", correct);

            Console.Read();

        }
    }
}
