﻿using Microsoft.Extensions.Logging;
using Polly;
using Polly.Wrap;


namespace NexCart.Orders.Policies
{
    public class UsersMicroservicePolicies : IUsersMicroservicePolicies
    {
        private readonly ILogger<UsersMicroservicePolicies> _logger;
        private readonly IPollyPolicies _pollyPolicies;

        public UsersMicroservicePolicies(ILogger<UsersMicroservicePolicies> logger, IPollyPolicies pollyPolicies)
        {
            _logger = logger;
            _pollyPolicies = pollyPolicies;
        }

        //public IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        //{
        //    AsyncCircuitBreakerPolicy<HttpResponseMessage> policy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
        //    .CircuitBreakerAsync(
        //     handledEventsAllowedBeforeBreaking: 3, //Number of retries
        //     durationOfBreak: TimeSpan.FromMinutes(2), // Delay between retries
        //     onBreak: (outcome, timespan) =>
        //     {
        //         _logger.LogInformation($"Circuit breaker opened for {timespan.TotalMinutes} minutes due to consecutive 3 failures. The subsequent requests will be blocked");
        //     },
        //     onReset: () => {
        //         _logger.LogInformation($"Circuit breaker closed. The subsequent requests will be allowed.");
        //     });

        //    return policy;

        //}

        //public IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        //{
        //    AsyncRetryPolicy<HttpResponseMessage> policy = Policy.HandleResult<HttpResponseMessage>(r => r.IsSuccessStatusCode)
        //       .WaitAndRetryAsync(retryCount: 5, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
        //        onRetry: (outcome, timespan, retryAttempt, context) =>
        //        {
        //            _logger.LogInformation($"Retry policy{retryAttempt} after {timespan.TotalSeconds}secound");
        //        });
        //    return policy;
        //}

        //public IAsyncPolicy<HttpResponseMessage> GetTimeoutPolicy()
        //{
        //    AsyncTimeoutPolicy<HttpResponseMessage> policy =
        //        Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMilliseconds(1500));
        //    return policy;
        //}

        public IAsyncPolicy<HttpResponseMessage> GetCombinedPolicy()
        {
            var retryPolicy = _pollyPolicies.GetRetryPolicy(3);
            var circuitBreakerPolicy = _pollyPolicies.GetCircuitBreakerPolicy(3, TimeSpan.FromMinutes(2));
            var timeoutPolicy = _pollyPolicies.GetTimeoutPolicy(TimeSpan.FromSeconds(5));

            AsyncPolicyWrap<HttpResponseMessage> wrappedPolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy, timeoutPolicy);
            return wrappedPolicy;
        }
    }
}
