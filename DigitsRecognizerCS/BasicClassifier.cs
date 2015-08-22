using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizerCS
{
    class BasicClassifier : IClassifier
    {
        private IEnumerable<Observation> _data;
        private readonly IDistance _distance;

        public BasicClassifier( IDistance distance )
        {
            _distance = distance;
        }
        public void Train(IEnumerable<Observation> trainingSet)
        {
            _data = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation currrentBest = null;
            var shortest = double.MaxValue;

            foreach (var obs in _data)
            {
                var dist = _distance.Between(obs.Pixels, pixels);
                if (dist < shortest)
                {
                    shortest = dist;
                    currrentBest = obs;
                }
            }

            return currrentBest?.Label;
        }
    }
}
