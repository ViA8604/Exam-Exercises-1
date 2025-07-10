using System;
using System.Diagnostics;

namespace Molecules
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSimple();
        }

        static void TestSimple()
        {
            string[] atomos = { "A", "B", "C" };
            bool[,] enlaces = { { false, true,  false},
                                { true,  false, true},
                                { false, true,  false } };

            string[] sentinel = { "S", "T", "P", "I", "D" };
            bool[,] sentinelLinks = {
                                    { false, true, true, false, false },
                                    {true, false, false, true, false},
                                    {true, false, false, true, false},
                                    {false, true, true, false, true},
                                    {false, false, false, true, false}
            };

            string[] test = { "S", "T", "P", "I", "D", "D" };
            bool[,] testLinks = {
                                    { false, true, true, false, false, true },
                                    {true, false, false, true, false, false},
                                    {true, false, false, true, false, false},
                                    {false, true, true, false, true, false,},
                                    {false, false, false, true, false, false},
                                    {true, false, false, false, false, false}
            };


            string[] atoms = { "S", "T", "P", "I", "D", "S", "S", "P", "T", "I", "D", "S", "T", "S", "P", "I", "D" };
            bool[,] atomsLinks = {
                            //  0     1     2     3       4     5       6     7       8     9      10     11     12     13     14     15     16     17
                            {false, true,  true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false, false}, //0
                            {true,  false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false}, //1
                            {true,  false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false}, //2
                            {false, true,  true,  false, true,  false, false, false, false, false, false, false, false, false, false, false, false, false}, //3
                            {false, false, false, true,  false, false, false, false, false, false, false, false, false, false, false, false, false, false}, //4
                            {false, false, false, false, false, false, true,  false, false, true,  false, false, false, false, false, false, false, false}, //5
                            {false, false, false, false, false, true,  false, true,  true,  false, false, false, false, false, false, false, false, false}, //6
                            {false, false, false, false, false, false, true,  false, false, true,  false, false, false, false, false, false, false, false}, //7
                            {false, false, false, false, false, false, true,  false, false, true,  false, false, false, false, false, false, false, false}, //8
                            {false, false, false, false, false, true,  false, true,  true,  false, true,  true,  false, false, false, false, false, false}, //9
                            {false, false, false, false, false, false, false, false, false, true,  false, false, true,  false, false, false, false, false}, //10
                            {false, false, false, false, false, false, false, false, false, true,  false, false, true,  false, false, false, false, false}, //11
                            {false, false, false, false, false, false, false, false, false, false, true,  true,  false, true,  false, false, false, false}, //12
                            {false, false, false, false, false, false, false, false, false, false, false, false, true,  false, true,  false, false, true}, //13
                            {false, false, false, false, false, false, false, false, false, false, false, false, false, true,  false, true,  false, false}, //14
                            {false, false, false, false, false, false, false, false, false, false, false, false, false, false, true,  false, true,  false}, //15
                            {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true,  false, true}, //16
                            {false, false, false, false, false, false, false, false, false, false, false, false, false, true,  false, false, true,  false}, //17

            };

            Debug.Assert(Exam.EstaInfectado(atomos, enlaces, atomos, enlaces)); //ok
            Debug.Assert(Exam.EstaInfectado(atoms, atomsLinks, sentinel, sentinelLinks)); //ok
            Debug.Assert(Exam.EstaInfectado(test, testLinks, sentinel, sentinelLinks)); //ok
        }
    }
}