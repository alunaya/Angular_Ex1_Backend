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
                    const int numberOfRandomServices = 6;
                    DateTime DateBeginMockData = new DateTime(2018, 1, 1);

                    string[] exampleAwsServices = {"EC2","RDS","S3","Other", "CodeBuild", "Rekognition", "Polly", "Lex", "CodeCommit", "Lambda", "DynamoDb", "ElastiCache", "CloudFront", "RedShift", "SNS", "GatwayApi" };

                    var dbContext = scope.ServiceProvider.GetRequiredService<AngularTest1DbContext>();
                    if (dbContext.Months.Count() > 0
                        && dbContext.ServicesBill.Count() > 0 
                        && dbContext.ReservationCoverages.Count() > 0)
                    {
                        return;
                    }

                    var ec2Client = scope.ServiceProvider.GetRequiredService<AmazonEC2Client>();
                    var result = await ec2Client.DescribeInstanceTypeOfferingsAsync(new DescribeInstanceTypeOfferingsRequest());
                    var rand = new Random();

                    HashSet<string> instanceTypes = new HashSet<string>();
                    HashSet<string> services = new HashSet<string>();


                    for (int i = 0;; i++) {

                        var month = new Months
                        {
                            Date = DateBeginMockData.AddMonths(i)
                        };

                        if(month.Date > DateTime.Now)
                        {
                            break;
                        }

                        dbContext.Months.Add(month);

                        if (month.Date.Month == 1 || month.Date.Month == 6)
                        {
                            while (instanceTypes.Count < numberOfRandomInstanceTypes)
                            {
                                var item = result.InstanceTypeOfferings[rand.Next(result.InstanceTypeOfferings.Count)].InstanceType;
                                instanceTypes.Add(item);
                            }

                            while (services.Count < numberOfRandomServices)
                            {
                                var item = exampleAwsServices[rand.Next(exampleAwsServices.Length)];
                                services.Add(item);
                            }
                        }

                        foreach (var service in services)
                        {
                            dbContext.ServicesBill.Add(new ServicesBill
                            {
                                Months = month,
                                ServicesName = service,
                                Bill = (decimal)Math.Round(rand.NextFloat(1000, 4000), 2)
                            });
                        }

                        foreach (var instanceType in instanceTypes)
                        {
                            float reservedHours = (float)Math.Round(rand.NextFloat(400, 750), 2);

                            dbContext.ReservationCoverages.Add(new ReservationCoverage
                            {
                                Months = month,
                                InstanceType = instanceType,
                                ReservedHours = reservedHours,
                                TotalHours = reservedHours + (float)Math.Round(rand.NextFloat(200, 3000), 2)
                            });
                        }

                        
                    }
                    dbContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
