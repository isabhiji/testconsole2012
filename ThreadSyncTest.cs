﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole2012
{
    class Calculate
    {

        double baseNumber, firstTerm, secondTerm, thirdTerm;
        AutoResetEvent[] autoEvents;
        ManualResetEvent manualEvent;
        // Generate random numbers to simulate the actual calculations.
        Random randomGenerator;
        public Calculate()
        {
            autoEvents = new AutoResetEvent[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };

            manualEvent = new ManualResetEvent(false);
        }

        void CalculateBase(object stateInfo)
        {

            //baseNumber = randomGenerator.NextDouble();
            baseNumber = 2;

            // Signal that baseNumber is ready.
            manualEvent.Set();

        }

        // The following CalculateX methods all perform the same
        // series of steps as commented in CalculateFirstTerm.
        void CalculateFirstTerm(object stateInfo)
        {

            // Perform a precalculation.
            //double preCalc = randomGenerator.NextDouble();
            double preCalc = 10;
            // Wait for baseNumber to be calculated.
            manualEvent.WaitOne();

            // Calculate the first term from preCalc and baseNumber.
            firstTerm = preCalc * baseNumber;

            // *randomGenerator.NextDouble();


            Console.WriteLine("I" + firstTerm);
            // Signal that the calculation is finished.
            autoEvents[0].Set();

        }

        void CalculateSecondTerm(object stateInfo)
        {

            //double preCalc = randomGenerator.NextDouble();
            double preCalc = 12;
            manualEvent.WaitOne();

            //*** waiting for base no.
            autoEvents[0].WaitOne();

            //*** waiting for firstTerm.
            secondTerm = preCalc * baseNumber + firstTerm;

            // *
            //randomGenerator.NextDouble();
            autoEvents[0].Set();

            //*** setting for waitAll
            Console.WriteLine("II" + secondTerm);
            autoEvents[1].Set();

        }

        void CalculateThirdTerm(object stateInfo)
        {

            //double preCalc = randomGenerator.NextDouble();
            double preCalc = 14;
            manualEvent.WaitOne();

            thirdTerm = preCalc * baseNumber;

            // *
            //randomGenerator.NextDouble();
            Console.WriteLine("III" + thirdTerm);
            autoEvents[2].Set();

        }

        public double Result(int seed)
        {

            randomGenerator =

            new Random(seed);
            // Simultaneously calculate the terms.
            ThreadPool.QueueUserWorkItem(
            new WaitCallback(CalculateBase));
            ThreadPool.QueueUserWorkItem(
            new WaitCallback(CalculateFirstTerm));
            ThreadPool.QueueUserWorkItem(
            new WaitCallback(CalculateSecondTerm));
            ThreadPool.QueueUserWorkItem(
            new WaitCallback(CalculateThirdTerm));
            // Wait for all of the terms to be calculated.
            WaitHandle.WaitAll(autoEvents);
            // Reset the wait handle for the next calculation.
            manualEvent.Reset();

            return firstTerm + secondTerm + thirdTerm;
        }

    }

}

