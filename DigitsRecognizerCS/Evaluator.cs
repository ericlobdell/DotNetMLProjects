using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DigitsRecognizerCS
{
    class Evaluator
    {
        public static double Correct(IEnumerable<Observation> validationSet, IClassifier classifier)
        {
            return validationSet.Select(obs => Score(obs, classifier))
                .Average();
        }

        private static double Score(Observation obs, IClassifier classifier)
        {
            return classifier.Predict(obs.Pixels) == obs.Label ? 1.0 : 0.0;
        }
    }
}
