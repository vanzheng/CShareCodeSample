//-----------------------------------------------------------------------
// <copyright file="Model.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RelyingPartyLogic
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.EntityClient;
    using System.Data.Objects;
    using System.Linq;
    using System.Text;

    public partial class DatabaseEntities
    {
        /// <summary>
        /// Clears the expired nonces.
        /// </summary>
        /// <param name="transaction">The transaction to use, if any.</param>
        internal void ClearExpiredNonces(EntityTransaction transaction)
        {
            this.ExecuteCommand(transaction, "DatabaseEntities.ClearExpiredNonces");
        }

        /// <summary>
        /// Clears the expired associations.
        /// </summary>
        /// <param name="transaction">The transaction to use, if any.</param>
        internal void ClearExpiredAssociations(EntityTransaction transaction)
        {
            this.ExecuteCommand(transaction, "DatabaseEntities.ClearExpiredAssociations");
        }
    }
}
