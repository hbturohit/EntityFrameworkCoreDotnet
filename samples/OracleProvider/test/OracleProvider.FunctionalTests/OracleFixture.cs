// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore
{
    public class OracleFixture : ServiceProviderFixtureBase
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory => (TestSqlLoggerFactory)ListLoggerFactory;
        protected override ITestStoreFactory TestStoreFactory => OracleTestStoreFactory.Instance;

        public override DbContextOptionsBuilder AddOptions(DbContextOptionsBuilder builder)
            => base.AddOptions(builder).ConfigureWarnings(
                w =>
                    {
                        w.Log(RelationalEventId.QueryClientEvaluationWarning);
                        w.Log(OracleEventId.ByteIdentityColumnWarning);
                        w.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning);
                    });
    }
}
