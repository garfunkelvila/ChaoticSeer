using gSeer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPropagationTest {
	class Program {
		static Seer _seer = new Seer(2, 1, 2);
		static TrainingData[] _and = new TrainingData[] {
				new TrainingData(
					new float[2] { 0, 0 },
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 0, 1 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 0 },
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 1 }
				)
			};
		//Out 1
		static TrainingData[] _or = new TrainingData[] {
				new TrainingData(
					new float[2] { 0, 0 },
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 0, 1 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 0 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 1 }
				)
			};
		//Out 0
		static TrainingData[] _xor = new TrainingData[] {
				new TrainingData(
					new float[2] { 0, 0 },
					new float[1] { 0 }
				),
				new TrainingData(
					new float[2] { 0, 1 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 0 },
					new float[1] { 1 }
				),
				new TrainingData(
					new float[2] { 1, 1 },
					new float[1] { 0 }
				)
			};
		static void Main(string[] args) {
			do {
				_seer.Train(_or, 100000);
				float _pred1 = _seer.Predict(new float[2] { 0, 0 })[0];
				float _pred2 = _seer.Predict(new float[2] { 0, 1 })[0];
				float _pred3 = _seer.Predict(new float[2] { 1, 0 })[0];
				float _pred4 = _seer.Predict(new float[2] { 1, 1 })[0];
				Console.WriteLine("0 :: Prediction: " + _pred1);
				Console.WriteLine("1 :: Prediction: " + _pred2);
				Console.WriteLine("1 :: Prediction: " + _pred3);
				Console.WriteLine("1 :: Prediction: " + _pred4);

				Console.WriteLine("Correct: 0 : err : " + _seer.GetError()[0]);
				Console.ReadKey();
			} while (true);
			
		}
	}
}
