﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

namespace Microsoft.Health.Fhir.Core.Logging.Metrics
{
    public interface IExceptionMetricNotification
    {
        string OperationName { get; set; }

        string ExceptionType { get; set; }

        string Severity { get; set; }
    }
}
