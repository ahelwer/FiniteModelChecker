// <copyright file="TestFiniteModelChecker.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace FiniteModelChecker.Tests
{
    using System;
    using System.Linq;
    using FiniteModelChecker;
    using FiniteModelChecker.Tests.GeneralizedDieHard;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="FiniteModelChecker"/> module.
    /// </summary>
    [TestClass]
    public class TestFiniteModelChecker
    {
        /// <summary>
        /// Tests the model checker with the <see cref="GeneralizedDieHard"/> module.
        /// </summary>
        [TestMethod]
        [Timeout(30000)]
        public void TestGeneralizedDieHard()
        {
            ModelCheckReport<Constants, Variables> report = Models.CheckBasic();
            Console.WriteLine(report);
            Assert.IsFalse(report.Success);
            Assert.AreEqual(typeof(Goal), report.SafetyInvariantsViolated.Single().Invariant.GetType());

            report = Models.CheckLarge();
            Console.WriteLine(report);
            Assert.IsFalse(report.Success);
            Assert.AreEqual(typeof(Goal), report.SafetyInvariantsViolated.Single().Invariant.GetType());

            report = Models.CheckImpossible();
            Console.WriteLine(report);
            Assert.IsTrue(report.Success);
        }
    }
}