using Angular_Ex1_Backend.Database.CodeFirst;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Amazon.EC2;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Amazon.EC2.Model;
using Microsoft.Extensions.Logging;

namespace Angular_Ex1_Backend
{
    public class SeedData: IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public SeedData(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    const int numberOfRandomInstanceTypes = 10;

                    var dbContext = scope.ServiceProvider.GetRequiredService<AngularTest1DbContext>();
                    if (dbContext.ServicesBill.Count() > 0 && dbContext.ReservationCoverages.Count() > 0)
                    {
                        return;
                    }

                    var ec2Client = scope.ServiceProvider.GetRequiredService<AmazonEC2Client>();
                    var result = await ec2Client.DescribeInstanceTypeOfferingsAsync(new DescribeInstanceTypeOfferingsRequest());
                    var rand = new Random();

                    HashSet<string> instanceTypes = new HashSet<string>();
                    while (instanceTypes.Count < numberOfRandomInstanceTypes)
                    {
                        var item = result.InstanceTypeOfferings[rand.Next(result.InstanceTypeOfferings.Count)].InstanceType;
                        instanceTypes.Add(item);
                    }

                    foreach (var instanceType in instanceTypes)
                    {
                        
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
