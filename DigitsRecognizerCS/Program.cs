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

            var training = DataReader.ReadObservations( pathToDataDir + "trainingsample.csv" );
            classifier.Train(training);

            var validation = DataReader.ReadObservations( pathToDataDir + "validationsample.csv" );

            var correct = Evaluator.Correct(validation, classifier);
            Console.WriteLine("Correctly classified: {0:p2}", correct);

            Console.Read();

        }
    }
}
