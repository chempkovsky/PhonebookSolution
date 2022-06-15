#nullable disable
using MassTransit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;




/*
    according to https://masstransit-project.com/usage/configuration.html#configuration
    make sure Program.cs file contains the following code:

#region MassTransit config
using MassTransit;
#endregion
...
var builder = WebApplication.CreateBuilder(args);
...

#region MassTransit config
builder.Services.AddMassTransit(x => {

    x.AddConsumer<PhbkEmployeeViewExtForLkUpMsgConsumer>(typeof(PhbkEmployeeViewExtForLkUpMsgConsumerDefinition));
        //.Endpoint(e =>
        //{
            // override the default endpoint name
            // e.Name =   phbk-employee-view;

            // specify the endpoint as temporary (may be non-durable, auto-delete, etc.)
            e.Temporary = false;

            // specify an optional concurrent message limit for the consumer
            e.ConcurrentMessageLimit = 8;

            // only use if needed, a sensible default is provided, and a reasonable
            // value is automatically calculated based upon ConcurrentMessageLimit if 
            // the transport supports it.
            e.PrefetchCount = 16;

            // set if each service instance should have its own endpoint for the consumer
            // so that messages fan out to each instance.
            e.InstanceId = "something-unique";
        //});

    x.UsingRabbitMq((context, configurator) => {
        configurator.Host("192.168.100.4", "RabbitMq_virtual_host_name", h =>
        {
            h.Username("RabbitMq_admin_name");
            h.Password("RabbitMq_admin_password");
            // 
            // Cluster settings
            //
            // h.UseCluster((configureCluster) =>
            // {
            //   configureCluster.Node("192.168.100.5");
            //   configureCluster.Node("192.168.100.6");
            //   ...
            //   configureCluster.Node("192.168.100.10");
            // });
            // h.PublisherConfirmation = true;
            //h.ConfigureBatchPublish(configure =>
            //{
            //});
        });
        // 
        // Quorum Queue settings
        //
        // configurator.SetQuorumQueue(3);
        //

        configurator.ConfigureEndpoints(context);
    });
});
builder.Services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    // if specified, waits until the bus is started before
                    // returning from IHostedService.StartAsync
                    // default is false
                    options.WaitUntilStarted = true;

                    // if specified, limits the wait time when starting the bus
                    options.StartTimeout = TimeSpan.FromSeconds(10);

                    // if specified, limits the wait time when stopping the bus
                    options.StopTimeout = TimeSpan.FromSeconds(30);

                });
#endregion


*/



using LpPhBkContext.PhBk;
using PhBkViews.PhBk;
using LpPhBkControllers.Helpers;
using LpPhBkViews.PhBk;


namespace LpPhBkControllers.Consumers {

    public class PhbkEmployeeViewExtForLkUpMsgConsumer: IConsumer<IPhbkEmployeeViewExtForLkUpMsg> {
        private readonly ILogger<PhbkEmployeeViewExtForLkUpMsgConsumer> _logger;
        // private readonly PhbkDbContext db;
        IServiceScopeFactory _serviceScopeFactory;

        // public PhbkEmployeeViewExtForLkUpMsgConsumer(PhbkDbContext dbcontext, ILogger<PhbkEmployeeViewExtForLkUpMsgConsumer> logger)
        public PhbkEmployeeViewExtForLkUpMsgConsumer(IServiceScopeFactory serviceScopeFactory, ILogger<PhbkEmployeeViewExtForLkUpMsgConsumer> logger)
        {
            // db = dbcontext;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<IPhbkEmployeeViewExtForLkUpMsg> context)
        {
            // _logger.LogInformation("Order Submitted: {OrderId}", context.Message.OrderId);
            using (IServiceScope scope = _serviceScopeFactory.CreateScope()) {
                LpEmpPhBkContext db = scope.ServiceProvider.GetRequiredService<LpEmpPhBkContext>();
                await M2mUpdaterPhbkEmployeeView.UpdateForPhbkEmployeeView(db, context.Message.Action, context.Message.OldVals, context.Message.NewVals);
            }
        }
    }

    public class PhbkEmployeeViewExtForLkUpMsgConsumerDefinition: ConsumerDefinition<PhbkEmployeeViewExtForLkUpMsgConsumer> {
        public PhbkEmployeeViewExtForLkUpMsgConsumerDefinition()
        {
            // override the default endpoint name
            // EndpointName = "order-service";
            //
            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            // ConcurrentMessageLimit = 8;
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<PhbkEmployeeViewExtForLkUpMsgConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100,200,500,800,1000));

            // use the outbox to prevent duplicate events from being published
            // endpointConfigurator.UseInMemoryOutbox();
        }
    }
}

