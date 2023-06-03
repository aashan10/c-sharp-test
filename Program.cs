class Program {
        static void Main(string[] args) {
            int numberOfItems = Program.GetNumberOfItems();
            double[][] x = Program.GetXValues(numberOfItems);

            double[] fx = new double[numberOfItems];

            for (int i = 0; i < numberOfItems; i++) {
                fx[i] = Program.CalculateFunctionValue(x[i]);
            }

            Program.PrettyPrintArray(fx, x);
        }

        static int GetNumberOfItems() {
            Console.WriteLine("Enter the total number of items:");
            string val = Console.ReadLine();
            return Convert.ToInt32(val);
        }

        static double[][] GetXValues(int iterations) {
            Console.WriteLine("Enter x, x1, x2 and x3 (Press Enter after entering each number):");
            double[][] values = new double[iterations][];

            for (int i = 0; i < iterations; i++ ) {
                Console.WriteLine("Iteration: {0}", i + 1);
                Console.WriteLine("--------------");
                Console.WriteLine();

                Console.WriteLine("Enter x:");
                double x = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter x1:");
                double x1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter x2:");
                double x2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter x3:");
                double x3 = Convert.ToDouble(Console.ReadLine());

                values[i] = new double[4] {x,x1,x2,x3};
            }
            
            return values;
        }

        static double CalculateFunctionValue(double[] x) {
            

            if (x[1] <= x[0] && x[0]<= x[2]) {
                return ((x[0]-x[1])/(x[2]-x[1])) * (x[3] - x[1]);
            }

            if (x[2] < x[0] && x[0] <= x[3]) {
                return ((x[0]-x[2])/(x[3]-x[2])) * (x[2] - x[1]);
            }

            if (x[0] > x[3]) {
                return x[3];
            }

            return 0.0;
        }

        static void PrettyPrintArray(double[] fx, double[][] x) {
            int length = x.Length;
            double max = fx[0];
            double min = fx[0];
            int positiveCount = 0;
            int negativeCount = 0;
            int zeroCount = 0;

            Console.WriteLine("\n");
            Console.WriteLine("Iteration\tX\tX1\tX2\tX3\tf(x)");
            for (int i = 0; i < length; i++) {
                Console.WriteLine("---------------------------------------------------");
                
                // Calculate max value
                if (fx[i] > max) {
                    max = fx[i];
                } 

                // Calculate min value
                if (fx[i] < min) {
                    min = fx[i];
                }

                if (fx[i] > 0) {
                    positiveCount++;
                } else if (fx[i] == 0) {
                    zeroCount++;
                } else {
                    negativeCount++;
                }


                double x0 = x[i][0]; 
                double x1 = x[i][1]; 
                double x2 = x[i][2]; 
                double x3 = x[i][3];
                Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}",i+1, x0, x1,x2,x3,fx[i]);
            }

            Console.WriteLine("===================================================");
            

            Console.WriteLine("Positive Count: {0}", positiveCount);
            Console.WriteLine("Negative Count: {0}", negativeCount);
            Console.WriteLine("Zero Count: {0}", zeroCount);
            Console.WriteLine("Min: {0}", min);
            Console.WriteLine("Max: {0}", max);

        }
    }

