﻿using InfluxData.Net.InfluxDb.Constants;
using InfluxData.Net.InfluxDb.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfluxData.Net.InfluxDb.RequestClients.Modules
{
    internal class RetentionRequestModule : RequestModuleBase, IRetentionRequestModule
    {
        public RetentionRequestModule(IInfluxDbRequestClient requestClient) 
            : base(requestClient)
        {
        }

        public async Task<IInfluxDbApiResponse> AlterRetentionPolicy(string dbName, string policyName, string duration, int replication)
        {
            var query = String.Format(QueryStatements.AlterRetentionPolicy, policyName, dbName, duration, replication);
            var requestParams = RequestClientUtility.BuildQueryRequestParams(query);

            return await this.RequestClient.GetQueryAsync(requestParams: requestParams);
        }
    }
}
