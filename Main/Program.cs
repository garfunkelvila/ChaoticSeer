using System;

namespace Main {
	class Program {
		static Test test = new Test();
		static void Main(string[] args) {
			Console.WriteLine("Hello World!");
			test.calc();
		}

	}

	class Test {
		int test = 10;

		public void calc() {
			int i = REFINT();
			i = 100;
        }


		public ref int REFINT() {
			return ref test;
        }
    }
}
