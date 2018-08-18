// <copyright file="IVariables.cs" company="Microsoft">
// Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>

namespace FiniteModelChecker
{
    /// <summary>
    /// Interface which must be implemented by variables classes used in model checking.
    /// </summary>
    public interface IVariables
    {
        /// <summary>
        /// Gets a unique long object hash.
        /// </summary>
        /// <returns>A long object hash.</returns>
        long GetLongHashCode();
    }
}