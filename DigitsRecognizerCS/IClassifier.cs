using System.Collections.Generic;

namespace DigitsRecognizerCS
{
    interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }
}
