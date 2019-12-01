using System;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day1.Test
{
    public class FuelCalculatorTest
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Example1(int mass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCalculator.Calculate(mass));
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Example2(int mass, int expectedFuel)
        {
            Assert.Equal(expectedFuel, FuelCalculator.CalculateIncludingItselfRecursive(mass));
        }

        [Fact]
        public void Actual()
        {
            var input = @"101005
139223
112833
70247
131775
106730
118388
138683
80439
71060
120862
67201
70617
79783
114813
77907
78814
107515
113507
81865
88130
75120
66588
56023
98080
128472
96031
118960
54069
112000
62979
105518
73342
52270
128841
68267
70789
94792
100738
102331
83082
77124
97360
86165
66120
139042
50390
105308
94607
58225
77894
118906
127277
101446
58897
93876
53312
117154
77448
62041
99069
87375
134854
108561
126406
53809
90760
121650
79573
134734
148021
84263
54390
132706
148794
67302
146885
76108
76270
54548
146920
145282
129509
144139
141713
62547
149898
96746
83583
107758
63912
142036
112281
91775
75809
82250
144667
140140
98276
103479".Split(Environment.NewLine);
            var answer = input.Sum( i => FuelCalculator.CalculateIncludingItself(int.Parse(i)));
        }
    }
}
