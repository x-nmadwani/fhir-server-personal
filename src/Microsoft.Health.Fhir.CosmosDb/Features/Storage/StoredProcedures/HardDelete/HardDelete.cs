﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EnsureThat;
using Microsoft.Azure.Cosmos.Scripts;
using Microsoft.Health.Fhir.Core.Features.Persistence;
using Microsoft.Health.Fhir.CosmosDb.Core.Features.Storage.StoredProcedures;
using Microsoft.Health.Fhir.CosmosDb.Initialization.Features.Storage.StoredProcedures.HardDelete;

namespace Microsoft.Health.Fhir.CosmosDb.Features.Storage.StoredProcedures.HardDelete
{
    internal class HardDelete : StoredProcedureBase
    {
        public HardDelete()
           : base(new HardDeleteMetadata())
        {
        }

        public async Task<StoredProcedureExecuteResponse<int>> Execute(Scripts client, ResourceKey key, bool keepCurrentVersion, bool allowPartialSuccess, CancellationToken cancellationToken)
        {
            EnsureArg.IsNotNull(client, nameof(client));
            EnsureArg.IsNotNull(key, nameof(key));

            return await ExecuteStoredProcAsync<int>(client, key.ToPartitionKey(), cancellationToken, key.ResourceType, key.Id, keepCurrentVersion, allowPartialSuccess);
        }
    }
}
