using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace AWSSecretManager
{
    public class GetSecretsResult : ISecretResult
    {
        private readonly IAmazonSecretsManager _amazonSecretsManager;
        public GetSecretsResult(IAmazonSecretsManager amazonSecretsManager)
        {

            _amazonSecretsManager = amazonSecretsManager;

        }


        public async Task<string> GetSecret()
        {

            string region = "ap-southeast-2";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = "awsSecret",
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }

            return response.SecretString;

            // Your code goes here


        }

    }
}
